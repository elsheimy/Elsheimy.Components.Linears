using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    /// <summary>
    /// Returns true if both matrices contain the same entry values.
    /// </summary>
    public bool Equals(double[,] other) {
      if (other == null)
        return false;

      return MatrixFunctions.Equals(this.InnerMatrix, other);
    }

    /// <summary>
    /// Returns true if both matrices contain the same entry values.
    /// </summary>
    public bool Equals(Matrix other) {
      if (other == null)
        return false;

      return MatrixFunctions.Equals(this.InnerMatrix, other.InnerMatrix);
    }

    /// <summary>
    /// Returns true if both matrices contain the same entry values.
    /// </summary>
    public override bool Equals(object obj) {
      return this.Equals(obj as Matrix);
    }

    public override int GetHashCode() {
      return this.InnerMatrix.GetHashCode();
    }


    /// <summary>
    /// Returns True if both matrices have the same dimensions.
    /// </summary>
    public bool IsSameDimensions(Matrix other) {
      return this.RowCount == other.RowCount && this.ColumnCount == other.ColumnCount;
    }
    /// <summary>
    /// Returns True if both matrices have the same dimensions.
    /// </summary>
    public bool IsSameDimensions(double[,] other) {
      return this.RowCount == other.GetLength(0) && this.ColumnCount == other.GetLength(1);
    }

    /// <summary>
    /// Returns True of the transpose of the other matrix has the same dimensions as this matrix.
    /// </summary>
    public bool IsSameTransposeDimensions(Matrix other) {
      return this.RowCount == other.ColumnCount && this.ColumnCount == other.RowCount;
    }
    /// <summary>
    /// Returns True of the transpose of the other matrix has the same dimensions as this matrix.
    /// </summary>
    public bool IsSameTransposeDimensions(double[,] other) {
      return this.RowCount == other.GetLength(1) && this.ColumnCount == other.GetLength(0);
    }
  }
}