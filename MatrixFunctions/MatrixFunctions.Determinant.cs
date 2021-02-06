using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    /// <summary>
    /// Calculates determinant. Internally uses Laplace Expansion method.
    /// </summary>
    /// <remarks>
    /// Returns 1 for an empty matrix. See https://math.stackexchange.com/questions/1762537/what-is-the-determinant-of/1762542
    /// </remarks>
    public static double Determinant(double[,] input) {
      var results = CrossProduct(input);

      return results.Sum();
    }

    public static double[] CrossProduct(double[,] input) {
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);

      if (rowCount != colCount)
        throw new InvalidOperationException(Properties.Resources.Exception_RequiredSquareMatrix);

      if (rowCount == 0)
        return new double[] { 1 };

      if (rowCount == 1)
        return  new double[] { input[0, 0] };

      if (rowCount == 2)
        return new double[] { (input[0, 0] * input[1, 1]) - (input[0, 1] * input[1, 0]) };

      double[] results = new double[colCount];

      for (int col = 0; col < colCount; col++) {
        // checkerboard pattern, even col  = 1, odd col = -1
        var checkerboardFactor = col % 2.0 == 0 ? 1 : -1;
        var coeffecient = input[0, col];

        var crossMatrix = GetCrossMatrix(input, 0, col);
        results[col] =  checkerboardFactor * (coeffecient * Determinant(crossMatrix));
      }

      return results;
    }

    /// <summary>
    /// Retrieves all matrix entries except the specified row and col. Used in cross product and determinant functions.
    /// </summary>
    public static double[,] GetCrossMatrix(double[,] input, int skipRow, int skipCol) {
      int rowCount = input.GetLength(0);
      int colCount = input.GetLength(1);

      var output = new double[rowCount - 1, colCount - 1];
      int outputRow = 0;

      for (int row = 0; row < rowCount;row++) {
        if (row == skipRow)
          continue;

        int outputCol = 0;

        for (int col = 0; col < colCount;col++) {
          if (col == skipCol)
            continue;

          output[outputRow, outputCol] = input[row, col];

          outputCol++; 
        }
        outputRow++;
      }

      return output;
    }
  }

}
