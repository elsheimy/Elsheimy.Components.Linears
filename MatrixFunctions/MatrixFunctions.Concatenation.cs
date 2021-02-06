using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    /// <summary>
    /// Removes specific columns from an input matrix.
    /// </summary>
    public static double[,] RemoveColumns(double[,] input, int[] colsToRemove) {
      var rowCount = input.GetLength(0);
      var colCount = input.GetLength(1);
      var newColCount = colCount - colsToRemove.Distinct().Count();

      if (newColCount <= 0)
        throw new InvalidOperationException(Properties.Resources.Exception_TooMuchColumnsRemove);

      double[,] output = new double[rowCount, newColCount];

      for (int row = 0; row < rowCount; row++) {
        int outputCol = 0;
        for (int col = 0;col < colCount;col++) {
          if (colsToRemove.Contains(col))
            continue;

          output[row, outputCol] = input[row, col];
          outputCol++;
        }
      }

      return output;
    }

    /// <summary>
    /// Removes specific rows from an input matrix.
    /// </summary>
    public static double[,] RemoveRows(double[,] input, params int[] rowsToRemove) {
      var rowCount = input.GetLength(0);
      var colCount = input.GetLength(1);
      var newRowCount = rowCount - rowsToRemove.Distinct().Count();

      if (newRowCount <= 0)
        throw new InvalidOperationException(Properties.Resources.Exception_TooMuchRowsRemove);

      double[,] output = new double[newRowCount, colCount];

      for (int col = 0; col < colCount; col++) {
        int outputRow = 0;
        for (int row = 0; row < rowCount; row++) {
          if (rowsToRemove.Contains(row))
            continue;

          output[outputRow, col] = input[row, col];
          outputRow++;
        }
      }

      return output;
    }

    /// <summary>
    /// Concats two matrices horizontally.
    /// </summary>
    public static double[,] ConcatHorizontally(double[,] matrix1, double[,] matrix2) {
      var rowCount = matrix1.GetLength(0);
      
      if (rowCount != matrix2.GetLength(0))
        throw new InvalidOperationException(Properties.Resources.Exception_RowCountMismatch);

      var matrix1Cols = matrix1.GetLength(1);
      var matrix2Cols = matrix2.GetLength(1);

      double[,] output = new double[rowCount, matrix1Cols + matrix2Cols];
      for (int row = 0; row < rowCount; row++) {
        for (int col = 0; col < matrix1Cols + matrix2Cols; col++) {
          if (col < matrix1Cols)
            output[row, col] = matrix1[row, col];
          else
            output[row, col] = matrix2[row, col - matrix1Cols];
        }
      }

      return output;
    }


    /// <summary>
    /// Concats two matrices vertically.
    /// </summary>
    public static double[,] ConcatVertically(double[,] matrix1, double[,] matrix2) {
      var columnCount = matrix1.GetLength(1);

      if (columnCount != matrix2.GetLength(1))
        throw new InvalidOperationException(Properties.Resources.Exception_ColumnCountMismatch);

      var matrix1Rows = matrix1.GetLength(0);
      var matrix2Rows = matrix2.GetLength(0);

      double[,] output = new double[matrix1Rows + matrix2Rows, columnCount];
      for (int col = 0; col < columnCount; col++) {
        for (int row = 0; row < matrix1Rows + matrix2Rows; row++) {
          if (row < matrix1Rows)
            output[row, col] = matrix1[row, col];
          else
            output[row, col] = matrix2[row - matrix1Rows,col];
        }
      }

      return output;
    }

  }

}
