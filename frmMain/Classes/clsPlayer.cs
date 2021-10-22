using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 [System.Runtime.InteropServices.ComVisible(true)]
 public class clsPlayer{
  public string Name{get;set;}
  public clsGame Owner;
  public int Power;
  public int Recruit;
  public int VictoryPoints;
  public clsZone Hand=null;
  public clsZone Play=null;
  public clsZone Deck=null;
  public clsZone Discard=null;
  public clsZone VictoryPile=null;
  private System.Windows.Forms.Label lblDispResources=null;
  public clsPlayer(){
   Power=0;
   Recruit=0;
   VictoryPoints=0;
   lblDispResources=new System.Windows.Forms.Label();
   lblDispResources.Text="Power: "+Power+" / Recruit: "+Recruit;
   lblDispResources.AutoSize=true;
   lblDispResources.Left=1055;
   lblDispResources.Top=10;
  }
  public clsPlayer(string Name,clsGame Owner):this(){
   this.Name=Name;
   this.Owner=Owner;
   if(Owner!=null)Owner.frm.Controls.Add(lblDispResources);
  }
  public void EndTurn(){
   Owner.frm.SuspendLayout();
   /*porque chingados no sirve con 1 numero??*/
   //while(Hand.Count>0)
   Hand.discardCard(Hand.Count);
   //while(Play.Count>0)
   Play.discardCard(Play.Count);
   //for(int i=0;i<6;i++)Deck.drawCard();
   //Hand.discardCard();
   //Hand.discardit();
   //Play.discardit();
   Deck.drawCard(6);
   Owner.frm.ResumeLayout(false);
   Owner.frm.PerformLayout();
   Power=0;
   Recruit=0;
   Refresh();
  }
  public void Refresh(){
   lblDispResources.Text="Power: "+Power+" / Recruit: "+Recruit+" / Victory: "+VictoryPoints;
   lblDispResources.Refresh();
  }

  public void Print(){
   System.Windows.Forms.MessageBox.Show(Name);
  }
 }
}