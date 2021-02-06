using System;

namespace Elsheimy.Components.Linears {
  public partial class Matrix : ICloneable, IEquatable<Matrix> {
    #region Fields
    private double[,] _innerMatrix;
    #endregion

    #region Properties
    /// <summary>
    /// Total row count. 
    /// </summary>
    public int RowCount { get; protected set; }
    /// <summary>
    /// Total column count including augmented columns (if any.)
    /// </summary>
    public int ColumnCount { get; protected set; }
    /// <summary>
    /// Returns True if matrix is a square matrix.
    /// </summary>
    public bool IsSquare { get { return RowCount == ColumnCount; } }
    /// <summary>
    /// Returns True if matrix is a 2-dimensional matrix.
    /// </summary>
    public bool Is2DMatrix { get { return RowCount == 2; } }
    /// <summary>
    /// Returns True if matrix is a 2-dimensional matrix.
    /// </summary>
    public bool Is3DMatrix { get { return RowCount == 3; } }
    /// <summary>
    /// Default number of augmented columns (if any.) Used only in matrix reduction and elimination functions.
    /// </summary>
    public int AugmentedColumnCount { get; set; }
    /// <summary>
    /// Inner raw array.
    /// </summary>
    public double[,] InnerMatrix {
      get { return _innerMatrix; }
      protected set {
        _innerMatrix = value;
        RefreshLengths();
      }
    }
    #endregion

    #region Indexers
    /// <summary>
    /// Sets/returns the required entry.
    /// </summary>
    public double this[int r, int c] {
      get {
        return this.InnerMatrix[r, c];
      }
      set {
        this.InnerMatrix[r, c] = value;
      }
    }
    #endregion

    /// <summary>
    /// Creates a square n-dimensional zero matrix.
    /// </summary>
    public Matrix(int length) : this(length, length) { }
    /// <summary>
    /// Creates a n by m zero matrix.
    /// </summary>
    public Matrix(int rows, int cols) {
      InnerMatrix = new double[rows, cols];
    }
    /// <summary>
    /// Creates a matrix from the specified raw array. Sets augmented columns (if any.)
    /// </summary>
    public Matrix(double[,] matrix, int augmentedCols = 0) {
      InnerMatrix = matrix;
      SetAugmentedColumnCount(augmentedCols);
    }

    #region Other
    /// <summary>
    /// Sets augmented column count. Augmented columns value is used only in matrix reduction/elimination functions.
    /// </summary>
    public virtual void SetAugmentedColumnCount(int cols) {
      if (cols >= ColumnCount)
        throw new ArgumentException(nameof(cols), Properties.Resources.Exception_TooMuchAugmentedColumns);

      this.AugmentedColumnCount = cols;
    }

    /// <summary>
    /// Refreshes <seealso cref="Matrix.RowCount"/> and <seealso cref="Matrix.ColumnCount"/>.
    /// </summary>
    protected void RefreshLengths() {
      RowCount = InnerMatrix.GetLength(0);
      ColumnCount = InnerMatrix.GetLength(1);
    }

    #endregion

    #region Helpers
    /// <summary>
    /// Outputs matrix in a string format.
    /// </summary>
    public override string ToString() {
      return MatrixFunctions.ToString(InnerMatrix, this.AugmentedColumnCount);
    }
    #endregion
  }

}
