using System;
using System.Collections.Generic;
using System.Threading;

namespace STP.Conway
{
  public class Program
  {
    static void Main(string[] args)
    {
      Game game = new Game(10, 10);

        //     0 1 2 3 4 5 6 7 8 9 
        // 0 | 0 0 0 0 0 0 0 0 0 0 
        // 1 | 0 0 0 0 0 0 0 0 0 0 
        // 2 | 0 0 0 0 0 1 0 0 0 0 
        // 3 | 0 0 0 0 0 1 1 0 0 0 
        // 4 | 0 0 1 1 1 1 1 1 0 0 
        // 5 | 0 0 0 0 0 1 1 0 0 0 
        // 6 | 0 0 0 0 0 1 0 0 0 0 
        // 7 | 0 0 0 0 0 0 0 0 0 0 
        // 8 | 0 0 0 0 0 0 0 0 0 0 
        // 9 | 0 0 0 0 0 0 0 0 0 0 

      game.Board.grid[4][2] = new Cell(true); 
      game.Board.grid[4][3] = new Cell(true); 
      game.Board.grid[5][4] = new Cell(true); 
      game.Board.grid[5][5] = new Cell(true);
      game.Board.grid[4][6] = new Cell(true);
      game.Board.grid[4][7] = new Cell(true);
      game.Board.grid[3][5] = new Cell(true);
      game.Board.grid[3][6] = new Cell(true);
      game.Board.grid[2][5] = new Cell(true);
      game.Board.grid[5][5] = new Cell(true);
      game.Board.grid[5][6] = new Cell(true);
      game.Board.grid[6][5] = new Cell(true);

      game.Start(); 

      Console.ReadKey();
    }

    

  }
}
