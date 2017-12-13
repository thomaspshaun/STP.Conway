using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STP.Conway
{
  class Prototype  // used for jotting down idea/concept
  {
    List<List<int>> _field;

    public Prototype(List<List<int>> field)  // alive = 1
    {
      _field = field;
    }


    public void DoSomething()
    {
      int r = -1;
      int c = -1;
      foreach (var row in _field)
      {
        r++;  //counter for row - can be done better
        foreach (var element in row)
        {
          c++;  //counter for column - can be done better
          Kill(r, c, element);
          BringToLife(r, c, element);
        }
        c = -1;
      }
    }

    private void BringToLife(int r, int c, int element)
    {
      int aliveCells = 0;
      if (element == 0)  // if current cell is dead
      {
        aliveCells = GetCountOfSurroundingLiveCells(r, c);
        _field[r][c] = aliveCells == 3 ? _field[r][c] = 1 : _field[r][c] = 0;
      }
    }

    private void Kill(int r, int c, int element)
    {
      int aliveCells = 0;
      if (element == 1)  // if current cell is alive
      {
        aliveCells = GetCountOfSurroundingLiveCells(r, c);
        _field[r][c] = aliveCells == 3 || aliveCells == 2 ? _field[r][c] = 1 : _field[r][c] = 0;
      }
    }

    private int GetCountOfSurroundingLiveCells( int r, int c)
    {
      int count = 0; 

      if (r != 0)
      {
        if (c != 0 )                 count = count + _field[r - 1][c - 1];
                                     count = count + _field[r - 1][c];
        if (c != _field[0].Count-1 ) count = count + _field[r - 1][c + 1];
      }

      if (c != 0)                     count = count + _field[r][c - 1];
      if (c != _field[0].Count - 1)   count = count + _field[r][c + 1];

      if (r != _field.Count - 1)
      {
       if (c != 0 )                   count = count + _field[r + 1][c - 1];
                                      count = count + _field[r + 1][c];
        if (c != _field[0].Count - 1) count = count + _field[r + 1][c + 1];
      }
      return count;
    }
  }
}
