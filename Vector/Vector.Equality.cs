using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{
    /// <summary>
    /// Returns True if two vectors contain the same entry values.
    /// </summary>
    public override bool Equals(object obj) {
      return Equals(obj as Vector);
    }


    /// <summary>
    /// Returns True if two vectors contain the same entry values.
    /// </summary>
    public  bool Equals(double[] obj) {
      if (obj == null)
        return false;

      return Equals(new Vector(obj));
    }

    /// <summary>
    /// Returns True if two vectors contain the same entry values.
    /// </summary>
    public bool Equals(Vector other) {
      if (other == null)
        return false;

      return VectorFunctions.Equals(this.InnerArray, other.InnerArray);
    }

    public override int GetHashCode() {
      return InnerArray.GetHashCode();
    }
  }
}