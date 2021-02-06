namespace Elsheimy.Components.Linears {
  public class MatrixEliminationResult {
    /// <summary>
    /// Full matrix along with the augmented columns.
    /// </summary>
    public double[,] FullMatrix { get; internal set; }
    public int Rank { get; internal set; }

    // Augmentation
    public int AugmentedColumnCount { get; internal set; }
    public double[,] AugmentedColumns { get; internal set; }


    public int TotalRowCount { get; internal set; }
    public int TotalColumnCount { get; internal set; }
    public int UnknownsCount { get; internal set; }

    /// <summary>
    /// Solution matrix. Free columns are denoted by NULL.
    /// </summary>
    public double?[] Solution { get; internal set; }
    public MatrixSolutionState SolutionState { get; internal set; }
  }
}
