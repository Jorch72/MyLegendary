namespace Legendary {
 partial class frmSplash {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
   if(disposing&&(components!=null)) {
    components.Dispose();
   }
   base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
   this.label1 = new System.Windows.Forms.Label();
   this.cboGames = new System.Windows.Forms.ComboBox();
   this.btnLoad = new System.Windows.Forms.Button();
   this.lblVersion = new System.Windows.Forms.Label();
   this.lblAuthor = new System.Windows.Forms.Label();
   this.btnNew = new System.Windows.Forms.Button();
   this.SuspendLayout();
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(23, 75);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(106, 20);
   this.label1.TabIndex = 0;
   this.label1.Text = "Select Game:";
   // 
   // cboGames
   // 
   this.cboGames.FormattingEnabled = true;
   this.cboGames.Location = new System.Drawing.Point(135, 72);
   this.cboGames.Name = "cboGames";
   this.cboGames.Size = new System.Drawing.Size(433, 28);
   this.cboGames.TabIndex = 1;
   this.cboGames.SelectedIndexChanged += new System.EventHandler(this.cboGames_SelectedIndexChanged);
   // 
   // btnLoad
   // 
   this.btnLoad.Location = new System.Drawing.Point(226, 469);
   this.btnLoad.Name = "btnLoad";
   this.btnLoad.Size = new System.Drawing.Size(81, 29);
   this.btnLoad.TabIndex = 2;
   this.btnLoad.Text = "Load";
   this.btnLoad.UseVisualStyleBackColor = true;
   this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
   // 
   // lblVersion
   // 
   this.lblVersion.AutoSize = true;
   this.lblVersion.Location = new System.Drawing.Point(268, 113);
   this.lblVersion.Name = "lblVersion";
   this.lblVersion.Size = new System.Drawing.Size(39, 20);
   this.lblVersion.TabIndex = 3;
   this.lblVersion.Text = "Text";
   this.lblVersion.Visible = false;
   // 
   // lblAuthor
   // 
   this.lblAuthor.AutoSize = true;
   this.lblAuthor.Location = new System.Drawing.Point(268, 156);
   this.lblAuthor.Name = "lblAuthor";
   this.lblAuthor.Size = new System.Drawing.Size(39, 20);
   this.lblAuthor.TabIndex = 4;
   this.lblAuthor.Text = "Text";
   this.lblAuthor.Visible = false;
   // 
   // btnNew
   // 
   this.btnNew.Location = new System.Drawing.Point(226, 193);
   this.btnNew.Name = "btnNew";
   this.btnNew.Size = new System.Drawing.Size(124, 50);
   this.btnNew.TabIndex = 5;
   this.btnNew.Text = "New &Game";
   this.btnNew.UseVisualStyleBackColor = true;
   this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
   // 
   // frmSplash
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
   this.ClientSize = new System.Drawing.Size(726, 519);
   this.ControlBox = false;
   this.Controls.Add(this.btnNew);
   this.Controls.Add(this.lblAuthor);
   this.Controls.Add(this.lblVersion);
   this.Controls.Add(this.btnLoad);
   this.Controls.Add(this.cboGames);
   this.Controls.Add(this.label1);
   this.Cursor = System.Windows.Forms.Cursors.Default;
   this.KeyPreview = true;
   this.MaximizeBox = false;
   this.MinimizeBox = false;
   this.Name = "frmSplash";
   this.ShowInTaskbar = false;
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Game Loader";
   this.TopMost = true;
   this.Load += new System.EventHandler(this.frmSplash_Load);
   this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSplash_KeyPress);
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.Label label1;
  private System.Windows.Forms.ComboBox cboGames;
  private System.Windows.Forms.Button btnLoad;
  private System.Windows.Forms.Label lblVersion;
  private System.Windows.Forms.Label lblAuthor;
  private System.Windows.Forms.Button btnNew;
 }
}