

namespace GameOfLife
{

    public class Program
    {

        public static void Main(string[] args)
        {

            bool[,] NextGeneration = new bool[16,32];

            NextGeneration[3, 4] = true;
            NextGeneration[3, 6] = true;
            NextGeneration[4, 5] = true;
            NextGeneration[4, 6] = true;
            NextGeneration[5, 5] = true;

            while (true)
            {

                NextGeneration = GameOfLife.GetNextGeneration(NextGeneration);
                PrintGeneration(GameOfLife.GetNextGeneration(NextGeneration));
                Thread.Sleep(100);
            }


        }

        public static void PrintGeneration(bool[,] CurrentGeneration)
        {
            System.Console.Clear();
            for (int RowIndex = 0; RowIndex < CurrentGeneration.GetLength(0); RowIndex++)
            {
                string PrintLine = "";
                for (int ColumnIndex = 0; ColumnIndex < CurrentGeneration.GetLength(1); ColumnIndex++)
                {
                    if (CurrentGeneration[RowIndex, ColumnIndex])
                    {
                        PrintLine += "*";
                    }
                    else
                    {
                        PrintLine += ".";
                    }
                }
                Console.WriteLine(PrintLine);
            }
        }

    }

}