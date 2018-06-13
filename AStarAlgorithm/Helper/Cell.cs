using System.Collections.Generic;

namespace AStarAlgorithm
{
    /// <summary>
    /// The represents the graph cells
    /// </summary>
    public class Cell
    {
        public double HValue { get; set; }
        public double FValue => this.GValue + this.HValue;
        public double GValue { get; set; }
        public Cell CameFrom { get; set; }
        public Cell NorthNeighbour { get; set; }
        public Cell SouthNeighbour { get; set; }
        public Cell WestNeighbour { get; set; }
        public Cell EastNeighbour { get; set; }

        public Cell LeftLowerNeighbour { get; set; }
        public Cell LeftUpperNeighbour { get; set; }
        public Cell RightLowerNeighbour { get; set; }
        public Cell RightUpperNeighbour { get; set; }

        public int X { get; set; }

        public int Y { get; set; }


        public Cell FindCell(int x, int y, List<Cell> map)
        {
            foreach (Cell t in map)
            {
                if (t.X == x && t.Y == y)
                    return t;
            }
            return null;
        }

    }
}
