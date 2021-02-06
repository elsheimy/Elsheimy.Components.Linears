using System;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{
    #region Fields
    private double[] _innerArray;
    #endregion

    #region Properties
    /// <summary>
    /// Returns vector dimension / length.
    /// </summary>
    public int Dimension { get; protected set; }
    /// <summary>
    /// Returns inner array representation of vector.
    /// </summary>
    public double[] InnerArray {
      get { return _innerArray; }
      protected set {
        _innerArray = value;
        this.Dimension = value.Length;
      }
    }
    /// <summary>
    /// Returns True if vector is 2-dimensional.
    /// </summary>
    public bool Is2DVector { get { return Dimension == 2; } }
    /// <summary>
    /// Returns True if vector is 3-dimensional.
    /// </summary>
    public bool Is3DVector { get { return Dimension == 3; } }
    #endregion

    #region Indexer
    public double this[int pos] {
      get {
        return this.InnerArray[pos];
      }
      set {
        this.InnerArray[pos] = value;
      }
    }
    #endregion


    public Vector(int dimension) {
      InnerArray = new double[dimension];
    }
    public Vector(double[] vector) {
      InnerArray = vector;
    }

    #region Helpers
    public override string ToString() {
      return VectorFunctions.ToString(this.InnerArray);
    }
    #endregion
  }
}