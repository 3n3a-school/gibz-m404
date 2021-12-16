using System;
using System.Diagnostics;

namespace Minesweeper
{
  public class Board
  {
    private readonly int _colCount;
    private readonly int _rowCount;
    private readonly int _mineCount;

    public Field[,] Fields { get; set; }

    public Board(int cols = 8, int rows = 8, int mines = 10, UI ui)
    {
      _colCount = cols;
      _rowCount = rows;
      _mineCount = mines;

      CreateFields(ui);
      //SeedMines();
    }

    private int[] RandomCoords(int min, int max_x, int max_y)
    {
      int[] coords = new int[2];
      Random rand = new Random();
      coords[0] = rand.Next(0, _colCount);
      coords[1] = rand.Next(0, _rowCount);

      return coords;
    }

    private void SeedMines()
    {
      int minesPlaced = 0;
      do
      {
        // Place mine at random coords
        int[] coords = RandomCoords(0, _colCount, _rowCount);

        // if already a mine, don't incremenet minesPlaced
        
        if (!Fields[coords[0], coords[1]].IsMine)
        {
          Fields[coords[0], coords[1]].IsMine = true;
          minesPlaced++;
        }
      } while (minesPlaced == _mineCount);
    }

    private void CreateFields(UI ui)
    {
      for (int i = 0; i < _colCount; i++)
      {
        for (int j = 0; j < _rowCount; j++)
        {
          Fields = new Field[j, i];
          ui.DrawField();
        }
      }
    }

  }

  public class Field
  {
    public bool IsMine { get; set; } = false;
    public bool IsUncovered { get; private set; } = false;

    public int SurroundingMineCount { get; set; } = 0;
    public bool IsSuspectedMine { get; private set; } = false;

    public Field() { }

    public void Uncover()
    {
      IsUncovered = true;
    }
  }
}
