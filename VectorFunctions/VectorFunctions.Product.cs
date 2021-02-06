using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {
    public static double DotProduct(double[] vector1, double[] vector2) {
      if (vector1.Length != vector2.Length)
        throw new InvalidOperationException(Properties.Resources.Exception_DimensionsMismatch);

      double product = 0;
      for (int i = 0; i < vector1.Length; i++)
        product += vector1[i] * vector2[i];

      return product;
    }

    public static double[] Scale(double scalar, double[] vector) {
      double[] product = new double[vector.Length];

      for (int i = 0; i < vector.Length; i++) {
        product[i] = scalar * vector[i];
      }

      return product;
    }


    public static double[] CrossProduct(double[] vector1, double[] vector2) {
      int length = 3;

      if (length != vector1.Length || length != vector2.Length)
        throw new InvalidOperationException(Properties.Resources.Exception_3DRequired);

      double[,] matrix = new double[length, length];
      for (int row = 0; row < length; row++) {
        for (int col = 0; col < length; col++) {
          if (row == 0)
            matrix[row, col] = 1;
          else if (row == 1)
            matrix[row, col] = vector1[col];
          else if (row == 2)
            matrix[row, col] = vector2[col];
        }
      }


      return MatrixFunctions.CrossProduct(matrix);
    }

  }


}
