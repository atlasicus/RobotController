using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RobotControllerTest.Utils
{
    //Implemneted globally due to time constraints
    static class TeleportList
    {
        private static Dictionary<Point, Point> teleportList = new Dictionary<Point, Point>();

        public static Point GetTeleportLocation(int x, int y)
        {
            Point location;
            teleportList.TryGetValue(new Point(x, y), out location);

            return location;
        }

        public static void SetTeleportLocation(int startX, int startY, int endX, int endY)
        {
            Point startPoint = new Point(startX, startY);
            Point endPoint = new Point(endX, endY);

            teleportList.Add(startPoint, endPoint);
        }
    }
}
