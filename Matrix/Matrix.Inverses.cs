using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    /// <summary>
    /// Calculates the inverse of matrix. Returns null if non-invertible.
    /// </summary>
    public virtual Matrix Invert() {
      var inverse = MatrixFunctions.Invert(this.InnerMatrix);
      if (inverse == null)
        return null;
      return new Matrix(inverse);
    }

    /// <summary>
    /// Returns a value indicates whether matrix is invertible. Internally uses matrix determinant.
    /// </summary>
    public virtual bool IsInvertible() {
      return MatrixFunctions.IsInvertible(this.InnerMatrix);
    }
  }
}