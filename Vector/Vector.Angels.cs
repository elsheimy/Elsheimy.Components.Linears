using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{
    /// <summary>
    /// Returns angle in radians / degrees between two vectors.
    /// </summary>
    public virtual double AngleBetween(Vector other, AngleUnit unit) {
      return AngleBetween(other.InnerArray, unit);
    }

    /// <summary>
    /// Returns angle in radians / degrees between two vectors.
    /// </summary>
    public virtual double AngleBetween(double[] other, AngleUnit unit) {
      return VectorFunctions.AngleBetween(this.InnerArray, other, unit);
    }


  }
}