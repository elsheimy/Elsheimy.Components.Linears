using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector : ICloneable, IEquatable<Vector> {
    /// <summary>
    /// Calculates magnitude/length of vector.
    /// </summary>
    public virtual double GetMagnitude() {
      return VectorFunctions.GetMagnitude(this.InnerArray);
    }

    /// <summary>
    /// Normalizes vector.
    /// </summary>
    public virtual Vector ToUnitVector() {
      return new Vector( VectorFunctions.ToUnitVector(this.InnerArray));
    }


  }
}