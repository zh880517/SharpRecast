using UnityEngine;

namespace SharpRecast.NavGrid
{
    public interface IObstacle
    {
        Rect Boundary { get; }
        bool Check(Vector2 pos);
        bool Check(Vector2 pos, float radius);
    }
}
