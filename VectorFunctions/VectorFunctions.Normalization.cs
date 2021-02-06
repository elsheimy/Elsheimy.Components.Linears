using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {
    /// <summary>
    /// Normalizes a vector.
    /// </summary>
    public static double[] ToUnitVector(double[] input) {
      var length = input.Length;

      double[] output = new double[length];
      var coeffecient = 1.0 / GetMagnitude(input);

      for (int i = 0; i < length; i++) {
        output[i] = coeffecient * input[i];
      }

      return output;
    }


    public static double GetMagnitude(double[] input) {
      double val = 0;

      for (int i = 0; i < input.Length; i++)
        val += input[i] * input[i];

      val = Math.Sqrt(val);

      return val;
    }

  }


}
