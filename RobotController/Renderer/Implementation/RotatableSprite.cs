using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RobotController.Renderer.Interface;

namespace RobotController.Renderer.Implementation
{
    class RotatableSprite : Sprite, Interface.RotatableTexture2DElement
    {
        protected float angle;

        public RotatableSprite (Texture2D texture, Rectangle position)
            :base(texture, position)
        {
            this.texture = texture;
            this.position = position;
            this.position.X += 16;
            this.position.Y += 16;
            angle = 0f;
        }

        public RotatableSprite(Texture2D texture, Rectangle position, float angle)
            : base(texture, position)
        {
            this.texture = texture;
            this.position = position;
            this.angle = angle;
        }

        public override void setPosition(int x, int y)
        {
            position.X = x + 16;
            position.Y = y + 16;
        }

        void RotatableTexture2DElement.SetRotation(float angle)
        {
            this.angle = angle;
        }

        new public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, angle, new Vector2(texture.Width/2, texture.Height/2), SpriteEffects.None, 0);
        }
    }
}
