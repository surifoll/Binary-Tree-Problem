using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AStarAlgorithm
{
    public partial class Form1 : Form
    {
        Cell _goal = new Cell();
        Cell _start = new Cell();
        List<Cell> _map;
        List<Cell> _path;
        private bool _shouldPlaceWall = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            dgvMap.RowCount = 21;
            dgvMap.ColumnCount = 27;
            _map = new List<Cell>();

        }

        public void CoverOverPath(List<Cell> resultPath)
        {
            int x, y = 0;

            resultPath.Remove(resultPath.First());
            resultPath.Remove(resultPath.Last());

            foreach (var cell in resultPath)
            {
                x = cell.X;
                y = cell.Y;
                dgvMap.Rows[x].Cells[y].Value = "●";
            }

        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            int colorChecker = 0;
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.Green)
                    {
                        colorChecker += 1;
                    }
                }
            }
            if (colorChecker == 0)
            {
                dgvMap.CurrentCell.Style.BackColor = Color.Green;
                _start = new Cell();
                _start.X = dgvMap.CurrentCell.RowIndex;
                _start.Y = dgvMap.CurrentCell.ColumnIndex;

            }
            else
                MessageBox.Show("The START point is already exist!");

        }

        private void btnSetFinish_Click(object sender, EventArgs e)
        {
            int colorChecker = 0;
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.DarkBlue)
                    {
                        colorChecker += 1;
                    }
                }
            }
            if (colorChecker == 0)
            {
                dgvMap.CurrentCell.Style.BackColor = Color.DarkBlue;
                _goal = new Cell();
                _goal.X = dgvMap.CurrentCell.RowIndex;
                _goal.Y = dgvMap.CurrentCell.ColumnIndex;
            }
            else
                MessageBox.Show("The START point is already exist!");

        }

        private void btnClearMap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    dgvMap.Rows[i].Cells[j].Style.BackColor = Color.White;
                    dgvMap.Rows[i].Cells[j].Value = "";

                }
            }
        }

        private void btnSetWall_Click(object sender, EventArgs e)
        {
            //dgvMap.CurrentCell.Style.BackColor = Color.DarkRed;
            _shouldPlaceWall = true;

        }



        private void btnPathFinding_Click(object sender, EventArgs e)
        {
            Algorithm(_start, _goal);
            CoverOverPath(_path);

        }



        public List<Cell> GetMap()
        {
            List<Cell> map = new List<Cell>();
            for (int i = 0; i < dgvMap.RowCount; i++)
            {
                for (int j = 0; j < dgvMap.ColumnCount; j++)
                {
                    Cell cell = new Cell();
                    cell.X = dgvMap.Rows[i].Cells[j].RowIndex;
                    cell.Y = dgvMap.Rows[i].Cells[j].ColumnIndex;


                    if (dgvMap.Rows[i].Cells[j].Style.BackColor == Color.DarkRed)
                    {
                        cell.GValue = 1999;
                    }

                    map.Add(cell);
                }
            }
            return map;
        }

        public List<Cell> Algorithm(Cell start, Cell goal)
        {
            List<Cell> map = new List<Cell>();
            map = GetMap();

            Cell currentCell = new Cell();
            Cell openCell = new Cell();

            List<Cell> closedList = new List<Cell>();
            List<Cell> openList = new List<Cell>();


           
            start.CameFrom = null;
            start.GValue = 0;
            start.HValue = GetHeuristicValue(start, goal);


            openList.Add(start);
            while (openList.Count > 0)
            {

                currentCell = openList.OrderBy(cell => cell.FValue).First();

                if (currentCell.X == goal.X && currentCell.Y == goal.Y)
                {
                    return _path = GetFullPath(currentCell);

                }

                openList.Remove(currentCell);
                closedList.Add(currentCell);

                foreach (var neighbourCell in GetNeighboursList(currentCell, map))
                {

                    if (closedList.Exists(cell => cell.X == neighbourCell.X && cell.Y == neighbourCell.Y))
                        continue;
                    openCell = openList.FirstOrDefault(cell => cell.X == neighbourCell.X && cell.Y == neighbourCell.Y);

                    if (openCell == null)
                    {
                        openList.Add(neighbourCell);
                    }
                    else
                        if (openCell.GValue < neighbourCell.GValue)
                        {

                            openCell.CameFrom = currentCell;
                            openCell.GValue = neighbourCell.GValue;
                        }
                }
            }

            return null;

        }
        public int GetHeuristicValue(Cell currentCell, Cell goal)
        {
            int heuristicValue = 0;
            if (currentCell.GValue == 1999)
            {
                return heuristicValue = 100;
            }
            else
                return heuristicValue = Math.Abs(currentCell.X - goal.X) + Math.Abs(currentCell.Y - goal.Y);
        }


        public double GetDistanceBetweenCells(Cell currentCell, Cell neighbour)
        {
            double distance = 0.0;
            double calculatedX = Math.Pow((currentCell.X - neighbour.X), 2);
            double calculatedY = Math.Pow((currentCell.Y - neighbour.Y), 2);
            return distance = Math.Sqrt(calculatedX + calculatedY);
        }

        public static List<Cell> GetFullPath(Cell goal)
        {
            List<Cell> fullPath = new List<Cell>();
            Cell currentCell = goal;
            while (currentCell != null)
            {
                fullPath.Add(currentCell);
                currentCell = currentCell.CameFrom;
            }
            fullPath.Reverse();
            return fullPath;
        }





        public List<Cell> GetNeighboursList(Cell currentCell, List<Cell> mapCells)
        {
            List<Cell> neighbours = new List<Cell>();
            List<Cell> resultNeighbours = new List<Cell>();
            Cell cell = new Cell();

            if (currentCell.NorthNeighbour == null) cell = currentCell.FindCell(currentCell.X, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.SouthNeighbour == null) cell = currentCell.FindCell(currentCell.X, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.WestNeighbour == null) cell = currentCell.FindCell(currentCell.X - 1, currentCell.Y, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.EastNeighbour == null) cell = currentCell.FindCell(currentCell.X + 1, currentCell.Y, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }

            if (currentCell.LeftLowerNeighbour == null) cell = currentCell.LeftLowerNeighbour = currentCell.FindCell(currentCell.X - 1, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.LeftUpperNeighbour == null) cell = currentCell.LeftUpperNeighbour = currentCell.FindCell(currentCell.X - 1, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.RightLowerNeighbour == null) cell = currentCell.RightLowerNeighbour = currentCell.FindCell(currentCell.X + 1, currentCell.Y - 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }


            if (currentCell.RightUpperNeighbour == null) cell = currentCell.RightUpperNeighbour = currentCell.FindCell(currentCell.X + 1, currentCell.Y + 1, mapCells);
            if (cell != null)
            {

                neighbours.Add(cell);
            }



            foreach (var neighbour in neighbours)
            {


                Cell neighbourNode = new Cell();

                neighbourNode.X = neighbour.X;
                neighbourNode.Y = neighbour.Y;
                neighbourNode.CameFrom = currentCell;
                neighbourNode.GValue = currentCell.GValue + GetDistanceBetweenCells(currentCell, neighbour);
                neighbourNode.HValue = GetHeuristicValue(neighbour, _goal);

                resultNeighbours.Add(neighbourNode);
            }

            return resultNeighbours;
        }

        private void dgvMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_shouldPlaceWall)
                    dgvMap.CurrentCell.Style.BackColor = Color.DarkRed;

            }
            else
            {
                _shouldPlaceWall = false;
            }
        }


    }
}

