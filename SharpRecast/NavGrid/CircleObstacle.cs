using System;
using UnityEngine;

namespace SharpRecast.NavGrid
{
    public class CircleObstacle : IObstacle
    {
        public Vector2 Center;
        public float Radius;

        public Rect Boundary => throw new NotImplementedException();

        public bool Check(Vector2 pos)
        {
            return (pos - Center).sqrMagnitude > Radius * Radius;
        }

        public bool Check(Vector2 pos, float radius)
        {
            throw new NotImplementedException();
        }
    }
}
