using System;
using UnityEngine;

namespace SharpRecast.NavGrid
{
    public class RectObstacle : IObstacle
    {
        public Rect Boundary => throw new NotImplementedException();

        public bool Check(Vector2 pos)
        {
            throw new NotImplementedException();
        }

        public bool Check(Vector2 pos, float radius)
        {
            throw new NotImplementedException();
        }
    }
}
