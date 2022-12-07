using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLife
    {

        public static bool[,] GetNextGeneration(bool[,] CurrentGeneration)
        {
            bool[,] NextGeneration = new bool[CurrentGeneration.GetLength(0), CurrentGeneration.GetLength(1)];

            for (int RowIndex = 0; RowIndex < CurrentGeneration.GetLength(0); RowIndex++)
            {
                for (int ColumnIndex = 0; ColumnIndex < CurrentGeneration.GetLength(1); ColumnIndex++)
                {
                    int NumberOfAliveNeighbouringCells = GetNumberOfAliveNeighbouringCells(CurrentGeneration, RowIndex, ColumnIndex);
                    if (CurrentGeneration[RowIndex, ColumnIndex])
                    {
                        if (NumberOfAliveNeighbouringCells == 2 || NumberOfAliveNeighbouringCells == 3)
                        {
                            NextGeneration[RowIndex, ColumnIndex] = true;
                        }
                    } 
                    else if (!CurrentGeneration[RowIndex, ColumnIndex])
                    {
                        if (NumberOfAliveNeighbouringCells == 3)
                        {
                            NextGeneration[RowIndex, ColumnIndex] = true;
                        }
                    }
                    

                }
            }
            return NextGeneration;
        }

        public static int GetNumberOfAliveNeighbouringCells(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            int NumberOfAliveNeighbouringCells = 0;

            if (CheckIfCellAboveLeftIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellAboveIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellAboveRightIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellLeftIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellRightIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellBelowLeftIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellBelowIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }
            if (CheckIfCellBelowRightIsAlive(CurrentGeneration, RowToBeChecked, ColumnToBeChecked))
            {
                NumberOfAliveNeighbouringCells++;
            }

            return NumberOfAliveNeighbouringCells;
        }

        public static bool CheckIfCellAboveLeftIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked > 0)
            {
                RowToBeChecked -= 1; 
            }
            else
            {
                RowToBeChecked = CurrentGeneration.GetLength(0) - 1;
            }
            if (ColumnToBeChecked > 0)
            {
                ColumnToBeChecked -= 1;
            }
            else
            {
                ColumnToBeChecked = CurrentGeneration.GetLength(1) - 1; 
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellAboveIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked > 0)
            {
                RowToBeChecked -= 1; 
            }
            else
            {
                RowToBeChecked = CurrentGeneration.GetLength(0) - 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellAboveRightIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked > 0)
            {
                RowToBeChecked -= 1;
            }
            else
            {
                RowToBeChecked = CurrentGeneration.GetLength(0) - 1;
            }
            if (ColumnToBeChecked == CurrentGeneration.GetLength(1) - 1)
            {
                ColumnToBeChecked = 0;
            }
            else
            {
                ColumnToBeChecked += 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellLeftIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (ColumnToBeChecked > 0)
            {
                ColumnToBeChecked -= 1;
            }
            else
            {
                ColumnToBeChecked = CurrentGeneration.GetLength(1) - 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellRightIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (ColumnToBeChecked == CurrentGeneration.GetLength(1) - 1)
            {
                ColumnToBeChecked = 0;
            }
            else
            {
                ColumnToBeChecked += 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellBelowLeftIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked == CurrentGeneration.GetLength(0) - 1)
            {
                RowToBeChecked = 0;
            }
            else
            {
                RowToBeChecked += 1;
            }
            if (ColumnToBeChecked > 0)
            {
                ColumnToBeChecked -= 1;
            }
            else
            {
                ColumnToBeChecked = CurrentGeneration.GetLength(1) - 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellBelowIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked == CurrentGeneration.GetLength(0) - 1)
            {
                RowToBeChecked = 0;
            }
            else
            {
                RowToBeChecked += 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

        public static bool CheckIfCellBelowRightIsAlive(bool[,] CurrentGeneration, int RowToBeChecked, int ColumnToBeChecked)
        {
            if (RowToBeChecked == CurrentGeneration.GetLength(0) - 1)
            {
                RowToBeChecked = 0;
            }
            else
            {
                RowToBeChecked += 1;
            }
            if (ColumnToBeChecked == CurrentGeneration.GetLength(1) - 1)
            {
                ColumnToBeChecked = 0;
            }
            else
            {
                ColumnToBeChecked += 1;
            }

            return CurrentGeneration[RowToBeChecked, ColumnToBeChecked];
        }

    }
}
