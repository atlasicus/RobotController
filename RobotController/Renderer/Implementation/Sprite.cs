using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RobotController.Renderer.Implementation
{
    class Sprite : Interface.Texture2DElement
    {
        protected Texture2D texture;
        protected Rectangle position;

        public Sprite(Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
        }    
        public Texture2D GetTexture2D()
        {
            return texture;
        }

        public Rectangle getPosition()
        {
            return position;
        }

        public virtual void setPosition(int x, int y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public void setPosition(Rectangle position)
        {
            this.position = position;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }
    }
}
