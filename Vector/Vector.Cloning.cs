using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsheimy.Components.Linears {
  public partial class Vector :  ICloneable, IEquatable<Vector> {
    /// <summary>
    /// Creates a deep copy of the vector.
    /// </summary>
    public virtual Vector CreateCopy() {
      return new Vector(VectorFunctions.Clone(this.InnerArray));
    }

    /// <summary>
    /// Creates a deep copy of the vector.
    /// </summary>
    public object Clone() {
      return CreateCopy();
    }

  }
}