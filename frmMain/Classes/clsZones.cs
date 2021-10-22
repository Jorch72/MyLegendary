using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 public class clsZones:IEnumerable<clsZone>{
  public clsGame Container;
  public IEnumerator<clsZone> GetEnumerator() {
   for(int i = 0;i<Values.Count;++i)
    yield return (clsZone)Values.ElementAt(i).Value;
  }
  IEnumerator IEnumerable.GetEnumerator() {
   return GetEnumerator();
  }
  public clsZones() {
   this.Values=new Dictionary<string,clsZone>();
  }
  public clsZones(clsGame Container):this(){
   this.Container=Container;
  }
  public Dictionary<string,clsZone> Values {
   get;
   set;
  }
  public clsZone this[string name]{
   get {return Values[name];}
  }
  public void Add(clsZone z){
   Values.Add(z.Name,z);
   z.container=this;
  }
  public void AddCard2Zone(string zonename,string cardname){
   System.Xml.XmlNode c=null;
   System.Xml.XmlDocument doc=Container.doc;
   int cnt=1;
   if(cardname==null)return;
   c=doc.SelectSingleNode("//card[@name='"+cardname+"']");
   string p=Container.Path+doc.SelectSingleNode("/xml/Cards/set/@path").Value;
   if(c.Attributes.GetNamedItem("count")!=null)cnt=Convert.ToInt32(c.Attributes.GetNamedItem("count").Value);
   for(int i=0;i<cnt;i++){
    clsCard card=new clsCard(c,p);
    Container.frm.Controls.Add(card.CardFront);
    Container.frm.Controls.Add(card.CardBack);
    Values[zonename].addCard(card);
    card.Card.BringToFront();
    card.Card.Refresh();
    card.CardFront.MouseDown+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseDown);
    card.CardFront.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseMove);
    card.CardFront.MouseUp+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseUp);
    card.CardBack.Tag=card;
    card.CardBack.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MM_Count);
   }
  }
  public void AddCard2Zone(string zonename,string group,string type,int count=-1){
   System.Xml.XmlNodeList nl=null;
   System.Xml.XmlDocument doc=Container.doc;
   string xpath=string.Empty;
   int cnt=1;
   if(group==null)return;
   if(count==-1)count=100;
   xpath="//card[";
   if(group!=string.Empty){
    xpath+="@group='"+group+"'";
    if(type!=string.Empty)xpath+=" and ";
   }
   if(type!=string.Empty){
    xpath+="@type='"+type+"']";
   }
   nl=doc.SelectNodes(xpath);
   string p=Container.Path+doc.SelectSingleNode("/xml/Cards/set/@path").Value;
   foreach(System.Xml.XmlNode c in nl){
    if(c.Attributes.GetNamedItem("count")!=null)cnt=Convert.ToInt32(c.Attributes.GetNamedItem("count").Value);
    else cnt=1;
    for(int i=0;i<cnt;i++){
     clsCard card=new clsCard(c,p);
     Container.frm.Controls.Add(card.CardFront);
     Container.frm.Controls.Add(card.CardBack);
     Values[zonename].addCard(card);
     card.Card.BringToFront();
     card.Card.Refresh();
     card.CardFront.MouseDown+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseDown);
     card.CardFront.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseMove);
     card.CardFront.MouseUp+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseUp);
     card.CardBack.Tag=card;
     card.CardBack.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MM_Count);
    }
    count--;
    if(count==0)break;
   }
  }
  public void LoadDeck(string name,int playerid){
   System.Xml.XmlNode d=null,c;
   System.Xml.XmlDocument doc=Container.doc;
   string zonename=string.Empty,xpath=string.Empty;
   if(name==null)return;
   d=doc.SelectSingleNode("//deck[@name='"+name+"']");
   zonename=d.Attributes.GetNamedItem("loadto").Value;
   string p=Container.Path+doc.SelectSingleNode("/xml/Cards/set/@path").Value;
   foreach(System.Xml.XmlNode n in d.ChildNodes){
    for(int i=0;i<Convert.ToInt32(n.Attributes.GetNamedItem("count").Value);i++){
     xpath="//card[@name='"+n.Attributes.GetNamedItem("name").Value+"' and @type!='"+n.Attributes.GetNamedItem("type").Value+"']";
     c=doc.SelectSingleNode(xpath);
     if(c==null)continue;
     clsCard card=new clsCard(c,p);
     Container.frm.Controls.Add(card.CardFront);
     Container.frm.Controls.Add(card.CardBack);
     Values[zonename].addCard(card);
     card.Card.BringToFront();
     card.Card.Refresh();
     card.CardFront.MouseDown+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseDown);
     card.CardFront.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseMove);
     card.CardFront.MouseUp+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MouseUp);
     card.CardBack.MouseMove+=new System.Windows.Forms.MouseEventHandler(Container.frm.Card_MM_Count);
     card.CardBack.Tag=card;
     if(Values[zonename].isplayable){
      System.Windows.Forms.ContextMenu cm=new System.Windows.Forms.ContextMenu();
      cm.MenuItems.Add("Play",new EventHandler(Container.frm.PlayCard));
      card.CardFront.ContextMenu=cm;
     }
    }
   }
  }
  public void LoadAll(){
   System.Xml.XmlDocument doc=Container.doc;
   System.Xml.XmlNode z=doc.SelectSingleNode("/xml/Zones");
   foreach(System.Xml.XmlNode n in z.ChildNodes){
    clsZone nzon=new clsZone(n,Container.Path);
    Add(nzon);
    if(n.ChildNodes.Count>0){
     foreach(System.Xml.XmlNode ch in n.ChildNodes){
      Add(new clsZone(ch,Container.Path,n.Name));
     }
    }
   }
   foreach(System.Xml.XmlNode n in z.ChildNodes){
    Values[n.Name].setDrawDiscard(n,this);
    if(n.ChildNodes.Count>0){
     foreach(System.Xml.XmlNode ch in n.ChildNodes){
      Values[ch.Name].setDrawDiscard(ch,this);
     }
    }
   }
   foreach(clsZone zo in this){
    if(zo.Pic!=null){
     Container.frm.Controls.Add(zo.Pic);
     if(zo.Name=="playmat")zo.Pic.SendToBack();
     else zo.Pic.BringToFront();
     zo.Pic.Refresh();
    }
   }  
  }
  /*  --------  Arreglar lo del owner ----*/
  public void DiscardAll(clsPlayer Player){
   foreach(clsZone z in this){
    //z.Owner.Equals(Player)&&
    if(z.isdiscardable)z.discardit();
   }
  }
 }
}