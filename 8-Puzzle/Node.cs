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
            cost = 0;
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

    }
}
