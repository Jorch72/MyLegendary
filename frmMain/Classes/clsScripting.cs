using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 [System.Runtime.InteropServices.ComVisible(true)]
 public class StringWrapper{
  private string wrappedString;
  public StringWrapper(string value) {
   wrappedString=value;
  }
  public override string ToString() {
   return wrappedString;
  }
 }
}