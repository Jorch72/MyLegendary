namespace Legendary {
 partial class frmGame {
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
   this.components = new System.ComponentModel.Container();
   this.timHideCount = new System.Windows.Forms.Timer(this.components);
   this.btnEndTurn = new System.Windows.Forms.Button();
   this.lblCountCards = new System.Windows.Forms.Label();
   this.btnDebug = new System.Windows.Forms.Button();
   this.SuspendLayout();
   // 
   // timHideCount
   // 
   this.timHideCount.Interval = 4000;
   this.timHideCount.Tick += new System.EventHandler(this.timHideCount_Tick);
   // 
   // btnEndTurn
   // 
   this.btnEndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
   this.btnEndTurn.Location = new System.Drawing.Point(1513, 68);
   this.btnEndTurn.Name = "btnEndTurn";
   this.btnEndTurn.Size = new System.Drawing.Size(127, 32);
   this.btnEndTurn.TabIndex = 1;
   this.btnEndTurn.Text = "End Turn";
   this.btnEndTurn.UseVisualStyleBackColor = true;
   this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
   // 
   // lblCountCards
   // 
   this.lblCountCards.AutoSize = true;
   this.lblCountCards.Location = new System.Drawing.Point(1622, 103);
   this.lblCountCards.Name = "lblCountCards";
   this.lblCountCards.Size = new System.Drawing.Size(18, 20);
   this.lblCountCards.TabIndex = 2;
   this.lblCountCards.Text = "0";
   this.lblCountCards.Visible = false;
   // 
   // btnDebug
   // 
   this.btnDebug.DialogResult = System.Windows.Forms.DialogResult.Cancel;
   this.btnDebug.Location = new System.Drawing.Point(1528, 203);
   this.btnDebug.Name = "btnDebug";
   this.btnDebug.Size = new System.Drawing.Size(68, 42);
   this.btnDebug.TabIndex = 3;
   this.btnDebug.Text = "Debug";
   this.btnDebug.UseVisualStyleBackColor = true;
   this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
   // 
   // frmGame
   // 
   this.AcceptButton = this.btnEndTurn;
   this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.CancelButton = this.btnDebug;
   this.ClientSize = new System.Drawing.Size(1653, 660);
   this.Controls.Add(this.btnDebug);
   this.Controls.Add(this.lblCountCards);
   this.Controls.Add(this.btnEndTurn);
   this.Name = "frmGame";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
   this.Text = "Other";
   this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
   this.Load += new System.EventHandler(this.frmMain_Load);
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion
  private System.Windows.Forms.Timer timHideCount;
  private System.Windows.Forms.Button btnEndTurn;
  private System.Windows.Forms.Label lblCountCards;
  private System.Windows.Forms.Button btnDebug;
 }
}