using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using GraphicObjects;
using DrawSurface;

namespace DrawSurfaceTest
{
	/// <summary>
	/// Summary description for PropertyForm.
	/// </summary>
	public class PropertyForm : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown numericUpDownX;
      private System.Windows.Forms.NumericUpDown numericUpDownY;
      private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
      private PointF selectedObjectPosition;
      private System.Windows.Forms.ComboBox cbUnits;
      public DrawSurface.DrawSurface drawSurface;

		public PropertyForm()
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUnits = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.DecimalPlaces = 2;
            this.numericUpDownX.Location = new System.Drawing.Point(24, 10);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            this.numericUpDownX.Enter += new System.EventHandler(this.numericUpDownX_Enter);
            this.numericUpDownX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownX_KeyDown);
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.DecimalPlaces = 2;
            this.numericUpDownY.Location = new System.Drawing.Point(120, 10);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownY.TabIndex = 4;
            this.numericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDownX_ValueChanged);
            this.numericUpDownY.Enter += new System.EventHandler(this.numericUpDownX_Enter);
            this.numericUpDownY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numericUpDownX_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(104, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbUnits
            // 
            this.cbUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnits.Location = new System.Drawing.Point(208, 8);
            this.cbUnits.Name = "cbUnits";
            this.cbUnits.Size = new System.Drawing.Size(136, 21);
            this.cbUnits.TabIndex = 5;
            this.cbUnits.SelectedIndexChanged += new System.EventHandler(this.cbUnits_SelectedIndexChanged);
            // 
            // PropertyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(394, 35);
            this.ControlBox = false;
            this.Controls.Add(this.cbUnits);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownX);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 64);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 64);
            this.Name = "PropertyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PropertyForm";
            this.Load += new System.EventHandler(this.PropertyForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PropertyForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.ResumeLayout(false);

      }
		#endregion


      private void numericUpDownX_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if(e.KeyCode == Keys.Return)
         {
            //if(drawSurface.selectedob != null)
            //{
               drawSurface.SelectedObjectsSetPos( 
                  new PointF((float) numericUpDownX.Value, (float) numericUpDownY.Value));
               //e.Handled = true;
            //}
         }
      }

      private void numericUpDownX_Enter(object sender, System.EventArgs e)
      {
         (sender as NumericUpDown).Select(0, 100);
      }

      private void numericUpDownX_ValueChanged(object sender, System.EventArgs e)
      {
         (sender as NumericUpDown).Select(0, 100);
      }

      private void PropertyForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         e.Cancel = true;
      }

      private void PropertyForm_Load(object sender, System.EventArgs e)
      {
         cbUnits.Items.AddRange(Enum.GetNames(typeof(GraphicsUnit)));
         cbUnits.SelectedIndex = (int) GraphicsUnit.Pixel;
      }

      private void cbUnits_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         drawSurface.MeasureUnit = this.MeasureUnit;
      }

      public PointF SelectedObjectPosition
      {
         get {return this.selectedObjectPosition;}
         set 
         {
            this.selectedObjectPosition = value;
            this.numericUpDownX.Value = (decimal) value.X;
            this.numericUpDownY.Value = (decimal) value.Y;
         }
      }

      public GraphicsUnit MeasureUnit
      {
         get {return (GraphicsUnit) cbUnits.SelectedIndex;}
      }
	}
}
