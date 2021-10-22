using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary{
 [System.Runtime.InteropServices.ComVisible(true)]
 public class clsGame{
  public string Name;
  public string Version;
  public string Path;
  public int Turn;
  public frmGame frm=null;
  private System.Collections.ArrayList Players=null;
  public clsZones Zones=null;
  public System.Xml.XmlDocument doc=null;
  public clsGame(){
   Players=new System.Collections.ArrayList();
   Turn=0;
  }
  public clsGame(frmGame frm,string gamepath,string AppPath):this(){
   this.frm=frm;
   Path=AppPath;
   doc=new System.Xml.XmlDocument();
   doc.Load(gamepath);
   Name=doc.SelectSingleNode("/xml/Game/title").InnerText;
   Version=doc.SelectSingleNode("/xml/Game/title").Attributes.GetNamedItem("version").Value;
   Zones=new clsZones(this);
   Zones.LoadAll();
  }
  public void AddPlayer(string Name){
   clsPlayer p=new clsPlayer(Name,this);
   Players.Add(p);
  }
  public void EndTurn(){   
   GetActivePlayer().EndTurn();
   Turn++;
   SetNextPlayer();
   Zones["villaindeck"].drawCard();
  }

  /*----------- Fix these! -----------*/
  public clsPlayer GetPlayer(string Name){
   return (clsPlayer)Players[0];
  }
  public clsPlayer GetActivePlayer(){
   return (clsPlayer)Players[0];
  }
  public clsPlayer SetNextPlayer(){
   return (clsPlayer)Players[0];
  }
  public clsPlayer GetPlayerToRightof(string Name){
   return (clsPlayer)Players[0];
  }
  public clsPlayer GetPlayerToLeftof(string Name) {
   return (clsPlayer)Players[0];
  }
 }
}
