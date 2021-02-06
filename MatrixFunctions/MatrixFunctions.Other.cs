using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    
    /// <summary>
    /// Returns true if the two matrices are the same.
    /// </summary>
    public static bool Equals(double[,] matrix1, double[,] matrix2) {
      int rowCount = matrix1.GetLength(0);
      int colCount = matrix1.GetLength(1);

      if ((rowCount != matrix2.GetLength(0)) || (colCount != matrix2.GetLength(1)))
        return false;

      for (int row = 0; row < rowCount; row++) {
        for (int col = 0; col < colCount; col++) {
          if (matrix1[row, col] != matrix2[row, col])
            return false;
        }
      }

      return true;
    }

    public static double[,] CreateCopy(double[,] input) {
      var rowCount = input.GetLength(0);
      var colCount = input.GetLength(1);

      double[,] output = new double[rowCount,colCount ];
      
      for (int row = 0; row < rowCount ; row++) {
        for (int col = 0; col < colCount; col++) {
          output[row, col] = input[row, col];
        }
      }

      return output;
    }
    public static double[,] CreateCopyUnsafe(double[,] input) {
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);
      int length = rowCount * colCount;

      double[,] output = new double[rowCount, colCount];

      unsafe
      {
        fixed (double* pInput = input, pOutput = output) {
          for (int i = 0;i  < length;i++) {
            pOutput[i] = pInput[i];
          }
        }
      }

      return output;
    }

   

    /// <summary>
    /// Returns the sum of a specific row.
    /// </summary>
    public static double RowSum(double[,] input, int row) {
      return RowSum(input, row, 0, input.GetLength(0));
    }
    /// <summary>
    /// Returns the sum of a column range in a specific row.
    /// </summary>
    public static double RowSum(double[,] input, int row, int startCol, int endCol) {
      double total = 0;
      for (int col = startCol; col <= endCol; col++) {
        total += input[row, col];
      }

      return total;
    }

    /// <summary>
    /// Generates random matrix.
    /// </summary>
    public static double[,] GenerateRandomMatrix(int numRows, int numCols, double maxValue = 1) {
      Random rand = new Random();
      double[,] output = new double[numRows, numCols];
      
      for (int row = 0; row < numRows; row++) {
        for (int col = 0; col < numCols; col++) {
          output[row, col] = rand.NextDouble() * maxValue;
        }
      }

      return output;
    }

    /// <summary>
    /// Returns matrix transpose.
    /// </summary>
    public static double[,] Transpose(double[,] input) {
      double[,] output = new double[input.GetLength(1), input.GetLength(0)];

      for (int row = 0; row < input.GetLength(0); row++) {
        for (int col = 0; col < input.GetLength(1); col++) {
          output[col, row] = input[row, col];
        }
      }

      return output;
    }

    /// <summary>
    /// Rounds matrix entries to the nearst integral values.
    /// </summary>
    public static double[,] Round(double[,] input, int decimals) {
      var rowCount = input.GetLength(0);
      var colCount = input.GetLength(1);

      // creating the final product matrix
      double[,] output = new double[rowCount, colCount];

      for (int row = 0; row < rowCount; row++) {
        for (int col = 0; col < colCount; col++) {
          output[row, col] = Math.Round(output[row, col]);
        }
      }

      return output;
    }



    /// <summary>
    /// Creates identity matrix of a specific length.
    /// </summary>
    public static double[,] CreateIdentityMatrix(int length) {
      double[,] matrix = new double[length, length];

      for (int i = 0, j = 0; i < length; i++, j++)
        matrix[i, j] = 1;

      return matrix;
    }
  }

}
