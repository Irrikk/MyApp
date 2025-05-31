using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MauiApp1
{
    public struct NodePositionChangedArgs
    {
        public readonly Node node;
        public readonly Vector2 oldPosition;
        public readonly Vector2 newPosition;

        public NodePositionChangedArgs(Node node, Vector2 oldPosition, Vector2 newPosition)
        {
            this.node = node;
            this.oldPosition = oldPosition;
            this.newPosition = newPosition;
        }
    }
}
