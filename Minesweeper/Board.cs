using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minesweeper
{
  public class Board
  {
    public readonly int _colCount;
    public readonly int _rowCount;
    private readonly int _mineCount;

    public Field[,] Fields { get; set; }

    public Board(int cols = 8, int rows = 8, int mines = 10)
    {
      _colCount = cols;
      _rowCount = rows;
      _mineCount = mines;

      Fields = new Field[_colCount, _rowCount];

      CreateFields();
      SeedMines();
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
        
        if (Fields[coords[0], coords[1]].IsMine == false)
        {
          Fields[coords[0], coords[1]].IsMine = true;
          minesPlaced++;
          IncrementNeighboursMineCount(coords[0], coords[1]);
        }
      } while (minesPlaced < _mineCount);
    }

    private void CreateFields()
    {
      for (int i = 0; i < _colCount; i++)
      {
        for (int j = 0; j < _rowCount; j++)
        {
          // Fields[x, y]
          Fields[i, j] = new Field
          {
            x = i,
            y = j,
          };
        }
      }
    }

    private void IncrementNeighboursMineCount(int x, int y)
    {
      List<Field> adjFields = GetAdjoiningFields(x, y);
      foreach (Field field in adjFields)
      {
        field.SurroundingMineCount++;
      }
    }

    private List<Field> GetAdjoiningFields(int x, int y)
    {
      List<Field> adjFields = new List<Field>();

      for (int col = x -1; col <= x + 1; col++)
      {
        for (int row = y -1; row <= y +1; row++)
        {
          if (col >= 0 && row >= 0 && col < _colCount && row < _rowCount)
          {
            adjFields.Add(Fields[x, y]);
          }
        }
      }
      return adjFields;
    }

  }

  public class Field
  {
    // x = col; y = row
    public int x { get; set; }
    public int y { get; set; }
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
