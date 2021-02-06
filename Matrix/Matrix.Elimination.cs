using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix {
    /// <summary>
    /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form.
    /// Accepts the number of augmeted columns. If the number specified is null, the default number specified in the matrix is used.
    /// </summary>
    /// <remarks>
    /// If <param name="augmentedColCount">augmentedColCount</param> is null, <seealso cref="Elsheimy.Components.Linears.Matrix.AugmentedColumnCount"/> is used.
    /// </remarks>
    public virtual Matrix Reduce(MatrixReductionForm form, int? augmentedColCount = null) {
      int augmentedCols = augmentedColCount ?? this.AugmentedColumnCount;

      return new Matrix(MatrixFunctions.Eliminate(this.InnerMatrix, form, augmentedCols).FullMatrix);
    }


    /// <summary>
    /// Reduces matrix to reduced row-echelon (RREF/Gauss-Jordan) form and solves for augmented columns.
    /// Returns the matrix solution and outputs the full matrix (reduced matrix along with the solution. 
    /// Accepts the number of augmeted columns. If the number specified is null, the default number specified in the matrix is used.
    /// </summary>
    /// <returns>
    /// Returns the matrix solution result.
    /// </returns>
    /// <remarks>
    /// The default value for <seealso cref="Elsheimy.Components.Linears.Matrix.AugmentedColumnCount"/> is used.
    /// </remarks>
    public virtual MatrixEliminationResult Solve(int? augmentedColCount) {
      int augmentedCols = augmentedColCount ?? this.AugmentedColumnCount;

      if (augmentedCols <= 0)
        throw new InvalidOperationException(Properties.Resources.Exception_NoAugmentedColumns);

     return MatrixFunctions.Eliminate(this.InnerMatrix, MatrixReductionForm.ReducedRowEchelonForm, augmentedCols);
    }

    /// <summary>
    /// Returns matrix rank.
    /// Accepts the number of augmeted columns. If the number specified is null, the default number specified in the matrix is used.
    /// </summary>
    /// <remarks>
    /// If <param name="augmentedColCount">augmentedColCount</param> is null, <seealso cref="Elsheimy.Components.Linears.Matrix.AugmentedColumnCount"/> is used.
    /// </remarks>
    public virtual int GetRank(int? augmentedColCount = null) {
      int augmentedCols = augmentedColCount ?? this.AugmentedColumnCount;
      return MatrixFunctions.GetRank(this.InnerMatrix, augmentedCols);
    }
  }
}
