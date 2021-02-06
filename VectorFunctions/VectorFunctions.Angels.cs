using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  internal static partial class VectorFunctions {
    public static double AngleBetween(double[] vector1, double[] vector2, AngleUnit unit) {
      if (vector1.Length != vector2.Length)
        throw new InvalidOperationException(Properties.Resources.Exception_DimensionsMismatch);

      var dotProduct = DotProduct(vector1, vector2);
      var lengthProduct = GetMagnitude(vector1) * GetMagnitude(vector2);

      var result = Math.Acos(dotProduct / lengthProduct);
      if (unit == AngleUnit.Degrees)
        result = Converters.RadiansToDegrees(result);

      return result;
    }

  }


}
