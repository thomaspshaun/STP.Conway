using System.Collections.Generic;

namespace STP.Conway
{
  public class Prototype  // used for jotting down idea/concept
  {
    // we assume the field can be any size
    // alive = 1
    public List<List<int>> _grid;

    public Prototype(List<List<int>> grid)
    {
      _grid = grid;
    }


    // This represents ONE GENERATION
    public void ApplyRules()  
    {
      int r = -1;
      int c = -1;
      foreach (var row in _grid)
      {
        r++;  //counter for row - can be done better
        foreach (var element in row)
        {
          c++;  //counter for column - can be done better
          if (element == 1) Kill(r, c);
          else
          if (element == 0) BringToLife(r, c);
        }
        c = -1;
      }
    }

    private void BringToLife(int r, int c)
    {
      var aliveCells = GetCountOfSurroundingLiveCells(r, c);
      _grid[r][c] = aliveCells == 3 ? _grid[r][c] = 1 : _grid[r][c] = 0;
    }

    private void Kill(int r, int c)
    {
      var aliveCells = GetCountOfSurroundingLiveCells(r, c);
      _grid[r][c] = aliveCells == 3 || aliveCells == 2 ? _grid[r][c] = 1 : _grid[r][c] = 0;
    }

    //probably could use a better name
    private int GetCountOfSurroundingLiveCells(int r, int c)
    {
      int count = 0;

      if (r != 0)
      {
        if (c != 0) count = count + _grid[r - 1][c - 1];
        count = count + _grid[r - 1][c];
        if (c != _grid[0].Count - 1) count = count + _grid[r - 1][c + 1];
      }

      if (c != 0) count = count + _grid[r][c - 1];
      if (c != _grid[0].Count - 1) count = count + _grid[r][c + 1];

      if (r != _grid.Count - 1)
      {
        if (c != 0) count = count + _grid[r + 1][c - 1];
        count = count + _grid[r + 1][c];
        if (c != _grid[0].Count - 1) count = count + _grid[r + 1][c + 1];
      }
      return count;
    }
  }
}
