using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix  {
    /// <summary>
    /// Creates a subspace projection matrix.
    /// </summary>
    /// <returns></returns>
    public Matrix CreateProjectionMatrix() {
      return new Matrix(MatrixFunctions.CreateProjectionMatrix(this.InnerMatrix));
    }

    /// <summary>
    /// Projects specified vector onto the current matrix subspace.
    /// </summary>
    public Vector Project(double[] vector) {
      return Project(new Vector(vector));

    }

    /// <summary>
    /// Projects specified vector onto the current matrix subspace.
    /// </summary>
    public Vector Project(Vector vector) {
      var projectionMatrix = CreateProjectionMatrix();
      var vectorMatrix = vector.AsMatrix();

      return projectionMatrix.Multiply(vectorMatrix).GetColumnVectors()[0];
    }
 

  }
}