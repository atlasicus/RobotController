using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RobotController.Renderer.Interface
{
    interface Texture2DElement
    {
        Texture2D GetTexture2D();

        Rectangle getPosition();
        void setPosition(int x, int y);
        void setPosition(Rectangle position);

        void draw(SpriteBatch spriteBatch);
    }
}
