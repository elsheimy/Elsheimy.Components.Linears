using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix {
    /// <summary>
    /// Rotates a 2D matrix to a specific angle in a spcific direction (clockwise / counter-clockwise.)
    /// </summary>
    public virtual Matrix Rotate(double angle, AngleUnit unit, MatrixRotationDirection direction) {
      if (Is2DMatrix == false)
        throw new InvalidOperationException(Properties.Resources.Exception_2DRequired);
      return new Matrix(MatrixFunctions.Create2DRotationMatrix(angle, unit, direction));
    }

    /// <summary>
    /// Rotates a 3D matrix to a specific angle in a given axis.
    /// </summary>
    public virtual Matrix Rotate(double angle, AngleUnit unit, MatrixAxis axis) {
      if (Is3DMatrix == false)
        throw new InvalidOperationException(Properties.Resources.Exception_3DRequired);
      return new Matrix(MatrixFunctions.Create3DRotationMatrix(angle, unit, axis));
    }


    /// <summary>
    /// Mirrors matrix entries horizontally / vertically.
    /// </summary>
    public virtual Matrix Mirror(MatrixDirection direction) {
      if (direction == MatrixDirection.Horizontal)
        return new Linears.Matrix(MatrixFunctions.MirrorHorizontally(this.InnerMatrix));
      else
        return new Linears.Matrix(MatrixFunctions.MirrorVertically(this.InnerMatrix));

    }
  }
}