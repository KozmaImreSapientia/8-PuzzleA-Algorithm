using System;
using System.Collections.Generic;
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
                //AStarSolve();
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

        private static bool AStarSolve(int[,] board)
        {
            //Initialize OPEN list
            List<int> openList = new List<int>();

            //Initialize CLOSED list
            List<int> closedList = new List<int>();

            //Create goal node
            int goalNode = 0; //= ;

            //Create start node
            int startNode = 0; //= ;

            //Add startNode to the OPEN list
            openList.Add(startNode);

            while (openList.Count > 0) {
                //Get node n off the OPEN list with the lowest f(n)

                //Add n to the CLOSED list
                //if n is the same as node_goal then return Solution(n)
                //Generate each successor node n' of n
                //for each successor node n' of n {
                    //Set the parent of n' to n
                    //Set h(n') to be the heuristically estimate distance to node_goal
                    //Set g(n') to be g(n) plus the cost to get to n' from n
                    //Set f(n') = g(n') + h(n')
                    //if n' is on the OPEN list and the existing one is as good or better then discard n' and continue
                    //if n' is on the CLOSED list and the existing one is as good or better then discard n' and continue
                    //Remove occurrences of n' from OPEN and CLOSED
                    //Add n' to the OPEN list
                //}
            }
            return false;

    }
}
}
