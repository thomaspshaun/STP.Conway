using System;
using System.Collections.Generic;

namespace STP.Conway
{
  public class Board
  {
    public List<List<Cell>> grid;
    public Board(int rows, int columns)
    {
      Setup(rows, columns);
    }

    private void Setup(int rows, int columns)
    {
      if (rows <= 0 || columns <= 0) throw new ArgumentOutOfRangeException("Row and Column size must be greater than zero");
      grid = new List<List<Cell>>();
      for (int i = 0; i < rows; i++)
      {
        List<Cell> Row = new List<Cell>(); 
        for (int j = 0; j < columns; j++)
        {
          Cell cell = new Cell(false);
          Row.Add(cell); 
        }
        grid.Add(Row); 
      }
    }
  }
}
