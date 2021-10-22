using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legendary{
 public partial class frmMain:Form {
  public frmMain() {
   InitializeComponent();
  }

  private void frmMain_Load(object sender,EventArgs e) {
   string file=string.Empty;
   int option=-1;
   frmSplash f=new frmSplash();
   f.ShowDialog();
   file=f.Game;
   option=f.Option;
   f.Close();
   f=null;
   switch(option) {
   case -1:
    this.Close();
   break;
   case 1:
    FrmNewGame1 fng=new FrmNewGame1();
    fng.LoadGameOptions(file);
    fng.ShowDialog();
   break;
   }
  }
 }
}