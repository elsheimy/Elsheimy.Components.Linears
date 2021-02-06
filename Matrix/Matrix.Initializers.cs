using System;
using System.Collections.Generic;

namespace Elsheimy.Components.Linears {
  public partial class Matrix : ICloneable, IEquatable<Matrix> {
    #region Identity
    /// <summary>
    /// Creates 2-dimensional identity matrix.
    /// </summary>
    public static Matrix Create2DIdentityMatrix() { return CreateIdentityMatrix(2); }
    /// <summary>
    /// Creates 3-dimensional identity matrix.
    /// </summary>
    public static Matrix Create3DIdentityMatrix() { return CreateIdentityMatrix(3); }
    /// <summary>
    /// Creates n-dimensional identity matrix.
    /// </summary>
    public static Matrix CreateIdentityMatrix(int length) {
      return new Matrix(MatrixFunctions.CreateIdentityMatrix(length));
    }
    #endregion

    #region Random
    /// <summary>
    /// Generates random square matrix of n-dimensions where entries range from 0 to the specified max value.
    /// </summary>
    public static Matrix GenerateRandomMatrix(int length, double maxValue) {
      return GenerateRandomMatrix(length, length, maxValue);
    }
    /// <summary>
    /// Geenerates random square matrix of n by m dimensions where entries range from 0 to the specified max value. 
    /// </summary>
    public static Matrix GenerateRandomMatrix(int numRows, int numCols, double maxValue) {
      return new Matrix(MatrixFunctions.GenerateRandomMatrix(numRows, numCols, maxValue));
    }
    #endregion

    #region Other
    /// <summary>
    /// Creates transformation matrix from the specified matrices. Technically multiplies n-dimensional matrix by the specified matrices.
    /// </summary>
    public static Matrix CreateTransformationMatrix(int dimension, params Matrix[] matrices) {
      Matrix matrix = Matrix.CreateIdentityMatrix(dimension);
      if (matrices != null) {
        foreach (var mat in matrices) {
          matrix = matrix.Multiply(mat);
        }
      }

      return matrix;
    }

    /// <summary>
    /// Creates transformation matrix from the specified matrices. Technically multiplies n-dimensional matrix by the specified matrices.
    /// </summary>
    public static Matrix CreateTransformationMatrix(int dimension, params double[][,] matrices) {
      Matrix matrix = Matrix.CreateIdentityMatrix(dimension);
      if (matrices != null) {
        foreach (var mat in matrices) {
          matrix = matrix.Multiply(mat);
        }
      }

      return matrix;
    }
    #endregion

    #region Rotation
    /// <summary>
    /// Creates 2-dimensional rotation matrix to the specified angle and direction.
    /// </summary>
    public static Matrix Create2DRotationMatrix(double angle, AngleUnit unit, MatrixRotationDirection direction) {
      return new Matrix(MatrixFunctions.Create2DRotationMatrix(angle, unit, direction));
    }
    /// <summary>
    /// Creates 3-dimensional rotation matrix to the specified angle and direction.
    /// </summary>
    public static Matrix Create3DRotationMatrix(double angle, AngleUnit unit, MatrixAxis axis) {
      return new Matrix(MatrixFunctions.Create3DRotationMatrix(angle, unit, axis));
    }
    #endregion

    #region Reflection
    /// <summary>
    /// Creates 2-dimensional reflection matrix over the specified axis.
    /// </summary>
    public static Matrix Create2DReflectionMatrix(MatrixAxis axis) {
      return new Matrix(MatrixFunctions.Create2DReflectionMatrix(axis));
    }
    /// <summary>
    /// Creates 3-dimensional reflection matrix over the specified plane.
    /// </summary>
    public static Matrix Create3DReflectionMatrix(Matrix3DReflectionPlane plane) {
      return new Matrix(MatrixFunctions.Create3DReflectionMatrix(plane));
    }
    #endregion

    #region Shearing
    /// <summary>
    /// Creates 2-dimensional shearing matrix over the specified axis.
    /// </summary>
    public static Matrix Create2DShearingMatrix(double factor, MatrixAxis axis) {
      return new Matrix(MatrixFunctions.Create2DShearingMatrix(factor, axis));
    }
    /// <summary>
    /// Creates 3-dimensional shearing matrix over the specified axis.
    /// </summary>
    public static Matrix Create3DShearingMatrix(double factor, MatrixAxis axis) {
      return new Matrix(MatrixFunctions.Create3DShearingMatrix(factor, axis));
    }


    #endregion
  }

}
