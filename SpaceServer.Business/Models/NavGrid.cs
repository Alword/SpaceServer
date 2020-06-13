using SpaceServer.Mathematic;
using System;

namespace SpaceServer.Network.Models
{
    public class NavGrid<T>
    {
        public float Size { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        private T[,] Grid { get; set; }
        public NavGrid(int with, int height, float size = 1f, Func<NavGrid<T>, int, int, T> initCell = null)
        {
            this.Width = with;
            this.Height = height;
            this.Grid = new T[with, height];
            this.Size = size;

            if (initCell != null)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        Grid[x, y] = initCell.Invoke(this, x, y);
                    }
                }
            }
        }

        public T this[int x, int y]
        {
            get
            {
                return Grid[x, y];
            }
            set
            {
                Grid[x, y] = value;
            }
        }

        public T this[Int2 pos]
        {
            get => this[pos.X, pos.Y];
            set => this[pos.X, pos.Y] = value;
        }
    }
}
