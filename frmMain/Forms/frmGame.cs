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
 public partial class frmGame:Form{
  private int _xPos;
  private int _yPos;
  private bool _dragging;
  private PictureBox CardActive=null;
  System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
  clsGame Game=null;

  public frmGame() {
   InitializeComponent();
  }

  public void Card_MouseDown(object sender,MouseEventArgs e) {
   if(e.Button!=MouseButtons.Left)return;
   _dragging=true;
   _xPos=e.X;
   _yPos=e.Y;
   var c=sender as PictureBox;
   c.BringToFront();
  }    
  public void Card_MouseUp(object sender,MouseEventArgs e) {
   var c = sender as PictureBox;
   if(null==c)return;
   _dragging=false;
  }
  public void Card_MouseMove(object sender,MouseEventArgs e) {
   var c=sender as PictureBox;
   CardActive=c;
   if(CardActive.Tag!=Game.Zones["detail"].Pic.Tag){
    Game.Zones["detail"].Pic.Tag=CardActive.Tag;
    Game.Zones["detail"].Pic.Load(CardActive.ImageLocation);
    return;
   }
   clsZone z=((clsCard)CardActive.Tag).Container;
   lblCountCards.Visible=true;
   lblCountCards.Left=z.x+z.width;
   lblCountCards.Top=z.y+z.height/2;
   lblCountCards.Text=z.Count.ToString();
   timHideCount.Enabled=true;
   if(!_dragging||null==c)return;
   c.Top=e.Y+c.Top-_yPos;
   c.Left=e.X+c.Left-_xPos;
  }
  public void Card_MM_Count(object sender,MouseEventArgs e) {
   var c=sender as PictureBox;
   if(c.Tag==null)return;
   clsZone z=((clsCard)c.Tag).Container;
   lblCountCards.Visible=true;
   lblCountCards.Left=z.x+z.width;
   lblCountCards.Top=z.y+z.height/2;
   lblCountCards.Text=z.Count.ToString();
   timHideCount.Enabled=true;
  }

  public void PlayCard(object sender,EventArgs e){
   if(CardActive==null)return;
   clsCard c=(clsCard)CardActive.Tag;
   c.Play();
  }
  public void PlayAllCards(object sender,EventArgs e) {
   if(CardActive==null) return;
   clsCard c=(clsCard)CardActive.Tag;
   c.Play();
  }
  public void BuyCard(object sender,EventArgs e){
   if(CardActive==null)return;
   clsCard c=(clsCard)CardActive.Tag;
   c.Buy();
  }
  public void KillCard(object sender,EventArgs e){
   if(CardActive==null)return;
   clsCard c=(clsCard)CardActive.Tag;
   c.Kill();
  }
  public void KKillCard(object sender,EventArgs e) {
   if(CardActive==null) return;
   clsCard c=(clsCard)CardActive.Tag;
   c.Kill(true);
  }

  public void LoadGame(string file){
   Game=new clsGame(this,file,Application.StartupPath);
   Game.AddPlayer("Jorge");
   this.Text="Cyberark Tester"; //Game.Name;

   MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
   sc.Language="VBScript";
   sc.AllowUI=true;
   StringWrapper tst = new StringWrapper("Sub Mio()\r\n"+
    "dim i\r\n"+
    " i=1\r\n"+
    " i=i+1\r\n"+
    " msgbox \"Valore:\"&i\r\n"+
    " Game.GetActivePlayer.Print()\r\n"+
    "End Sub");

   sc.AddCode(tst.ToString());
   sc.AddObject("Game",Game);

   //sc.Run("Mio");
   //sc.ExecuteStatement("msgbox \"hi\" ");

   //Fix This should be in the setp
   Game.GetActivePlayer().Hand=Game.Zones["hand"];
   Game.GetActivePlayer().Play=Game.Zones["play"];
   Game.GetActivePlayer().Deck=Game.Zones["deck"];
   Game.GetActivePlayer().Discard=Game.Zones["discard"];
   Game.GetActivePlayer().VictoryPile=Game.Zones["victorypile"];

   Game.Zones["deck"].Owner=Game.GetPlayer("Jorge");
   Game.Zones["play"].Owner=Game.GetPlayer("Jorge");
   Game.Zones["hand"].Owner=Game.GetPlayer("Jorge");
   Game.Zones["discard"].Owner=Game.GetPlayer("Jorge");
   Game.Zones["victorypile"].Owner=Game.GetPlayer("Jorge");

   Game.Zones.AddCard2Zone("bystanders","Bystander");
   Game.Zones.AddCard2Zone("wounds","Wound");
   Game.Zones.AddCard2Zone("heroedeck","Avengers","Heroe",3*4);
   Game.Zones["heroedeck"].shuffle();

   Game.Zones.AddCard2Zone("villaindeck","Brotherhood","Villain");
   Game.Zones.AddCard2Zone("villaindeck","Hand Ninja","Villain");
   Game.Zones.AddCard2Zone("villaindeck","Master Strike");
   Game.Zones.AddCard2Zone("villaindeck","Bystander","Bystander",1);
   Game.Zones["villaindeck"].shuffle();

   Game.Zones.AddCard2Zone("shield","S.H.I.E.L.D. Officer - Maria Hill");
   Game.Zones.AddCard2Zone("scheme","Midtown Bank Robbery");

   Game.Zones["heroedeck"].drawCard(5);
   Game.Zones["villaindeck"].drawCard();
   Game.Zones.LoadDeck("startup",0);
   Game.Zones["deck"].shuffle();
   Game.Zones["deck"].drawCard(6);

   Game.Zones.AddCard2Zone("mastermind",string.Empty,"Mastermind",1);
   this.Refresh();
   //timTimer.Enabled=true;
   Game.GetActivePlayer().Refresh();
   btnEndTurn.Visible=true;
   btnEndTurn.BringToFront();
   btnEndTurn.Show();
  }
  private void frmMain_Load(object sender,EventArgs e){
  }

  private void btnEndTurn_Click(object sender,EventArgs e){
   Game.EndTurn();
  }

  private void btnDebug_Click(object sender,EventArgs e){
   System.Text.StringBuilder sb=new StringBuilder();
   frmDebug frm=new frmDebug();
   clsPlayer p=Game.GetActivePlayer();
   sb.AppendLine(string.Format("Cards in Deck ({0}):",p.Deck.Cards.Count));
   foreach(clsCard c in p.Deck.Cards){
    sb.AppendLine(" Name:"+c.Name+" X: "+c.x+" Y:"+c.y);
   }
   sb.AppendLine(string.Format("Cards in Discard ({0}):",p.Discard.Cards.Count));
   foreach(clsCard c in p.Discard.Cards){
    sb.AppendLine(" Name:"+c.Name+" X: "+c.x+" Y:"+c.y);
   }
   sb.AppendLine(string.Format("Cards in Hand ({0}):",p.Hand.Cards.Count));
   foreach(clsCard c in p.Hand.Cards) {
    sb.AppendLine(" Name:"+c.Name+" X: "+c.x+" Y:"+c.y);
   }
   sb.AppendLine(string.Format("Cards in Play ({0}):",p.Play.Cards.Count));
   foreach(clsCard c in p.Play.Cards){
    sb.AppendLine(" Name:"+c.Name+" X: "+c.x+" Y:"+c.y);
   }
   frm.txtDebug.Text=sb.ToString();
   frm.Show();
  }

  private void timHideCount_Tick(object sender,EventArgs e){
   lblCountCards.Visible=false;
   timHideCount.Enabled=false;
  }
 }
}