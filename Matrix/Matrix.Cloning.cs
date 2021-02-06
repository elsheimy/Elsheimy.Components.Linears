using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    /// <summary>
    /// Creates a deep copy of the matrix.
    /// </summary>
    public virtual Matrix CreateCopy() {
      return new Matrix(MatrixFunctions.CreateCopy(this.InnerMatrix));
    }
    /// <summary>
    /// Creates a deep copy of the matrix using unsafe code. Might provide better performance with large matrices.
    /// </summary>
    public virtual Matrix CreateCopyUnsafe() {
      return new Matrix(MatrixFunctions.CreateCopyUnsafe(this.InnerMatrix));
    }
    /// <summary>
    /// Creates a deep copy of the matrix.
    /// </summary>
    public object Clone() {
      return CreateCopy();
    }
  }
}