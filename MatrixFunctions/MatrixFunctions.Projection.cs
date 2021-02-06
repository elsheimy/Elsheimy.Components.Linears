using System;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    // TODO: Test
    /// <summary>
    /// Creates projection matrix for the specified subspace.
    /// </summary>
    public static double[,] CreateProjectionMatrix(double[,] subspace) {
      var subspaceTranspose = MatrixFunctions.Transpose(subspace);

      double[,] value = MatrixFunctions.Multiply(subspaceTranspose, subspace);

      value = MatrixFunctions.Invert(value);

      value = MatrixFunctions.Multiply(value, subspaceTranspose);

      value = MatrixFunctions.Multiply(subspace, value);

      return value;
    }

  }
}