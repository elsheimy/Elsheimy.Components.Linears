using System;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    public static double[,] Create2DShearingMatrix(double factor, MatrixAxis axis) {
      if (axis == MatrixAxis.Z)
        throw new InvalidOperationException(Properties.Resources.Exception_InvalidAxis);

      var output = CreateIdentityMatrix(2);

      if (axis ==  MatrixAxis.X)
        output[0, 1] = factor;

      else if (axis == MatrixAxis.Y )
        output[1, 0] = factor;

      return output;
    }

    public static double[,] Create3DShearingMatrix(double factor, MatrixAxis axis) {
      var output = CreateIdentityMatrix(4);

      if (axis == MatrixAxis.X) { 
        output[1, 0] = factor;
        output[2, 0] = factor;
      } else if (axis == MatrixAxis.Y) {
        output[0, 1] = factor;
        output[2, 1] = factor;
      } else if (axis == MatrixAxis.Z) {
        output[0, 2] = factor;
        output[1, 2] = factor;
      }

      return output;
    }
  }
}