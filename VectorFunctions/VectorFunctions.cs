using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {

    public static double[] GenerateRandomVector(int dimension, double maxValue = 1) {
      Random rand = new Random();
      double[] output = new double[dimension];

      for (int i = 0; i < dimension;i++) {
        output[i] = rand.NextDouble() * maxValue;

      }

      return output;
    }

    public static string ToString(double[] input) {
      string str = string.Empty;

      for (int i = 0; i < input.GetLength(0); i++) {
        str += input[i].ToString() + ", ";

       
      }

      str = str.TrimEnd(',', ' ');

      return str;
    }

  }


}
