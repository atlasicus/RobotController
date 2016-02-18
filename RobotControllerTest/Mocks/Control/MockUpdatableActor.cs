using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RobotController.Robots.Interface;
using RobotControllerTest.Utils;

namespace RobotControllerTest.Mocks.Control
{
    class MockUpdatableActor : RobotController.Control.Interface.UpdatableActor
    {
        Vector2 actorCoords;
        float actorAngle;

        int tileSize;

        public MockUpdatableActor(int tileSize = 32, float actorAngle = 0f)
        {
            this.actorCoords = new Vector2(0, 0);
            this.tileSize = tileSize;
            this.actorAngle = actorAngle;
        }

        public Vector2 GetPosition()
        {
            return actorCoords;
        }

        public float GetRotation()
        {
            return actorAngle;
        }

        public int getTileSize()
        {
            return tileSize;
        }

        public void setTileSize(int tileSize)
        {
            this.tileSize = tileSize;
        }

        public void UpdatePosition(Vector2 position)
        {
            actorCoords = position;

            Point resultOutput = position.ToPoint();
            Results.AddResult("m:" + resultOutput.X.ToString() + resultOutput.Y.ToString());
        }

        public void UpdateRotation(float angle)
        {
            actorAngle = angle;

            bool correctRotation = (angle % MathHelper.PiOver2) == 0;
            Results.AddResult("r:" + Convert.ToInt32(correctRotation).ToString());
        }

        public void draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public Actor GetActor()
        {
            throw new NotImplementedException();
        }

    }
}
