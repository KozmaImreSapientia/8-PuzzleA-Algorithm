using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle
{
    class Program
    {
        private static string inputFile = "";

        private static bool printSolutionSequence = false;
        // solution sequence (List??)

        private static bool printCost = false;
        private static int cost = 0;

        private static bool printVisitedNodes = false;
        // visited nodes (List??)

        private static int heuristics = 0;

        private static bool useRandomState = false;
        private static int dimensions = 0;
        private static int numberOfMovments = 0;

        static void Main(string[] args)
        {
            //getting command line args
            if (args.Length > 0)
            {
                if (!SuccesfullyGotCommandLineArgs(args))
                {
                    return;
                }
            }

            if (useRandomState)
            {
                //generate random initial state

            }
            else
            {
                //get state from given file

            }

            if(heuristics == 1)
            {
                //A* with number of wrong positions
            }
            if(heuristics == 2)
            {
                //A* with Manhattan distance
            }
            Console.ReadKey();
        }

        private static bool SuccesfullyGotCommandLineArgs(string[] args)
        {
            bool error = false;
            for (int i = 0; i < args.Length; ++i)
            {
                if (error)
                {
                    return false;
                }
                switch (args[i])
                {
                    case "-input":  //-input <File>
                        if (i + 1 < args.Length)
                        {
                            i++;
                            if (args[i].Length > 2)
                            {
                                inputFile = args[i];
                            }
                            else
                            {
                                Console.WriteLine("Wrong file name given!");
                                error = true;
                            }
                        }
                        break;

                    case "-solseq":
                        printSolutionSequence = true;
                        break;

                    case "-pcost":
                        printCost = true;
                        break;

                    case "-nvisited":
                        printVisitedNodes = true;
                        break;

                    case "-h":  // -h <H> = type of the heuristics
                        if (i + 1 < args.Length)
                        {
                            i++;
                            switch (args[i])
                            {
                                case "1":
                                    heuristics = 1;
                                    break;
                                case "2":
                                    heuristics = 2;
                                    break;
                                default:
                                    heuristics = 0;
                                    break;
                            }
                        }
                        break;

                    case "-rand":  //–rand <N> <M>
                        useRandomState = true;
                        if (i + 2 < args.Length)
                        {
                            i++;
                            int number;
                            bool result = Int32.TryParse(args[i], out number);
                            if (result)
                            {
                                dimensions = number;
                            }
                            else
                            {
                                Console.WriteLine("Wrong parameters for generating random initial state!");
                                error = true;
                            }

                            i++;
                            result = Int32.TryParse(args[i], out number);
                            if (result)
                            {
                                numberOfMovments = number;
                            }
                            else
                            {
                                Console.WriteLine("Wrong parameters for generating random initial state!");
                                error = true;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown argument: " + args[i]);
                        break;
                }
            }

            //checking arguments to be correct
            if (heuristics == 0)
            {
                Console.WriteLine("Wrong heuristics given! Heuristics should be 1 or 2");
                return false;
            }

            return true;
        }

        private static void printData()
        {

        }

        private static int[,] ReadBoardFromFile(string fileName)
        {
            string[] lines;
            List<string> list = new List<string>();
            int n = 0;

            //reading the size of the game and the tile of game to a string
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                String line;
                int isFirst = 1;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (isFirst == 1)
                    {
                        n = int.Parse(line);
                        isFirst = 0;
                    }
                    else
                    {
                        list.Add(line);
                    }

                }
            }
            lines = list.ToArray();

            int[,] board = new int[n, n];
            String row;
            String[] split;

            //filling the board with the given values, 0 means the empty field
            for (int i = 0; i < n; i++)
            {
                row = lines[i];
                split = split = row.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < n; j++)
                {
                    board[i, j] = int.Parse(split[j]);
                }
            }

            return board;
        }

        private static void PrintBoard(int[,] board)
        {
            int n = board.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] != 0)
                    {
                        Console.Write("{0} ", board[i, j]);
                    }
                    else
                    {   //empty
                        Console.Write("_ ");
                    }
                }
                Console.WriteLine("");
            }
        }

        private static int[,] ReadBoardFromConsole()
        {
            Console.Write("Width of the game: ");
            int n = int.Parse(Console.ReadLine());

            int[,] board = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //TODO some formating...
                    Console.Write("[{0},{1}]: ", i, j);
                    board[i, j] = int.Parse(Console.ReadLine());
                }
            }

            if (!isOK(board))
            {   //TODO
                return new int[0, 0];
            }
            else
            {
                return board;
            }
        }

        //checking a filled board if it's legal
        private static bool isOK(int[,] board)
        {
            //check if the board have a legal size
            int n = board.GetLength(0);
            if (n < 1)
            {
                return false;
            }

            //creating a number statistic, first filled with zeros
            int[] numbers = new int[n * n];
            for (int i = 0; i < n; i++) { numbers[i] = 0; }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //if the number is legal in the game, ex. int a 3x3 game doesn't exist number 9 or bigger
                    if (board[i, j] >= n * n || board[i, j] < 0)
                    {
                        return false;
                    }
                    else
                    {
                        //count the presence of the numbers
                        numbers[board[i, j]]++;
                    }

                    //in a legal board the tile of 2 doesn't appear more than once
                    if (numbers[board[i, j]] > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CanMove(int i, int j, int n, int direction)
        {
            switch (direction) //0 - left, 1 - up, 2 - right, 3 - down 
            {
                case 0:
                    if (j == 0)
                    {
                        return false;
                    }
                    break;
                case 1:
                    if (i == 0)
                    {
                        return false;
                    }
                    break;
                case 2:
                    if (j == n - 1)
                    {
                        return false;
                    }
                    break;
                case 3:
                    if (i == n - 1)
                    {
                        return false;
                    }
                    break;

            }
            return true;
        }

        private static void Step(int[,] board, ref int positionI, ref int positionJ, int direction)
        {
            int N = board.GetLength(0);
            int tile;

            switch (direction) //0 - left, 1 - up, 2 - right, 3 - down 
            {
                case 0:
                    positionJ--;
                    tile = board[positionI, positionJ];

                    board[positionI, positionJ] = 0; //the empty tile
                    board[positionI, positionJ + 1] = tile;

                    break;
                case 1:
                    positionI--;
                    tile = board[positionI, positionJ];

                    board[positionI, positionJ] = 0;
                    board[positionI + 1, positionJ] = tile;

                    break;
                case 2:
                    positionJ++;
                    tile = board[positionI, positionJ];

                    board[positionI, positionJ] = 0;
                    board[positionI, positionJ - 1] = tile;
                    break;
                case 3:
                    positionI++;
                    tile = board[positionI, positionJ];

                    board[positionI, positionJ] = 0;
                    board[positionI - 1, positionJ] = tile;
                    break;

            }
        }

        private static int[,] GenerateTable(int N, int M)
        {
            int[,] board = new int[N, N];
            int temp = 0;

            //generating the solved table
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = temp;
                    temp++;
                }
            }

            //taking M random step with the empty tile
            Random rand = new Random();
            int direction;

            //the starting position of the empty tile after generating
            int positionI = 0;
            int positionJ = 0;

            while (M > 0)
            {
                do
                {
                    direction = rand.Next(4);
                } while (!CanMove(positionI, positionJ, N, direction));

                Step(board, ref positionI, ref positionJ, direction);

                M--;
            }

            return board;
        }

        private static void ValueToCoordinates(int board_size, int value, ref int out_x, ref int out_y)
        {
            out_x = value / board_size;
            out_y = value % board_size;
        }

        private static int ManhattanDistanceBetweenCoordinates(int p1_x, int p1_y, int p2_x, int p2_y)
        {
            int distX = Math.Abs(p1_x - p2_x);
            int distY = Math.Abs(p1_y - p2_y);
            return distX + distY;
        }

        private static int wrongPositions(int[,] board)
        {
            /*
            Returns 0 if the board looks like this one:
            n=3:
                    0  1  2
                    3  4  5
                    6  7  8
            */

            int wrongPositionCount = 0;
            int n = board.GetLength(0);
            int c = 0;

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (board[i, j] != c)
                    {
                        ++wrongPositionCount;
                    }
                    ++c;
                }
            }

            return wrongPositionCount;
        }

        private static int manhattanDifference(int[,] board, bool debug = false)
        {
            int totalDifference = 0;

            int n = board.GetLength(0);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int value = board[i, j];

                    // get the final coordinate for current value:

                    int finalX = -1;
                    int finalY = -1; ;
                    ValueToCoordinates(n, value, ref finalX, ref finalY);

                    if(debug) Console.Write("["+i+","+j+"] with value of "+ board[i, j] + " has to been moved to ["+ finalX + ","+ finalY + "] coordinates.");

                    // calculate mengattan distance:

                    int dist = ManhattanDistanceBetweenCoordinates(i, j, finalX, finalY);
                    
                    if(debug) Console.WriteLine(" Manhattan distance to goal: " + dist );

                    totalDifference += dist;
                }
            }

            return totalDifference;
        }
    }
}
