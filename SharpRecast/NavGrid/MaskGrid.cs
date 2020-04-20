using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SharpRecast.NavGrid
{
    public class MaskGrid
    {
        public List<BitArray> Rows;
        public Vector2 Start;
        public float GridSize;

        public bool Get(int x, int y)
        {
            if (y >= 0 && y < Rows.Count)
            {
                var array = Rows[y];
                if (x >=0 && x<array.Count)
                {
                    return array[x];
                }
            }
            return false;
        }

        public Vector2Int GetPos(Vector2 point)
        {
            Vector2 fPos = (point - Start) / GridSize;
            return new Vector2Int(Mathf.FloorToInt(fPos.x), Mathf.FloorToInt(fPos.y));
        }

        public int LenToStep(float len)
        {
            return Mathf.CeilToInt(len / GridSize);
        }

        public bool Check(int x, int y, int radius)
        {
            int sqrRadius = radius * radius;
            for (int i=-radius; i<radius; ++i)
            {
                for (int j=-radius; j<radius; ++j)
                {
                    int sqrLen = i * i + j * j;
                    if (sqrLen <= sqrRadius)
                    {
                        if (!Get(i+x, j+y))
                            return false;
                    }
                }
            }
            return true;
        }

    }
}
