using System.Collections.ObjectModel;
using System.Numerics;

namespace Data
{
    public class Board 
    {
        public static int _boardWidth = 750;
        public static int _boardHeight = 400;

        public Board()
        {
           
        }

        public int BoardHeight
        {
            get => _boardHeight;
        }
        public int BoardWidth
        {
            get => _boardWidth;
        }
        
    }
}
