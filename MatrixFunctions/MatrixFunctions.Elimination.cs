using System;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    /// <summary>
    /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form.
    /// </summary>
    public static double[,] Reduce(double[,] input, MatrixReductionForm form) {
      return Eliminate(input, form, 0).FullMatrix;
    }

    /// <summary>
    /// Returns the state of a solved matrix.
    /// </summary>
    public static MatrixSolutionState GetSolutionState(double[,] input, int augmentedCols) {
      var rowCount = input.GetLength(0);
      var totalCols = input.GetLength(1);

      for (int row = 0; row < rowCount; row++) {
        var sumRow = MatrixFunctions.RowSum(input, row, 0, totalCols - augmentedCols - 1);
        var sumAug = MatrixFunctions.RowSum(input, row, totalCols - augmentedCols, totalCols - 1);

        if (sumRow + sumAug == 0)
          return MatrixSolutionState.Infinite;
        else if (sumRow == 0)
          return MatrixSolutionState.None;
      }

      return MatrixSolutionState.Unique;
    }

    /// <summary>
    /// Returns matrix rank.
    /// </summary>
    public static int GetRank(double[,] input, int augmentedCols = 0) {
      return Eliminate(input, MatrixReductionForm.RowEchelonForm, augmentedCols).Rank;
    }

    /// <summary>
    /// Reduces matrix to row-echelon (REF/Gauss) or reduced row-echelon (RREF/Gauss-Jordan) form and solves for augmented columns (if any.)
    /// </summary>
    public static MatrixEliminationResult Eliminate(double[,] input, MatrixReductionForm form, int augmentedCols = 0) {
      int totalRowCount = input.GetLength(0);
      int totalColCount = input.GetLength(1);

      if (augmentedCols >= totalColCount)
        throw new ArgumentException(nameof(augmentedCols), Properties.Resources.Exception_TooMuchAugmentedColumns);

      MatrixEliminationResult result = new MatrixEliminationResult();

      double[,] output = CreateCopy(input);

      // number of pivots found
      int numPivots = 0;

      // loop through columns, exclude augmented columns
      for (int col = 0; col < totalColCount - augmentedCols; col++) {
        int? pivotRow = FindPivot(output, numPivots, col, totalRowCount);

        if (pivotRow == null)
          continue; // no pivots, go to another column

        ReduceRow(output, pivotRow.Value, col, totalColCount);

        SwitchRows(output, pivotRow.Value, numPivots, totalColCount);

        pivotRow = numPivots;
        numPivots++;

        // Eliminate Previous Rows
        if (form == MatrixReductionForm.ReducedRowEchelonForm) {
          for (int tmpRow = 0; tmpRow < pivotRow; tmpRow++)
            EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);
        }

        // Eliminate Next Rows
        for (int tmpRow = pivotRow.Value; tmpRow < totalRowCount; tmpRow++)
          EliminateRow(output, tmpRow, pivotRow.Value, col, totalColCount);

      }

      result.Rank = numPivots;
      result.FullMatrix = output;
      result.AugmentedColumnCount = augmentedCols;
      if (augmentedCols > 0 && form == MatrixReductionForm.ReducedRowEchelonForm) { // matrix has solution 
        result.Solution = ExtractColumns(output, totalColCount - augmentedCols, totalColCount - 1);
      }

      return result;
    }




    private static void EliminateRow(double[,] input, int row, int pivotRow, int pivotCol, int colCount) {
      if (pivotRow == row)
        return;

      if (input[row, pivotCol] == 0)
        return;

      double coeffecient = input[row, pivotCol];

      for (int col = pivotCol; col < colCount; col++) {
        input[row, col] -= input[pivotRow, col] * coeffecient;
      }
    }

    private static void SwitchRows(double[,] input, int row1, int row2, int colCount) {
      if (row1 == row2)
        return;

      for (int col = 0; col < colCount; col++) {
        var tmpVal1 = input[row1, col];
        input[row1, col] = input[row2, col];
        input[row2, col] = tmpVal1;
      }
    }

    private static void ReduceRow(double[,] input, int row, int col, int colCount) {
      var coeffecient = 1.0 / input[row, col];

      if (coeffecient == 1)
        return;

      for (; col < colCount; col++)
        input[row, col] *= coeffecient;
    }

    private static int? FindPivot(double[,] input, int startRow, int col, int rowCount) {
      for (int i = startRow; i < rowCount; i++) {
        if (input[i, col] != 0)
          return i;
      }

      return null;
    }
  }

}
