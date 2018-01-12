using System;
using System.Threading;

namespace STP.Conway
{
  public class Game
  {
    private const int Generations = 50;
    private Board _board;
    private Board _newBoard;

    public Board Board { get => _board; set => _board = value; }

    public Game(int rows, int columns)
    {
      if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
      _board = new Board(rows, columns);
      _newBoard = new Board(rows, columns);
    }

    public void ApplyRules()
    {

      int r = -1;
      int c = -1;
      foreach (var row in _board.grid)
      {
        r++;  //counter for row - can be done better
        foreach (var element in row)
        {
          c++;  //counter for column - can be done better
          if (element.IsAlive) Kill(r, c);
          else
          if (!element.IsAlive) BringToLife(r, c);
        }
        c = -1; // reset counter. 
      }
      _board = _newBoard; // Update grid
    }

    private void BringToLife(int r, int c)
    {
      var aliveCells = GetCountOfSurroundingLiveCells(r, c);
      _newBoard.grid[r][c].IsAlive = aliveCells == 3 ;
    }

    private void Kill(int r, int c)
    {
      var aliveCells = GetCountOfSurroundingLiveCells(r, c);
      _newBoard.grid[r][c].IsAlive = aliveCells == 3 || aliveCells == 2 ;
    }

    private int GetCountOfSurroundingLiveCells(int r, int c)
    {
      int count = 0;

      if (r != 0)
      {
        if (c != 0) count = count + (_board.grid[r - 1][c - 1].IsAlive ? 1 : 0);                      
        count = count + (_board.grid[r - 1][c].IsAlive ? 1 : 0);
        if (c != _board.grid[0].Count - 1) count = count + (_board.grid[r - 1][c + 1].IsAlive ? 1 : 0);
      }

      if (c != 0) count = count + (_board.grid[r][c - 1].IsAlive ? 1 : 0);
      if (c != _board.grid[0].Count - 1) count = count + (_board.grid[r][c + 1].IsAlive ? 1 : 0);

      if (r != _board.grid.Count - 1)
      {
        if (c != 0) count = count + (_board.grid[r + 1][c - 1].IsAlive ? 1 : 0);
        count = count + (_board.grid[r + 1][c].IsAlive ? 1 : 0);
        if (c != _board.grid[0].Count - 1) count = count + (_board.grid[r + 1][c + 1].IsAlive ? 1 : 0);
      }
      return count;
    }

    public void Start()
    {
      Display(); // initial State
      for (int i = 0; i < Generations; i++)
      {
        ApplyRules();
        Display();
      }
    }

    
    public void Display()
    {
      Console.Clear();

      foreach (var row in _board.grid)
      {
        foreach (var cell in row)
        {
          Console.Write(cell.ToString());
        }
        Console.WriteLine();
      }
      Thread.Sleep(500);
    }



  }
}
