using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector : ICloneable, IEquatable<Vector> {
    /// <summary>
    /// Returns the projection factor of current vector onto another vector.
    /// </summary>
    public virtual double ProjectionFactor(Vector other) {
      return ProjectionFactor(other.InnerArray);
    }
    /// <summary>
    /// Returns the projection factor of current vector onto another vector.
    /// </summary>
    public virtual double ProjectionFactor(double[] other) {
      return VectorFunctions.ProjectionFactor(this.InnerArray, other);
    }

    /// <summary>
    /// Returns the projection of current vector onto another vector.
    /// </summary>
    public virtual Vector Projection(Vector other) {
      return Projection(other.InnerArray);
    }
    /// <summary>
    /// Returns the projection of current vector onto another vector.
    /// </summary>
    public virtual Vector Projection(double[] other) {
      return new Vector( VectorFunctions.Projection(this.InnerArray, other));
    }
  }
}