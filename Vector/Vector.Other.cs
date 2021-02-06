using System;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector>{

    /// <summary>
    /// Rounds vector entries to the nearest integeral value.
    /// </summary>
    public virtual Vector Round(int decimals) {
      return new Vector(VectorFunctions.Round(this.InnerArray, decimals));
    }
  }
}