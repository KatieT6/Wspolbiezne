using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public class Board 
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

       
        
    }
}
