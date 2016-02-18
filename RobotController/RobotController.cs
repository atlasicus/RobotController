using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RobotController.Control.Implementation;
using RobotController.Navigation.Implementation;
using RobotController.Renderer.Implementation;
using RobotController.Topography.Implementation;
using RobotController.Utils;

namespace RobotController
{
    /// <summary>
    /// 
    /// </summary>
    public class RobotController : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D robotTexture;
        Rectangle robotRectangle;

        Texture2D blankTexture;
        Texture2D rockTexture;
        Texture2D holeTexture;
        Texture2D spinnerTexture;

        //RoboManagers correlate Actor position to DrawableActor Position
        //In this case, Actor is an AcceptanceRobo
        //DrawableActor is an implementation for handling textures
        AcceptanceRoboManager roboManager;

        //NavigationManagers handle how an Actor navigates a CoordinateSystem;
        //In this case, the Actor is an AcceptanceRobo, and 
        //the CoordinateSystem is a SymmetricalTileMap;
        AcceptanceNavigationManager navManager;

        //TileTraversalManagers handle how a Robot interacts with underlying Tiles on a TileMap
        AcceptanceTTManager tileTraversalManager;

        //TileMaps hold an array of interactionvalues
        SymmetricalTileMap tileMap;

        //SpriteMaps correlate a texture to a TileMap interactionValue;
        SpriteMap spriteMap;

        private const float MoveTime = 500f;
        private float nextMoveInMilliseconds = MoveTime;
        private bool isReadyForNextMove = false;

        private bool errorStateReached = false;

        private Queue<string> simulationQueue;

        private Texture2D TileToDraw;
        private const int TileSize = 32;

        private bool IsReadyForUpdate = false;

        public RobotController(string input)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            tileTraversalManager = new AcceptanceTTManager();

            spriteMap = new SpriteMap();

            //Hardcoded due to time constraints, would prefer to have used a rule content manager
            try
            {
                XmlRuleParser.LoadRules("rules.xml", ref tileTraversalManager);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error loading rules file: " + e.StackTrace);
                errorStateReached = true;
            }
            catch (XmlException e)
            {
                Console.WriteLine("Error parsing rules: " + e.StackTrace);
                errorStateReached = true;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Generic XML Error " + e.StackTrace);
                errorStateReached = true;
            }

            //Hardcoded due to time constraints, would prefer to have used a map content manager
            try {
                byte[,] mapLayout = CSVReader.GetSymmetrical("map.csv");
                if (mapLayout.GetLength(0) != mapLayout.GetLength(1))
                {
                    Console.WriteLine("Error: Map inputted must be square");
                    errorStateReached = true;
                }
                else
                {
                    graphics.PreferredBackBufferWidth = mapLayout.GetLength(0) * TileSize;
                    graphics.PreferredBackBufferHeight = mapLayout.GetLength(1) * TileSize;

                }

                tileMap = MapBuilder.BuildSymmetrical(mapLayout, tileTraversalManager);
            } catch(FileNotFoundException e) {
                Console.WriteLine("Error: Unable to load map data " + e.StackTrace);
                errorStateReached = true;
            } catch (IOException e) {
                Console.WriteLine("Generic File Error " + e.StackTrace);
                errorStateReached = true;
            }
            
            simulationQueue = Parsers.TokenizeToFIFOQueue(input);

            Console.WriteLine("Starting now");
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            if (errorStateReached == false)
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);

                robotTexture = Content.Load<Texture2D>("robot");
                robotRectangle = new Rectangle(0, 0, TileSize, TileSize);

                //Need to make new roboManager here due to 
                //robotTexture being uninitialized before LoadContent() is called
                roboManager = new AcceptanceRoboManager(robotTexture, robotRectangle);

                //needs an initialized roboManager
                navManager = new AcceptanceNavigationManager(roboManager, tileTraversalManager, tileMap);

                rockTexture = Content.Load<Texture2D>("rock");
                spinnerTexture = Content.Load<Texture2D>("spinner");
                holeTexture = Content.Load<Texture2D>("hole");

                //Making a texture for empty interactions
                blankTexture = new Texture2D(GraphicsDevice, TileSize, TileSize);
                Color[] colorData = new Color[TileSize * TileSize];
                for(int i = 0; i < colorData.Length; ++i)
                {
                    colorData[i] = Color.Green;
                }

                blankTexture.SetData(colorData);

                //Due to time constraints, this is hardcoded.
                //Would have built a more robust XML structure 
                //And association system which would have had this information encoded

                spriteMap.SetAssociation(blankTexture, 0);
                spriteMap.SetAssociation(rockTexture, 1);
                spriteMap.SetAssociation(holeTexture, 2);
                spriteMap.SetAssociation(spinnerTexture, 3);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Small number of assets, no unloading necessary, but method must be implemented
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if(IsReadyForUpdate)
            {
                if (errorStateReached)
                {
                    Exit();
                    return;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    Console.WriteLine("Exit key pressed, terminating simulation");
                    Exit();
                    return;
                }

                if (simulationQueue.Count <= 0)
                {
                    Console.WriteLine("Simulation has completed press enter key to close sim window");
                    Console.ReadLine();
                    Exit();
                    return;
                }

                else
                {
                    if (isReadyForNextMove)
                    {
                        string nextMove = simulationQueue.Dequeue();
                        InputInterpreter.NextMove(nextMove, ref navManager);
                        isReadyForNextMove = false;
                        IsReadyForUpdate = false;
                    }
                    else
                    {
                        nextMoveInMilliseconds -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                        if (nextMoveInMilliseconds < 0)
                        {
                            isReadyForNextMove = true;
                            nextMoveInMilliseconds = MoveTime;
                        }
                    }
                }

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);

            spriteBatch.Begin();

            for (int i = 0; i < tileMap.GetSizeY(); ++i)
            {
                for (int j = 0; j < tileMap.GetSizeX(); ++j)
                {
                    TileToDraw = spriteMap.GetAssociation(tileMap.GetElement(i, j).GetInteractionValue());
                    spriteBatch.Draw(TileToDraw, new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize), Color.White);
                }
            }

            roboManager.draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);

            IsReadyForUpdate = true;
        }
    }
}
