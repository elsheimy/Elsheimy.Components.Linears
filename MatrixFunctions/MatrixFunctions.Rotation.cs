using System;

namespace Elsheimy.Components.Linears {
  internal static partial class MatrixFunctions {
    /// <summary>
    /// Creates 2-dimensional rotation matrix using the specified angle.
    /// </summary>
    public static double[,] Create2DRotationMatrix(double angle, AngleUnit unit, MatrixRotationDirection direction) {
      // sin and cos accept only radians

      double angleRadians = angle;
      if (unit == AngleUnit.Degrees)
        angleRadians = Converters.DegreesToRadians(angleRadians);


      double[,] output = new double[2, 2];

      output[0, 0] = Math.Cos(angleRadians);
      output[1, 0] = Math.Sin(angleRadians);
      output[0, 1] = Math.Sin(angleRadians);
      output[1, 1] = Math.Cos(angleRadians);

      if (direction == MatrixRotationDirection.Clockwise)
        output[1, 0] *= -1;
      else
        output[0, 1] *= -1;


      return output;
    }

    /// <summary>
    /// Creates 2-dimensional rotation matrix using the specified angle and axis.
    /// </summary>
    public static double[,] Create3DRotationMatrix(double angle, AngleUnit unit, MatrixAxis axis) {
      // sin and cos accept only radians

      double angleRadians = angle;
      if (unit == AngleUnit.Degrees)
        angleRadians = Converters.DegreesToRadians(angleRadians);


      double[,] output = new double[3,3];

      if (axis == MatrixAxis.X) {
        output[0, 0] = 1;
        output[1, 1] = Math.Cos(angleRadians);
        output[2, 1] = Math.Sin(angleRadians);
        output[1, 2] = -1 * Math.Sin(angleRadians);
        output[2, 2] = Math.Cos(angleRadians);
      } else if (axis == MatrixAxis.Y) {
        output[1, 1] = 1;
        output[0, 0] = Math.Cos(angleRadians);
        output[2, 0] = -1 * Math.Sin(angleRadians);
        output[0, 2] = Math.Sin(angleRadians);
        output[2, 2] = Math.Cos(angleRadians);
      } else if (axis == MatrixAxis.Z) {
        output[2, 2] = 1;
        output[0,0] = Math.Cos(angleRadians);
        output[1, 0] = Math.Sin(angleRadians);
        output[0, 1] = -1 * Math.Sin(angleRadians);
        output[1, 1] = Math.Cos(angleRadians);
      }


      return output;
    }

  }

}