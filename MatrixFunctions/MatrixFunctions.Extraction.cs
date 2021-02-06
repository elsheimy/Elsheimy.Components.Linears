using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    /// <summary>
    /// Extracts specific columns from a matrix.
    /// </summary>
    public static double[,] ExtractColumns(double[,] input, int startCol, int endCol) {
      return ExtractColumns(input, Enumerable.Range(startCol, endCol - startCol + 1).ToArray());
    }

    public static double[,] ExtractColumns(double[,] input, int[] cols) {
      cols = cols.Distinct().ToArray();
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);
      double[,] output = new double[rowCount, cols.Length];

      for (int row = 0; row < rowCount; row++) {
        int i = 0;
        for (int col = 0; col < colCount; col++) {
          if (cols.Contains(col) == false)
            continue;
          output[row, i] = input[row, col];
          i++;
        }
      }
      return output;
    }


    /// <summary>
    /// Extracts specific rows from a matrix.
    /// </summary>
    public static double[,] ExtractRows(double[,] input, int startRow, int endRow) {
      int colCount = input.GetLength(1);
      double[,] output = new double[endRow - startRow + 1, colCount];

      for (int col = 0; col < colCount; col++) {
        for (int row = startRow, i = 0; row <= endRow; row++, i++)
          output[i, col] = input[row, col];
      }
      return output;
    }

    public static double[,] ExtractRows(double[,] input, int[] rows) {
      rows = rows.Distinct().ToArray();
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);
      double[,] output = new double[rows.Length, colCount];

      for (int col = 0; col < colCount; col++) {
        int i = 0;
        for (int row = 0; row < rowCount; row++) {
          if (rows.Contains(row) == false)
            continue;
          output[i, col] = input[row, col];
          i++;
        }
      }
      return output;
    }


    public static double[][] GetColumnVectors(double[,] input) {
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);


      double[][] columnVectors = new double[colCount][];

      for (int i = 0; i < colCount; i++) {
        columnVectors[i] = new double[rowCount];

        for (int row = 0; row < rowCount; row++)
          columnVectors[i][row] = input[row, i];

      }

      return columnVectors;
    }


    public static double[][] GetRowVectors(double[,] input) {
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);


      double[][] rowVectors = new double[rowCount][];

      for (int i = 0; i < rowCount; i++) {
        rowVectors[i] = new double[colCount];

        for (int col = 0; col < colCount; col++)
          rowVectors[i][col] = input[i, col];

      }

      return rowVectors;
    }
  }
}