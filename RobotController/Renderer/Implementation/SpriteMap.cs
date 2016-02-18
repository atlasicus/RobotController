using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace RobotController.Renderer.Implementation
{
    class SpriteMap : Interface.Texture2DAssociation
    {
        Dictionary<byte, Texture2D> associationMap;

        public SpriteMap()
        {
            associationMap = new Dictionary<byte, Texture2D>();
        }

        public Texture2D GetAssociation(byte interactionValue)
        {
            return associationMap[interactionValue];
        }

        public void SetAssociation(Texture2D texture, byte interactionValue)
        {
            associationMap[interactionValue] = texture;
        }
    }
}
