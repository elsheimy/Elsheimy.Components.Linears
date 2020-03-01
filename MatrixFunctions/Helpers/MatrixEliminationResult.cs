namespace Elsheimy.Components.Linears {
  internal class MatrixEliminationResult {
    /// <summary>
    /// Full matrix along with the augmented columns.
    /// </summary>
    public double[,] FullMatrix { get; internal set; }
    public int Rank { get; internal set; }
    public int AugmentedColumnCount { get; internal set; }
    /// <summary>
    /// Solution matrix (if found.)
    /// </summary>
    public double[,] Solution { get; internal set; }
    public MatrixSolutionState SolutionState { get; internal set; }
    
  }
}