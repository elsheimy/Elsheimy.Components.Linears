using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {


    internal static double[,] FromString(string str) {
      string[] lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

      double[,] output = new double[lines.Length, lines[0].Split(',').Count()];

      for (int r = 0; r < lines.Length; r++) {
        var split = lines[r].Split(',');

        for (int c = 0; c < split.Length; c++) {
          var val = split[c].Trim();

          output[r, c] = double.Parse(val);
        }
      }

      return output;
    }


    internal static string ToString(double[,] matrix, int augmentedCols = 0) {
      string str = string.Empty;
      int rowCount = matrix.GetLength(0);
      int colCount = matrix.GetLength(1);
      int augmentedColsStartIndex = matrix.GetLength(1) - augmentedCols;

      for (int row = 0; row < rowCount; row++) {
        for (int col = 0; col < colCount; col++) {
          str += matrix[row, col].ToString();

          if (col == augmentedColsStartIndex - 1)
            str += " | ";
          else
            str += ", ";
        }
        str = str.TrimEnd(',', ' ', '|');

        if (row + 1 != rowCount)
          str += Environment.NewLine;
      }

      return str;
    }

  }

}
