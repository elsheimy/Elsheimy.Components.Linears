using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector : ICloneable, IEquatable<Vector> {
    /// <summary>
    /// Dot product of current vector and another vector.
    /// </summary>
    public virtual double DotProduct(Vector other) {
      return DotProduct(other.InnerArray);
    }
    /// <summary>
    /// Dot product of current vector and another vector.
    /// </summary>
    public virtual double DotProduct(double[] other) {
      return VectorFunctions.DotProduct(this.InnerArray, other);
    }

    /// <summary>
    /// Multiplies/scales vector by a scalar input.
    /// </summary>
    public virtual Vector Scale(double scalar) {
      return new Linears.Vector(VectorFunctions.Scale(scalar, this.InnerArray));
    }

    /// <summary>
    /// Cross product of current vector with another vector.
    /// </summary>
    public virtual Vector CrossProduct(Vector other) {
      return CrossProduct(other.InnerArray);
    }


    /// <summary>
    /// Cross product of current vector with another vector.
    /// </summary>
    public virtual Vector CrossProduct(double[] other) {
      return new Linears.Vector(VectorFunctions.CrossProduct(this.InnerArray, other));
    }

    /// <summary>
    /// Returns True if two vectors are perpendicular.
    /// </summary>
    public virtual bool IsPerpendicular(Vector other) {
      return IsPerpendicular(other.InnerArray);
    }

    /// <summary>
    /// Returns True if two vectors are perpendicular.
    /// </summary>
    public virtual bool IsPerpendicular(double[] other) {
      return DotProduct(other) == 0;
    }


  }
}