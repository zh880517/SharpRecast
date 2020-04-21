using System.Collections;
using UnityEngine;

namespace SharpRecast.NavGrid
{
    public class MaskGrid
    {
        public BitArray Datas;
        public int Width;
        public int Height;
        public Vector2 Start;
        public float GridSize;

        public bool Get(int x, int y)
        {
            if (y >= 0 && y < Height && x >= 0 && x < Width)
            {
                return Datas[x * Width + y];
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
