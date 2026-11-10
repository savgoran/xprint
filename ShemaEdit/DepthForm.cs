using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DrawSurfaceTest
{
	/// <summary>
	/// Summary description for DepthForm.
	/// </summary>
	public class DepthForm : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button buttonOk;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxDepth;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DepthForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.buttonOk = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxDepth = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // buttonOk
         // 
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Location = new System.Drawing.Point(200, 64);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.TabIndex = 1;
         this.buttonOk.Text = "Ok";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(120, 64);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 2;
         this.buttonCancel.Text = "Cancel";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(48, 23);
         this.label1.TabIndex = 2;
         this.label1.Text = "Depth:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBoxDepth
         // 
         this.textBoxDepth.Location = new System.Drawing.Point(56, 18);
         this.textBoxDepth.Name = "textBoxDepth";
         this.textBoxDepth.Size = new System.Drawing.Size(72, 20);
         this.textBoxDepth.TabIndex = 0;
         this.textBoxDepth.Text = "0";
         // 
         // DepthForm
         // 
         this.AcceptButton = this.buttonOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(282, 95);
         this.Controls.Add(this.textBoxDepth);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "DepthForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Depth";
         this.ResumeLayout(false);

      }
		#endregion

      public int Depth
      {
         get {return Int32.Parse(textBoxDepth.Text);}
         set {textBoxDepth.Text = value.ToString();}
      }
	}
}
