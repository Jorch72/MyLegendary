using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 public enum Visibility{all=0,player=1,back=2,hidden=3}
 public enum Style{none=0,tile=1,tile34=2}
 public enum TileDir{right=0,left=1,top=2,bottom=3}
 public class clsZone{
  int xof=0,yof=0;
  public string Name{set;get;}
  public string Parent{set;get;}
  public clsPlayer Owner{set;get;}
  public int x{set;get;}
  public int y{set;get;}
  public int max{set;get;}
  public int width{set;get;}
  public int height{set;get;}
  public int power{set;get;}
  public clsZones container{set;get;}
  public int value{set;get;}
  public string text{set;get;}
  public bool isplayable{set;get;}
  public bool isbuyable{set;get;}
  public bool iskillable{set;get;}
  public bool isdiscardable{set;get;}
  public Visibility visibility{set;get;}
  public Style style{set;get;}
  public TileDir tiledir{set;get;}
  public int Count {
   get { return Cards.Count; }
  }
  public int rotate{set;get;}
  public clsZone Drawto{set;get;}
  public clsZone Discardto{set;get;}
  public clsZone Drawfrom{set;get;}
  public clsZone Refillfrom{set;get;}
  public System.Collections.ArrayList Cards=null;
  public System.Windows.Forms.PictureBox Pic{set;get;}
  public clsZone() {
   Cards=new System.Collections.ArrayList();
   rotate=0;
  }
  private System.Drawing.Color getColor(string color) {
   return System.Drawing.Color.Black;
  }
  public clsZone(System.Xml.XmlNode n,string picpath):this(){
   int v=0;
   Name=n.Name;
   max=500;
   foreach(System.Xml.XmlNode a in n.Attributes){
    bool bol;
    Int32.TryParse(a.Value,out v);
    switch(a.Name){
     case "x":
      x=v;
      if(Pic!=null&&Pic.Left!=x) Pic.Location=new System.Drawing.Point(x,y);
     break;
     case "y":
      y=v;
      if(Pic!=null&&Pic.Top!=y) Pic.Location=new System.Drawing.Point(x,y);
     break;
     case "power":
      power=v;
     break;
     case "width":
      width=v;
      if(Pic!=null&&Pic.Width!=width) Pic.Width=width;
     break;
     case "height":
      height=v;
      if(Pic!=null&&Pic.Height!=height) Pic.Height=height;
     break;
     case "img":
      Pic=new System.Windows.Forms.PictureBox();
      Pic.Location=new System.Drawing.Point(x,y);
      Pic.Height=height;
      Pic.Width=width;
      Pic.Visible=true;
      Pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      Pic.Load(picpath+a.Value);
     break;
     case "background":
      Pic=new System.Windows.Forms.PictureBox();
      Pic.BackColor=getColor(a.Value);
      Pic.Location=new System.Drawing.Point(x,y);
      Pic.Height=height;
      Pic.Width=width;
      Pic.Visible=true;
      Pic.SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
     break;
     case "cardvisible":
      Visibility vis;
      Enum.TryParse(a.Value,out vis);
      visibility=vis;
     break;
     case "style":
      Style styl;
      Enum.TryParse(a.Value,out styl);
      style=styl;
     break;
     case "max":max=v;break;
     case "text":text=a.Value;break;
     case "tiledir":
      TileDir p;
      Enum.TryParse(a.Value,out p);
      tiledir=p;
     break;
     case "rotate":rotate=v;break;
     case "playable":
      bol=false;
      bool.TryParse(a.Value,out bol);
      isplayable=bol;
     break;
     case "buyable":
      bol=false;
      bool.TryParse(a.Value,out bol);
      isbuyable=bol;
     break;
     case "killable":
      bol=false;
      bool.TryParse(a.Value,out bol);
      iskillable=bol;
     break;
     case "discardable":
      bol=false;
      bool.TryParse(a.Value,out bol);
      isdiscardable=bol;
     break;
    }
   }
   if(Pic!=null&&text!=null)Pic.Tag=text;
  }
  public clsZone(System.Xml.XmlNode n,string picpath,string Parent) : this(n,picpath) {
   this.Parent=Parent;
  }
  public void setDrawDiscard(System.Xml.XmlNode n,clsZones zones) {
   System.Xml.XmlNode a=n.Attributes.GetNamedItem("drawto");
   if(a!=null)Drawto=zones[a.Value];
   a=n.Attributes.GetNamedItem("discardto");
   if(a!=null)Discardto=zones[a.Value];
   a=n.Attributes.GetNamedItem("drawfrom");
   if(a!=null)Drawfrom=zones[a.Value];
   a=n.Attributes.GetNamedItem("refillfrom");
   if(a!=null)Refillfrom=zones[a.Value];
  }
  public void shuffle(){
   Random r=new Random();
   int randomIndex=0;
   for(int i = 0;i<10;i++){
    System.Collections.ArrayList ar = new System.Collections.ArrayList();
    while(Cards.Count>0) {
     randomIndex=r.Next(0,Cards.Count); //Choose a random object in the list
     ar.Add(Cards[randomIndex]); //add it to the new, random list
     Cards.RemoveAt(randomIndex); //remove to avoid duplicates
    }
    Cards.Clear();
    Cards=null;
    Cards=ar;
   }
  }
  public void addCard(clsCard c){
   System.Windows.Forms.ContextMenu cm=null;
   if(isplayable){
    cm=new System.Windows.Forms.ContextMenu();
    cm.MenuItems.Add("Play",new EventHandler(container.Container.frm.PlayCard));
    cm.MenuItems.Add("Play All",new EventHandler(container.Container.frm.PlayAllCards));
   } else if(isbuyable){
    cm=new System.Windows.Forms.ContextMenu();
    cm.MenuItems.Add("Buy",new EventHandler(container.Container.frm.BuyCard));
   }else if(iskillable){
    cm=new System.Windows.Forms.ContextMenu();
    cm.MenuItems.Add("Kill",new EventHandler(container.Container.frm.KillCard));
    cm.MenuItems.Add("Kill+1",new EventHandler(container.Container.frm.KKillCard));
   }
   c.CardFront.ContextMenu=cm;
   c.Owner=this.Owner;
   if(Cards.Count>=max)this.drawCard();
   c.Container=this;
   c.y=y;
   if(rotate!=0)c.Rotate();
   if(style==Style.tile||style==Style.tile34){
    switch(tiledir){
     case TileDir.right:
      c.x=x+xof;
      c.y=y;
      if(style==Style.tile34)xof+=72;
      else xof+=96;
      if(rotate!=0){
       c.height=height;
       c.width=width;
      }
     break;
     case TileDir.left:
      c.x=x-xof;
      c.y=y;
      if(style==Style.tile34) xof+=72;
      else xof+=99;
      c.height=height;
      //c.width=width;
     break;
     case TileDir.top:
      c.x=x;
      c.y=y-yof;
      yof+=15;
      if(rotate!=0){
       c.height=height;
       c.width=width;
      }
     break;
    }    
   }else{
    c.x=x;
    c.width=width;
    c.height=height;
   }
   //if(c.visible!=visibility){
   // c.Card.Visible=false;
   // c.Refresh();
   //}
   c.visible=visibility;
   c.Card.Visible=true;
   c.Card.BringToFront();
   c.Refresh();
   Cards.Add(c);
  }
  /*Ke pasa cuando se jalan varias cartas en el return*/
  public clsCard drawCard(int count=1){
   clsCard c=null;
   if(Cards.Count<count&&Refillfrom==null)throw new Exception("Tie!");
   if(Cards.Count==0){
    Refill();
    shuffle();
   }
   while(count-->0){
    c=(clsCard)Cards[0];
    Cards.RemoveAt(0);
    Drawto.addCard(c);
    if(Cards.Count==0){
     Refill();
     shuffle();
    }
   }
   return c; 
  }
  public void discardCard(int count=1){
   clsCard c;
   while(Cards.Count>0&&count-->0){
    /*arreglar bien xof*/
    xof-=96;
    if(xof<0)xof=0;
    c=(clsCard)Cards[0];
    Cards.RemoveAt(0);
    Discardto.addCard(c);
   }
   if(Cards.Count<=0)xof=0;
  }
  public void discardit(){
   discardCard(Cards.Count);
  }
  public void Refill(){
   if(Refillfrom!=null){
    Refillfrom.drawCard(Refillfrom.Cards.Count);
   }
  }
  public void Refresh(){
   foreach(clsCard c in Cards){
    c.Refresh();
   }
  }
 }
}