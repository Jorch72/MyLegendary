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
 public partial class FrmNewGame1:Form {
  private System.Windows.Forms.CheckBox chkExp=null;
  private int TI=3,chky=25,chkx=15;
  public System.Collections.ArrayList Expansions=null,Masterminds=null,Schemes=null,Villains=null,Henchmen=null,Heroes=null;
  string coreData;

  public FrmNewGame1() {
   InitializeComponent();
  }

  private void gpReset(){
   TI=3;
   chky=25;
   chkx=15;
  }
  private void addChk(string Name,bool Enabled,string data,GroupBox gp,bool check){
   chkExp=new CheckBox();
   this.chkExp.Enabled=Enabled;
   gp.Controls.Add(this.chkExp);
   this.chkExp.AutoSize=true;
   this.chkExp.Location=new System.Drawing.Point(chkx,chky);
   chky+=20;
   if(chky>grpBx1.Height-10){
    chky=25;
    chkx+=170;
   }
   this.chkExp.Name="chkExp";
   this.chkExp.Size=new System.Drawing.Size(68,24);
   this.chkExp.TabIndex=TI++;
   this.chkExp.Text=Name;
   this.chkExp.Tag=data;
   this.chkExp.UseVisualStyleBackColor=true;
   this.chkExp.Checked=check;
  }
  private void addChk(string Name,bool Enabled,string data,GroupBox gp) {
   addChk(Name,Enabled,data,gp,false);
  }
  private void chkAllExp_CheckedChanged(object sender,EventArgs e) {
   CheckBox chk=null;
   GroupBox gb=null;
   if(grpBx0.Visible)return;
   if(grpBx1.Visible)gb=grpBx1;
   if(grpBx2.Visible)gb=grpBx2;
   if(grpBx3.Visible)gb=grpBx3;
   if(grpBx4.Visible)gb=grpBx4;
   if(grpBx5.Visible)gb=grpBx5;
   if(grpBx6.Visible)gb=grpBx6;
   foreach(Control c in gb.Controls){
    try{
     chk=(CheckBox)c;
     if(chk.Enabled)chk.Checked=chkAllExp.Checked;
    }catch{};
   }
  }
  private void SetupGPMasterMind(){
   CheckBox chk = null;
   clsitem itm = null;
   System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
   System.Xml.XmlNodeList nl = null;
   bool enabled = true;
   this.Expansions=new System.Collections.ArrayList();
   gpReset();
   foreach(Control c in grpBx1.Controls) {
    chk=(CheckBox)c;
    if(chk.Checked) {
     itm=new clsitem(chk.Text,(string)chk.Tag);
     Expansions.Add(itm);
     doc.Load(Application.StartupPath+itm.Value);
     nl=doc.SelectNodes("/xml/Cards/set/masterminds/card");
     Label lbl = new Label();
     lbl.Text=itm.Name+":";
     lbl.Location=new Point(4,12);
     lbl.AutoSize=true;
     grpBx2.Controls.Add(lbl);
     foreach(System.Xml.XmlNode n in nl) {
      addChk(n.Attributes["name"].Value,enabled,n.Attributes["group"].Value,grpBx2);
     }
    }
   }
   grpBx1.Visible=false;
   grpBx2.Visible=true;
   this.Text="Choose Mastermind";
   doc=null;
  }
  private void SetupGPSchemes(){
   System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
   System.Xml.XmlNodeList nl=null;
   bool enabled=true;
   gpReset();
   Masterminds=new System.Collections.ArrayList();
   foreach(Control c in grpBx2.Controls){
    if(c is CheckBox)Masterminds.Add(new clsitem(c.Text,(string)c.Tag));
   }

   foreach(clsitem c in this.Expansions){
    doc.Load(Application.StartupPath+c.Value);
    nl=doc.SelectNodes("/xml/Cards/set/schemes/card");
    Label lbl = new Label();
    lbl.Text=c.Name+":";
    lbl.Location=new Point(4,12);
    lbl.AutoSize=true;
    grpBx3.Controls.Add(lbl);
    foreach(System.Xml.XmlNode n in nl) {
     addChk(n.Attributes["name"].Value,enabled,null,grpBx3);
    }
   }
   grpBx2.Visible=false;
   grpBx3.Visible=true;
   doc=null;
   this.Text="Choose Scheme";
  }
  private void SetupGPVillains(){
   System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
   System.Xml.XmlNodeList nl=null;
   System.Collections.Generic.Dictionary<string,string> Dic = new Dictionary<string,string>();
   bool enabled = true,found=false;
   gpReset();
   foreach(clsitem c in this.Expansions){
    doc.Load(Application.StartupPath+c.Value);
    nl=doc.SelectNodes("/xml/Cards/set/villains/card");
    Label lbl = new Label();
    lbl.Text=c.Name+":";
    lbl.Location=new Point(4,12);
    lbl.AutoSize=true;
    grpBx4.Controls.Add(lbl);
    foreach(System.Xml.XmlNode n in nl){
     if(!Dic.ContainsKey(n.Attributes["group"].Value))Dic.Add(n.Attributes["group"].Value,n.Attributes["group"].Value);
    }
    foreach(KeyValuePair<string,string> kvp in Dic){
     found=false;
     foreach(clsitem grp in Masterminds){
      if(kvp.Value==grp.Value){
       addChk(kvp.Value,false,null,grpBx4,true);
       found=true;
       break;
      }
     }
     if(!found)addChk(kvp.Value,enabled,null,grpBx4);
    }    
   }
   grpBx3.Visible=false;
   grpBx4.Visible=true;
   doc=null;
   Dic=null;
   this.Text="Choose Villains";
  }
  private void SetupGPHenchmen(){
   System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
   System.Xml.XmlNodeList nl=null;
   System.Collections.Generic.Dictionary<string,string> Dic=new Dictionary<string,string>();
   bool enabled=true,found=false;
   gpReset();
   foreach(clsitem c in this.Expansions){
    doc.Load(Application.StartupPath+c.Value);
    nl=doc.SelectNodes("/xml/Cards/set/henchmen/card");
    Label lbl = new Label();
    lbl.Text=c.Name+":";
    lbl.Location=new Point(4,12);
    lbl.AutoSize=true;
    grpBx5.Controls.Add(lbl);
    foreach(System.Xml.XmlNode n in nl) {
     if(!Dic.ContainsKey(n.Attributes["group"].Value))Dic.Add(n.Attributes["group"].Value,n.Attributes["group"].Value);
    }
    foreach(KeyValuePair<string,string> kvp in Dic) {
     found=false;
     foreach(clsitem grp in Masterminds) {
      if(kvp.Value==grp.Value) {
       addChk(kvp.Value,false,null,grpBx5,true);
       found=true;
       break;
      }
     }
     if(!found)addChk(kvp.Value,enabled,null,grpBx5);
    }
   }
   grpBx4.Visible=false;
   grpBx5.Visible=true;
   doc=null;
   Dic=null;
   this.Text="Choose Henchman";
  }
  private void SetupGPHeroes(){
   System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
   System.Xml.XmlNodeList nl = null;
   System.Collections.Generic.Dictionary<string,string> Dic = new Dictionary<string,string>();
   string name;
   gpReset();
   foreach(clsitem c in this.Expansions){
    doc.Load(Application.StartupPath+c.Value);
    nl=doc.SelectNodes("/xml/Cards/set/heroes/card");
    Label lbl=new Label();
    lbl.Text=c.Name+":";
    lbl.Location=new Point(4,12);
    lbl.AutoSize=true;
    grpBx6.Controls.Add(lbl);
    foreach(System.Xml.XmlNode n in nl) {
     name=n.Attributes["name"].Value;
     name=name.Substring(name.IndexOf(" - ")+3);
     if(!Dic.ContainsKey(name))Dic.Add(name,n.Attributes["name"].Value);
    }
    foreach(KeyValuePair<string,string> kvp in Dic){
     addChk(kvp.Key,true,kvp.Value,grpBx6);
    }
   }
   grpBx5.Visible=false;
   grpBx6.Visible=true;
   doc=null;
   this.Text="Choose Heroes";
  }
  private void btnNxt_Click(object sender,EventArgs e){
   if(grpBx0.Visible){
    grpBx0.Visible=false;
    grpBx1.Visible=true;
    chkAllExp.Checked=false;
    return;
   }
   if(grpBx1.Visible){
    SetupGPMasterMind();
    chkAllExp.Checked=false;
    return;
   }
   if(grpBx2.Visible){
    SetupGPSchemes();
    chkAllExp.Checked=false;
    return;
   }
   if(grpBx3.Visible){
    SetupGPVillains();
    chkAllExp.CheckState=CheckState.Unchecked;
    return;
   }
   if(grpBx4.Visible){
    SetupGPHenchmen();
    chkAllExp.CheckState=CheckState.Unchecked;
    return;
   }
   if(grpBx5.Visible){
    SetupGPHeroes();
    chkAllExp.CheckState=CheckState.Unchecked;
    return;
   }
  }

  public void LoadGameOptions(string Game) {
   System.Xml.XmlNode nod=null;
   System.Xml.XmlNodeList nl=null;
   System.Xml.XmlDocument doc=new System.Xml.XmlDocument();
   GroupBox GB=null;
   RadioButton rad=null;
   CheckBox cb=null;
   ComboBox cbo=null;
   bool enabled=false;
   string data;
   int min,max,gby;
   doc.Load(Application.StartupPath+"\\Data\\Game.xml");
   nl=doc.SelectNodes("/xml/Game");
   //Find chosen game in list
   foreach(System.Xml.XmlNode n in nl){
    nod=n.SelectSingleNode("data");
    if(nod!=null)coreData=nod.InnerText;
    else coreData=string.Empty;
    nod=n.SelectSingleNode("title");
    if(nod!=null&&nod.InnerText==Game){
     nod=n;
     break;
    }
   }
   if(nod!=null){
    nl=nod.SelectNodes("Expansions/Expansion");
    foreach(System.Xml.XmlNode n in nl){
     data=string.Empty;
     enabled=(n.Attributes["data"]!=null);
     if(enabled)data=n.Attributes["data"].Value;
     addChk(n.Attributes["title"].Value,enabled,data,grpBx1);
    }
   }
   chky=10;
   chkx=10;
   //load Options
   enabled=true;
   doc.Load(Application.StartupPath+coreData);
   nod=doc.SelectSingleNode("/xml/Game/Setup");
   min=Convert.ToInt32(nod.Attributes["minPlayers"].Value);
   max=Convert.ToInt32(nod.Attributes["maxPlayers"].Value);
   for(int i=min;i<=max;i++)cboPlayers.Items.Add(i);
   cboPlayers.SelectedIndex=0;
   gby=cboPlayers.Top+cboPlayers.Height+10;
   nl=nod.SelectNodes("ChallengeMode/Challenge");
   foreach(System.Xml.XmlNode n in nl){
    data=n.Attributes["type"].Value;
    switch(data){
     case "radio":
      rad=new RadioButton();
      rad.Left=chkx;
      rad.Top=chky;
      chky+=5;
      if(n.Attributes["Selected"]!=null)rad.Checked=true;
      rad.Text=n.Attributes["Name"].Value;
      rad.Name="r"+n.Attributes["id"].Value;
      rad.AutoSize=true;
      data="GB"+n.Attributes["id"].Value;
      if(GB==null){
       GB=new GroupBox();
       GB.Top=gby;
       GB.Left=5;
       GB.Name=data;
       GB.AutoSize=true;
       grpBx0.Controls.Add(GB);
      }
      if(GB.Name!=data){
       gby+=GB.Height+5;
       GB=new GroupBox();
       chky=10;
       rad.Top=chky;
       GB.Left=5;
       GB.Top=gby;
       GB.Name=data;
       GB.AutoSize=true;
       grpBx0.Controls.Add(GB);
      }
      GB.Controls.Add(rad);

      //if(n.Attributes.Count>2)data=n.Attributes[1].Name+"="+n.Attributes[1].Value;
      //else data=string.Empty;
      
      //grpBx0.Controls.Add(rad);
     break;
     case "cbo":
      data="cbo"+n.Attributes["id"].Value;
      if(cbo==null){
       cbo=new ComboBox();
       cbo.Top=gby+190;
       cbo.Left=chkx;
       cbo.Name=data;
       cbo.AutoSize=true;
       grpBx0.Controls.Add(cbo);
      }
      if(cbo.Name!=data){
       return;
       gby+=GB.Height+5;
       GB=new GroupBox();
       chky=10;
       rad.Top=chky;
       GB.Left=5;
       GB.Top=gby;
       GB.Name=data;
       GB.AutoSize=true;
       grpBx0.Controls.Add(cbo);
      }
      cbo.Items.Add(n.Attributes["Name"].Value);
      if(n.Attributes["Selected"]!=null)cbo.SelectedIndex=cbo.Items.Count-1;
      
    break;
     case "checkbox":
      cb=new CheckBox();
      cb.Left=chkx;
      cb.Top=chky;
      cb.Text=n.Attributes["Name"].Value;
      cb.AutoSize=true;
      grpBx0.Controls.Add(cb);
    break;
    }
    chky+=20;
    if(chky>grpBx1.Height-10){
     chky=25;
     chkx+=170;
    }
    //addChk(n.Attributes["Name"].Value,enabled,data,grpBx0);
   }
   doc=null;
  }
  private void FrmNewGame_Load(object sender,EventArgs e) {
  }
 }
}