# 8 Puzzle Solver Algorithm

#### Command Line Arguments
The program can be executed from the command line using the following arguments:
  - `-input <FILE>`
  - `-solseq`
  - `-pcost`
  - `-nvisited`
  - `-h <H>`
  - `-rand <N> <M>`
  
#### The input file  `-input <FILE>`
There's an integer (N) in the first row which means one size of the board. In the next rows are the values of tiles (0 means empty space).<br>
##### For example:
3<br>
0 1 2<br>
3 4 5<br>
6 7 8<br>

#### Console:
If the board is given from console firstly we gave the N, then the tiles. The reading of tiles starts from top left corner to right.<br>

#### Generating a random board: `-rand <N> <M>`
An other way to get a board is to generate randomly. This is given from the command line arguments like `-rand 3 15`. The first number means one size of the board like before and the second means the number of random moves from initial state.
##### For example:
The returned board:<br>
3 1 2<br>
6 4 0<br>
7 8 5<br>

############Test rezults#####################

H1 = Heuristic for WrongPositionsCount
H2 = Heuristic for ManhattanDistance
                                ##3x3##
H1:                                           H2: 
  Cost: 67 Visited Nodes: 3007                  Cost: 37 Visited Nodes: 95
  Cost: 8 Visited Nodes: 10                     Cost: 8 Visited Nodes: 9
  Cost: 34 Visited Nodes: 362                   Cost: 40 Visited Nodes: 505
  Cost: 14 Visited Nodes: 41                    Cost: 14 Visited Nodes: 20
  Cost: 14 Visited Nodes: 42                    Cost: 10 Visited Nodes: 11
                                ##4x4##
H1:                                           H2: 
  Cost: 130 Visited Nodes: 3374                  Cost: 50 Visited Nodes: 259
  Cost: 22 Visited Nodes: 205                    Cost: 22 Visited Nodes: 54
  Cost: 62 Visited Nodes: 844                   Cost: 36 Visited Nodes: 887
                                ##5x5##
H1:                                           H2: 
  Cost: 164 Visited Nodes: 6795                  Cost: 128 Visited Nodes: 5261
  Cost: 97 Visited Nodes: 2189                   Cost: 87 Visited Nodes: 3186
  Cost: 160 Visited Nodes: 15010                 Cost: 126 Visited Nodes: 3013
