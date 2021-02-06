using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {
    public static double[] Clone (double[] input) {
      int length = input.Length;

      double[] output = new double[length];

      Array.Copy(input, output, length);

      return output;
    }


    public static bool Equals(double[] input1, double[] input2) {
      int length = input1.Length;

      if (length != input2.Length)
        return false;

      for( int i=  0; i < length;i++)
        if (input1[i] != input2[i])
          return false;

      return true;
    }

  }


}
