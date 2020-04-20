using System.Collections.Generic;
using UnityEngine;

namespace SharpRecast.NavGrid
{
    public class HeightFieldGrid
    {
        public List<byte[]> Rows;
        public Vector2 Start;
        public float GridSize;
        public byte Get(int x, int y)
        {
            if (y >= 0 && y < Rows.Count)
            {
                var array = Rows[y];
                if (x >= 0 && x < array.Length)
                {
                    return array[x];
                }
            }
            return 0xFF;
        }

        public Vector2Int GetPos(Vector2 point)
        {
            Vector2 fPos = (point - Start) / GridSize;
            return new Vector2Int(Mathf.FloorToInt(fPos.x), Mathf.FloorToInt(fPos.y));
        }
        public int LenToStep(float len)
        {
            return Mathf.FloorToInt(len / GridSize);
        }

    }
}
