using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XPrint
{
	/// <summary>
	/// Summary description for FormPrint.
	/// </summary>
	public class FormPrint : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button buttonPrint;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxFrom;
      private System.Windows.Forms.TextBox textBoxTo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormPrint()
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
         this.buttonPrint = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxFrom = new System.Windows.Forms.TextBox();
         this.textBoxTo = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // buttonPrint
         // 
         this.buttonPrint.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonPrint.Location = new System.Drawing.Point(192, 64);
         this.buttonPrint.Name = "buttonPrint";
         this.buttonPrint.TabIndex = 0;
         this.buttonPrint.Text = "Print";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(112, 64);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 1;
         this.buttonCancel.Text = "Cancel";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 23);
         this.label1.TabIndex = 2;
         this.label1.Text = "From Page:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // textBoxFrom
         // 
         this.textBoxFrom.Location = new System.Drawing.Point(72, 24);
         this.textBoxFrom.Name = "textBoxFrom";
         this.textBoxFrom.Size = new System.Drawing.Size(64, 20);
         this.textBoxFrom.TabIndex = 3;
         this.textBoxFrom.Text = "0";
         this.textBoxFrom.Enter += new System.EventHandler(this.textBoxTo_Enter);
         // 
         // textBoxTo
         // 
         this.textBoxTo.Location = new System.Drawing.Point(200, 24);
         this.textBoxTo.Name = "textBoxTo";
         this.textBoxTo.Size = new System.Drawing.Size(64, 20);
         this.textBoxTo.TabIndex = 5;
         this.textBoxTo.Text = "0";
         this.textBoxTo.Enter += new System.EventHandler(this.textBoxTo_Enter);
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(144, 24);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(56, 23);
         this.label2.TabIndex = 4;
         this.label2.Text = "To Page:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // FormPrint
         // 
         this.AcceptButton = this.buttonPrint;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(282, 103);
         this.Controls.Add(this.textBoxTo);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.textBoxFrom);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonPrint);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "FormPrint";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "FormPrint";
         this.Activated += new System.EventHandler(this.FormPrint_Activated);
         this.ResumeLayout(false);

      }
		#endregion

      private void FormPrint_Activated(object sender, System.EventArgs e)
      {
         textBoxFrom.Focus();
      }

      private void textBoxTo_Enter(object sender, System.EventArgs e)
      {
         (sender as TextBox).SelectAll();
      }

      public int FromPage
      {
         get {return Int32.Parse(textBoxFrom.Text);}
         set {textBoxFrom.Text = value.ToString();}
      }

      public int ToPage
      {
         get {return Int32.Parse(textBoxTo.Text);}
         set {textBoxTo.Text = value.ToString();}
      }
	}
}
