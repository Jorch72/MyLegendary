using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 public class clsitem{
  public string Name { get; set; }
  public string Value { get; set; }
  public string Img { get; set; }
  public string Version { get; set; }
  public string Author { get; set; }
  public clsitem(string name,string value){
   Name=name;
   Value=value;
  }
  public clsitem() {
  }
  public override string ToString() {
   return Name;
  }
 }
}