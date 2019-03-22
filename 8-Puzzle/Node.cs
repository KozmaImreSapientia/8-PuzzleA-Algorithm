using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Puzzle
{
    class Node
    {
        private int[,] board;
        private Node parent;
        private int cost;

        public Node(int[,] board)
        {
            this.board = board;
            parent = null;
            cost = int.MaxValue;
        }

        public Node(int[,] board, Node parent, int cost)
        {
            this.board = board;
            this.parent = parent;
            this.cost = cost;
        }

        public int[,] Board
        {
            get { return this.board; }
            set { this.board = value; }
        }

        public Node Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public int Cost
        {
            get { return this.cost; }
            set { this.cost = value; }
        }

        public override bool Equals(object obj)
        {
            Node nd = (obj as Node);
            if (nd!=null) {
                return AreSameNodes(this.Board, nd.Board);
            }
            return false;
        }

        public static bool AreSameNodes(int[,] board_1, int[,] board_2)
        {
            int n = board_1.GetLength(0);
            int m = board_1.GetLength(1);

            if (n != board_2.GetLength(0) || m != board_2.GetLength(1))
            {
                Console.WriteLine("Can't compare boards with different size!");
                return false;
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (board_1[i, j] != board_2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
