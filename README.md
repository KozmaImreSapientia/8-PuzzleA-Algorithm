# 8 Puzzle Solver Algorithm


#### The input file
There's an integer (N) in the first row which means one size of the board. In the next rows are the values of tiles (0 means empty space).<br>
##### For example:
3<br>
0 1 2<br>
3 4 5<br>
6 7 8<br>
#### Console:
If the board is given from console firstly we gave the N, then the tiles. The reading of tiles starts from top left corner to right.<br>
#### Generated:
An other way to get a board is to generate randomly. This is given from the command line arguments like '-rand 3 15'. The first number means one size of the board like before and the second means the number of random moves from initial state.
##### For example:
The returned board:<br>
3 1 2<br>
6 4 0<br>
7 8 5<br>
