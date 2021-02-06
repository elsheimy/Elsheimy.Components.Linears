using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {
    public static double ProjectionFactor(double[] vector1, double[] vector2) {
      return DotProduct(vector1, vector2) / DotProduct(vector2, vector2);
    }
    public static double[] Projection(double[] vector1, double[] vector2) {
      var factor = ProjectionFactor(vector1, vector2);
      return Scale(factor, vector2);
    }


    
  }


}
