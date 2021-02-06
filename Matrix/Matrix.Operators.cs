using System;
using System.Linq;

namespace Elsheimy.Components.Linears {
  public partial class Matrix {
    public static Matrix operator +(Matrix m) { return m; }
    public static Matrix operator -(Matrix m) { return m.Scale(-1); }
    public static Matrix operator +(Matrix a, Matrix b) { return a.Add(b); }
    public static Matrix operator -(Matrix a, Matrix b) { return a.Subtract(b); }
    public static Matrix operator +(Matrix a, double[,] b) { return a.Add(b); }
    public static Matrix operator -(Matrix a, double[,] b) { return a.Subtract(b); }

    public static Matrix operator *(double a, Matrix m) { return m.Scale(a); }
    public static Matrix operator *(Matrix a, Matrix b) { return a.Multiply(b); }
    public static Matrix operator *(Matrix a, double[,] b) { return a.Multiply(b); }

    public static bool operator ==(Matrix a, Matrix b) {
      if ((a as object) == null || (b as object) == null)
        return false;
      return a.Equals(b);
    }
    public static bool operator !=(Matrix a, Matrix b) {
      if ((a as object) == null || (b as object) == null)
        return false;
      return a.Equals(b) == false;
    }

    public static Matrix operator ^(Matrix a, int power) { return a.Power(power); }


    public static implicit operator double[,] (Matrix m) { return m.InnerMatrix; }
    public static explicit operator Matrix(double[,] m) { return new Linears.Matrix(m); }

  }

}
