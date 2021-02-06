using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{
    /// <summary>
    /// Adds another vector (right).
    /// </summary>
    public virtual Vector Add(double[] vector) {
      return new Vector(VectorFunctions.Add(this.InnerArray, vector));
    }

    /// <summary>
    /// Adds another vector (right).
    /// </summary>
    public virtual Vector Add(Vector vector) {
      return Add(vector.InnerArray);
    }

    /// <summary>
    /// Subtracts another vector (right).
    /// </summary>
    public virtual Vector Subtract(double[] vector) {
      return new Vector(VectorFunctions.Subtract(this.InnerArray, vector));
    }

    /// <summary>
    /// Subtracts another vector (right).
    /// </summary>
    public virtual Vector Subtract(Vector vector) {
      return Subtract(vector.InnerArray);
    }

  }
}