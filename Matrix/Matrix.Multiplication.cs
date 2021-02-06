using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    /// <summary>
    /// Multiplies/scales matrix by a scalar input.
    /// </summary>
    public virtual Matrix Scale(double scalar) {
      return new Matrix(MatrixFunctions.Multiply(scalar, this.InnerMatrix));
    }


    /// <summary>
    /// Multiplies matrix by another.
    /// </summary>
    public virtual Matrix Multiply(Matrix matrix) {
      return Multiply(matrix.InnerMatrix);
    }


    /// <summary>
    /// Multiplies matrix by another.
    /// </summary>
    public virtual Matrix Multiply(double[,] matrix) {
      return new Matrix(MatrixFunctions.Multiply(this.InnerMatrix, matrix));
    }

    /// <summary>
    /// Raises matrix to the spcified power.
    /// </summary>
    public virtual Matrix Power(int power) {
      return new Matrix(MatrixFunctions.Power(this.InnerMatrix, power));
    }


  }
}