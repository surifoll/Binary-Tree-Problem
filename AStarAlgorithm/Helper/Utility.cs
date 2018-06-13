using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AStarAlgorithm
{
    public class Utility
    {
        /// <summary>
        /// Function interprets the map
        /// </summary>
        /// <param name="dgvMap"></param>
        /// <returns></returns>
        public List<Cell> GetMap(System.Windows.Forms.DataGridView dgvMap)
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
        /// <summary>
        /// A* Algorithm implemented here 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="goal"></param>
        /// <param name="dgvMap"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Cell>  Algorithm(Cell start, Cell goal, System.Windows.Forms.DataGridView dgvMap, List<Cell> path)
        {
            List<Cell> map = new List<Cell>();
            map = GetMap(dgvMap);

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
                    return path = GetFullPath(currentCell);

                }

                openList.Remove(currentCell);
                closedList.Add(currentCell);

                foreach (var neighbourCell in GetNeighboursList(currentCell, map, goal))
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
        /// <summary>
        /// Function calculates Heuristic value
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="goal"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Function distance between nodes
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="neighbour"></param>
        /// <returns></returns>
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



        /// <summary>
        /// Function get all neighbours of the node
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="mapCells"></param>
        /// <param name="goal"></param>
        /// <returns></returns>

        public List<Cell> GetNeighboursList(Cell currentCell, List<Cell> mapCells, Cell goal)
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
                neighbourNode.HValue = GetHeuristicValue(neighbour, goal);

                resultNeighbours.Add(neighbourNode);
            }

            return resultNeighbours;
        }

      

    }
}
