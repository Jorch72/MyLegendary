namespace Legendary {
 partial class FrmNewGame1 {
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
   this.chkAllExp = new System.Windows.Forms.CheckBox();
   this.grpBx1 = new System.Windows.Forms.GroupBox();
   this.btnNxt = new System.Windows.Forms.Button();
   this.grpBx2 = new System.Windows.Forms.GroupBox();
   this.grpBx3 = new System.Windows.Forms.GroupBox();
   this.grpBx4 = new System.Windows.Forms.GroupBox();
   this.grpBx5 = new System.Windows.Forms.GroupBox();
   this.grpBx6 = new System.Windows.Forms.GroupBox();
   this.grpBx0 = new System.Windows.Forms.GroupBox();
   this.cboPlayers = new System.Windows.Forms.ComboBox();
   this.label1 = new System.Windows.Forms.Label();
   this.grpBx0.SuspendLayout();
   this.SuspendLayout();
   // 
   // chkAllExp
   // 
   this.chkAllExp.AutoSize = true;
   this.chkAllExp.Location = new System.Drawing.Point(27, 12);
   this.chkAllExp.Name = "chkAllExp";
   this.chkAllExp.Size = new System.Drawing.Size(52, 24);
   this.chkAllExp.TabIndex = 0;
   this.chkAllExp.Text = "&All";
   this.chkAllExp.UseVisualStyleBackColor = true;
   this.chkAllExp.CheckedChanged += new System.EventHandler(this.chkAllExp_CheckedChanged);
   // 
   // grpBx1
   // 
   this.grpBx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx1.Location = new System.Drawing.Point(12, 42);
   this.grpBx1.Name = "grpBx1";
   this.grpBx1.Size = new System.Drawing.Size(833, 510);
   this.grpBx1.TabIndex = 2;
   this.grpBx1.TabStop = false;
   this.grpBx1.Text = "Available Expansions:";
   this.grpBx1.Visible = false;
   // 
   // btnNxt
   // 
   this.btnNxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
   this.btnNxt.Location = new System.Drawing.Point(727, 558);
   this.btnNxt.Name = "btnNxt";
   this.btnNxt.Size = new System.Drawing.Size(118, 37);
   this.btnNxt.TabIndex = 0;
   this.btnNxt.Text = "Next";
   this.btnNxt.UseVisualStyleBackColor = true;
   this.btnNxt.Click += new System.EventHandler(this.btnNxt_Click);
   // 
   // grpBx2
   // 
   this.grpBx2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx2.Location = new System.Drawing.Point(12, 42);
   this.grpBx2.Name = "grpBx2";
   this.grpBx2.Size = new System.Drawing.Size(833, 510);
   this.grpBx2.TabIndex = 4;
   this.grpBx2.TabStop = false;
   this.grpBx2.Text = "Available Masterminds:";
   this.grpBx2.Visible = false;
   // 
   // grpBx3
   // 
   this.grpBx3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx3.Location = new System.Drawing.Point(12, 42);
   this.grpBx3.Name = "grpBx3";
   this.grpBx3.Size = new System.Drawing.Size(833, 510);
   this.grpBx3.TabIndex = 5;
   this.grpBx3.TabStop = false;
   this.grpBx3.Text = "Available Schemes:";
   this.grpBx3.Visible = false;
   // 
   // grpBx4
   // 
   this.grpBx4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx4.Location = new System.Drawing.Point(12, 42);
   this.grpBx4.Name = "grpBx4";
   this.grpBx4.Size = new System.Drawing.Size(833, 510);
   this.grpBx4.TabIndex = 6;
   this.grpBx4.TabStop = false;
   this.grpBx4.Text = "Available Villains:";
   this.grpBx4.Visible = false;
   // 
   // grpBx5
   // 
   this.grpBx5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx5.Location = new System.Drawing.Point(12, 42);
   this.grpBx5.Name = "grpBx5";
   this.grpBx5.Size = new System.Drawing.Size(833, 510);
   this.grpBx5.TabIndex = 7;
   this.grpBx5.TabStop = false;
   this.grpBx5.Text = "Available Henchmen:";
   this.grpBx5.Visible = false;
   // 
   // grpBx6
   // 
   this.grpBx6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx6.Location = new System.Drawing.Point(12, 42);
   this.grpBx6.Name = "grpBx6";
   this.grpBx6.Size = new System.Drawing.Size(833, 510);
   this.grpBx6.TabIndex = 8;
   this.grpBx6.TabStop = false;
   this.grpBx6.Text = "Available Heroes:";
   this.grpBx6.Visible = false;
   // 
   // grpBx0
   // 
   this.grpBx0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.grpBx0.Controls.Add(this.cboPlayers);
   this.grpBx0.Controls.Add(this.label1);
   this.grpBx0.Location = new System.Drawing.Point(12, 42);
   this.grpBx0.Name = "grpBx0";
   this.grpBx0.Size = new System.Drawing.Size(833, 510);
   this.grpBx0.TabIndex = 9;
   this.grpBx0.TabStop = false;
   this.grpBx0.Text = "Options:";
   // 
   // cboPlayers
   // 
   this.cboPlayers.FormattingEnabled = true;
   this.cboPlayers.Location = new System.Drawing.Point(94, 28);
   this.cboPlayers.Name = "cboPlayers";
   this.cboPlayers.Size = new System.Drawing.Size(83, 28);
   this.cboPlayers.TabIndex = 3;
   // 
   // label1
   // 
   this.label1.AutoSize = true;
   this.label1.Location = new System.Drawing.Point(11, 31);
   this.label1.Name = "label1";
   this.label1.Size = new System.Drawing.Size(64, 20);
   this.label1.TabIndex = 2;
   this.label1.Text = "Players:";
   // 
   // FrmNewGame1
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(857, 598);
   this.Controls.Add(this.grpBx0);
   this.Controls.Add(this.grpBx6);
   this.Controls.Add(this.grpBx5);
   this.Controls.Add(this.grpBx4);
   this.Controls.Add(this.grpBx3);
   this.Controls.Add(this.grpBx2);
   this.Controls.Add(this.btnNxt);
   this.Controls.Add(this.grpBx1);
   this.Controls.Add(this.chkAllExp);
   this.Name = "FrmNewGame1";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Scenario Builder";
   this.Load += new System.EventHandler(this.FrmNewGame_Load);
   this.grpBx0.ResumeLayout(false);
   this.grpBx0.PerformLayout();
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  private System.Windows.Forms.CheckBox chkAllExp;
  private System.Windows.Forms.GroupBox grpBx1;
  private System.Windows.Forms.Button btnNxt;
  private System.Windows.Forms.GroupBox grpBx2;
  private System.Windows.Forms.GroupBox grpBx3;
  private System.Windows.Forms.GroupBox grpBx4;
  private System.Windows.Forms.GroupBox grpBx5;
  private System.Windows.Forms.GroupBox grpBx6;
  private System.Windows.Forms.GroupBox grpBx0;
  private System.Windows.Forms.ComboBox cboPlayers;
  private System.Windows.Forms.Label label1;
 }
}