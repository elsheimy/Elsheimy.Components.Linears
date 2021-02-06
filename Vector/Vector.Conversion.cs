using System;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{
    /// <summary>
    /// Converts vector to matrix.
    /// </summary>
    public virtual Matrix AsMatrix() {
      return new Linears.Matrix(VectorFunctions.ToMatrix(this.InnerArray));
    }
  }
}