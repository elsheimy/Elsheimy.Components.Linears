using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    #region Concatenation
    /// <summary>
    /// Concats another matrix horizontally / vertically.
    /// </summary>
    public virtual Matrix Concat(Matrix matrix, MatrixDirection direction) {
      return Concat(matrix.InnerMatrix, direction);
    }
    /// <summary>
    /// Concats another matrix horizontally / vertically.
    /// </summary>
    public virtual Matrix Concat(double[,] matrix, MatrixDirection direction) {
      if (direction == MatrixDirection.Horizontal)
        return new Matrix(MatrixFunctions.ConcatHorizontally(this.InnerMatrix, matrix));
      else
        return new Matrix(MatrixFunctions.ConcatVertically(this.InnerMatrix, matrix));
    }
    #endregion

    #region Expanding
    /// <summary>
    /// Expands matrix by the specified number of columns (at the start / at the end.)
    /// </summary>
    public virtual Matrix ExpandColumns(int cols, MatrixPosition pos) {
      if (cols < 0)
        throw new ArgumentOutOfRangeException(nameof(cols));

      double[,] newMatrix = new double[this.RowCount,  cols];

      if (pos == MatrixPosition.Start)
        return new Matrix(newMatrix).Concat(this, MatrixDirection.Horizontal);
      else
        return Concat(newMatrix, MatrixDirection.Horizontal);
    }
    /// <summary>
    /// Expands matrix by the specified number of rows (at the start / at the end.)
    /// </summary>
    public virtual Matrix ExpandRows(int rows, MatrixPosition pos) {
      if (rows < 0)
        throw new ArgumentOutOfRangeException(nameof(rows));

      double[,] newMatrix = new double[ rows, this.ColumnCount];
      if (pos == MatrixPosition.Start)
        return new Matrix(newMatrix).Concat(this, MatrixDirection.Vertical);
      else
        return Concat(newMatrix, MatrixDirection.Vertical);
    }
    #endregion

    #region Shrinking
    /// <summary>
    /// Shrinks matrix by number of columns (from the start / from the end.)
    /// </summary>
    public virtual Matrix ShrinkColumns(int colsToShrink, MatrixPosition pos) {
      int[] cols = null;
      if (pos == MatrixPosition.Start)
        cols = Enumerable.Range(0, colsToShrink).ToArray();
      else
        cols = Enumerable.Range(this.ColumnCount - colsToShrink , colsToShrink).ToArray();
      return new Matrix(MatrixFunctions.RemoveColumns(this.InnerMatrix, cols));
    }
    /// <summary>
    /// Shrinks matrix by number of rows (from the start / from the end.)
    /// </summary>
    public virtual Matrix ShrinkRows(int rowsToShrink, MatrixPosition pos) {
      int[] rows = null;
      if (pos == MatrixPosition.Start)
        rows = Enumerable.Range(0, rowsToShrink).ToArray();
      else
        rows = Enumerable.Range(this.RowCount - rowsToShrink , rowsToShrink).ToArray();
      return new Matrix(MatrixFunctions.RemoveRows(this.InnerMatrix, rows));
    }
    #endregion

    #region Removing
    /// <summary>
    /// Removes specific columns.
    /// </summary>
    public virtual Matrix RemoveColumns(int[] cols) {
      return new Linears.Matrix(MatrixFunctions.RemoveColumns(this.InnerMatrix, cols));
    }

    /// <summary>
    /// Removes specific rows.
    /// </summary>
    public virtual Matrix RemoveRows(int[] rows) {
      return new Linears.Matrix(MatrixFunctions.RemoveRows(this.InnerMatrix, rows));
    }
    #endregion

    
  }
}