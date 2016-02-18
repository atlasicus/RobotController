using Microsoft.Xna.Framework.Graphics;

namespace RobotController.Renderer.Interface
{
    interface Texture2DAssociation
    {
        void SetAssociation(Texture2D texture, byte interactionValue);
        Texture2D GetAssociation(byte interactionValue);
    }
}
