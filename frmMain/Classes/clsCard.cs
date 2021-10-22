using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 public class clsCard{
  public int ID{get;set;}
  public clsPlayer Owner{get;set;}
  public string Name{get;set;}
  public string img{get;set;}
  public string type{get;set;}
  public string subtype{get;set;}
  public string group{get;set;}
  public string skill{get;set;}
  public int cost{get;set;}
  public int power{get;set;}
  public int recruit{get;set;}
  public int value{get;set;}
  public string text{get;set;}
  public clsZone Container{get;set;}
  public Visibility visible{get;set;}
  public int x{
   get{return CardFront.Left;}
   set{CardFront.Left=value;CardBack.Left=value;}
  }
  public int y{
   get{return CardFront.Top;}
   set{CardFront.Top=value;CardBack.Top=value;}
  }
  public int width{
   get{return CardFront.Width;}
   set{CardFront.Width=value;CardBack.Width=value;}
  }
  public int height {
   get{return CardFront.Height;}
   set{CardFront.Height=value;CardBack.Height=value;}
  }
  public System.Windows.Forms.PictureBox Card{
   get{
    if(visible==Visibility.all||visible==Visibility.player)return CardFront;
    else return CardBack;
   }
  }
  public System.Windows.Forms.PictureBox CardFront;
  public System.Windows.Forms.PictureBox CardBack;
  public clsCard(){
   CardBack=new System.Windows.Forms.PictureBox();
   CardFront=new System.Windows.Forms.PictureBox();
  }
  public clsCard(System.Xml.XmlNode n,string picpath):this(){
   System.Xml.XmlNode cb=n.SelectSingleNode("//card[@name='CardBack']");
   Name=getAttributeValue(n,"name");
   img=getAttributeValue(n,"img");
   CardFront.SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
   CardFront.Load(picpath+img);
   CardFront.Visible=true;
   CardFront.Tag=this;
   if(cb!=null){
    CardBack.SizeMode=System.Windows.Forms.PictureBoxSizeMode.StretchImage;
    CardBack.Load(picpath+cb.Attributes.GetNamedItem("img").Value);
    CardBack.Visible=true;
   }
   value=getAttributeIntValue(n,"value");
   type=getAttributeValue(n,"type");
   subtype=getAttributeValue(n,"subtype");
   group=getAttributeValue(n,"group");
   skill=getAttributeValue(n,"skill");
   cost=getAttributeIntValue(n,"cost");
   power=getAttributeIntValue(n,"power");
   recruit=getAttributeIntValue(n,"recruit");
   text=getAttributeValue(n,"text");
  }
  public void Flip(){
   if(visible==Visibility.all||visible==Visibility.player)visible=Visibility.back;
   else if(visible==Visibility.back)visible=Visibility.all;
   if(Container!=null)Container.Refresh();
  }
  public void Rotate() {
   Card.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipXY);
  }
  public bool Ambush(){
   return true;
  }
  public bool Escape(){
   return true;
  }
  public void Refresh(){
   Card.Refresh();
  }
  public void KO(){
   Container.Cards.Remove(this);
   if(type=="Heroe"||type=="MasterStrike"||type=="SchemeTwist")Container.container.Container.Zones["ko"].addCard(this);
   else Container.container.Container.Zones["victorypile"].addCard(this);
   Refresh();
   Owner=null;
  }
  public void Play(){
   Container.Cards.Remove(this);
   Container.Drawto.addCard(this);
   Owner.Power+=power;
   Owner.Recruit+=recruit;
   Owner.Refresh();
  }
  /* Corregir que el container (=discard del jugador) tenga dueño*/
  public void Buy(){
   if(cost>Container.container.Container.GetActivePlayer().Recruit)return;
   Container.Cards.Remove(this);
   /*arreglar con zonas, se uso esto para que la carta nueva quede en el mismo lugar*/
   if(Container.Name=="hq"){
    clsCard c=Container.Drawfrom.drawCard();
    c.x=x;
    c.y=y;
   }
   Container.Drawto.addCard(this);
   Owner=Container.container.Container.GetActivePlayer();
   Owner.Recruit-=cost;
   Owner.Refresh();
  }
  public void Kill(bool overkill=false){
   int pow=Container.container.Container.GetActivePlayer().Power;
   if(power>pow)return;
   if(overkill&&power+1>pow)return;
   Container.Cards.Remove(this);
   this.KO();
   Owner=Container.container.Container.GetActivePlayer();
   Owner.Power-=power;
   if(overkill)Owner.Power--;
   Owner.VictoryPoints+=value;
   Owner.Refresh();
  }
  private string getAttributeValue(System.Xml.XmlNode n,string name){
   System.Xml.XmlNode a=n.Attributes.GetNamedItem(name);
   if(a==null)return null;
   return a.Value;
  }
  private int getAttributeIntValue(System.Xml.XmlNode n,string name){
   int v=-1;
   System.Xml.XmlNode a=n.Attributes.GetNamedItem(name);
   if(a==null)return 0;
   Int32.TryParse(a.Value,out v);
   return v;
  }
 }
}