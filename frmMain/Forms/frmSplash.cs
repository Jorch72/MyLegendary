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
 public partial class frmSplash:Form {
  public string Game;
  public int Option=-1;
  public frmSplash() {
   InitializeComponent();
  }

  private void frmSplash_Load(object sender,EventArgs e){
   clsitem itm=null;
   System.Xml.XmlNode tit=null;
   System.Xml.XmlNodeList nl=null;
   System.Xml.XmlDocument doc=new System.Xml.XmlDocument(),inf=new System.Xml.XmlDocument();
   doc.Load(Application.StartupPath+"\\Data\\Game.xml");
   nl=doc.SelectNodes("/xml/Game");
   foreach(System.Xml.XmlNode n in nl){
    itm=new clsitem();
    tit=n.SelectSingleNode("title");
    itm.Name=tit.InnerText;
    tit=n.SelectSingleNode("data");
    if(tit!=null){
     itm.Value=tit.InnerText;
     inf.Load(Application.StartupPath+tit.InnerText);
     tit=inf.SelectSingleNode("/xml/Game/title");
     itm.Version=tit.Attributes.GetNamedItem("version").Value;
     itm.Img=Application.StartupPath+tit.Attributes.GetNamedItem("splash").Value;
     itm.Author=inf.SelectSingleNode("/xml/Game/author").InnerText;
    }
    cboGames.Items.Add(itm);
   }
   doc=null;
  }

  private void cboGames_SelectedIndexChanged(object sender,EventArgs e){
   clsitem itm=(clsitem)cboGames.SelectedItem;
   if(itm.Img!=null&&itm.Img!=string.Empty){
    Image img=System.Drawing.Image.FromFile(itm.Img);
    this.BackgroundImage=img;
   }
   if(itm.Author!=string.Empty){
    lblAuthor.Text="Author: "+itm.Author;
    lblAuthor.Visible=true;
   }
   if(itm.Version!=string.Empty){
    lblVersion.Text="Version: "+itm.Version;
    lblVersion.Visible=true;
   }
  }

  private void btnLoad_Click(object sender,EventArgs e){
   if(cboGames.SelectedIndex==-1)return;
   Game=((clsitem)cboGames.SelectedItem).Value;
   this.Hide();
  }

  private void btnNew_Click(object sender,EventArgs e){
   if(cboGames.SelectedIndex==-1)return;
   Game=((clsitem)cboGames.SelectedItem).Name;
   Option=1;
   this.Hide();
  }

  private void frmSplash_KeyPress(object sender,KeyPressEventArgs e){
   if(e.KeyChar==27)this.Hide();
  }
 }
}