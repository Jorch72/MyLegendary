namespace Legendary{
 partial class frmDebug {
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
   this.txtDebug = new System.Windows.Forms.TextBox();
   this.SuspendLayout();
   // 
   // txtDebug
   // 
   this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
   this.txtDebug.Location = new System.Drawing.Point(12, 12);
   this.txtDebug.Multiline = true;
   this.txtDebug.Name = "txtDebug";
   this.txtDebug.Size = new System.Drawing.Size(528, 437);
   this.txtDebug.TabIndex = 0;
   // 
   // frmDebug
   // 
   this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
   this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
   this.ClientSize = new System.Drawing.Size(552, 461);
   this.Controls.Add(this.txtDebug);
   this.Name = "frmDebug";
   this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
   this.Text = "Debug";
   this.TopMost = true;
   this.ResumeLayout(false);
   this.PerformLayout();

  }

  #endregion

  public System.Windows.Forms.TextBox txtDebug;
 }
}