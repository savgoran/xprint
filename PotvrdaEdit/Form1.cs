using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using GraphicObjects;

namespace PotvrdaEdit
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
      MexPotvrda mexPotvrda;
      private System.Data.SqlClient.SqlConnection sqlConnection1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      public System.Windows.Forms.FontDialog fontDialog1;
      PrintDocument pd;
      private System.Windows.Forms.Label label10;
      private Font serFont;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private Font idFont;
      private Font textFont;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem menuItem7;
      private System.Windows.Forms.Label lblIdFont;
      private System.Windows.Forms.TextBox tbIdSize;
      private System.Windows.Forms.TextBox tbIdLocation;
      private System.Windows.Forms.TextBox tbIdentSize;
      private System.Windows.Forms.TextBox tbIdentLocation;
      private System.Windows.Forms.TextBox tbImeSize;
      private System.Windows.Forms.TextBox tbImeLocation;
      private System.Windows.Forms.Label lblImeFont;
      private System.Windows.Forms.TextBox tbPotvrdaSize;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox tbBarCodeSize;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.TextBox tbBarCodeLocation;
      private System.Windows.Forms.Label label16;
      private float gutter;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

         pd = new PrintDocument();
         pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
         
         mexPotvrda = new MexPotvrda(0, 0);
         //ticketObject.TicketChanged += new TicketChangedHandler(ticketObject_TicketChanged);
         //ticketObject.Draw(1, panel2.CreateGraphics());

         //LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tombola.gof");

         FillFields();
		}

      public void FillFields()
      {
         PotvrdaSize = mexPotvrda.PotvrdaSize;
         
         IdLocation = mexPotvrda.IdRect.Location;
         IdSize = mexPotvrda.IdRect.Size;
         IdFont = mexPotvrda.IdFont;

         ImeLocation = mexPotvrda.ImeRect.Location;
         ImeSize = mexPotvrda.ImeRect.Size;
         TextFont = mexPotvrda.TextFont;

         IdentLocation = mexPotvrda.IdentRect.Location;
         IdentSize = mexPotvrda.IdentRect.Size;

         BarCodeLocation = mexPotvrda.BarCodeRect.Location;
         BarCodeSize = mexPotvrda.BarCodeRect.Size;
      }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.menuItem4 = new System.Windows.Forms.MenuItem();
         this.menuItem7 = new System.Windows.Forms.MenuItem();
         this.menuItem5 = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.menuItem6 = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.panel1 = new System.Windows.Forms.Panel();
         this.button1 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label9 = new System.Windows.Forms.Label();
         this.tbBarCodeSize = new System.Windows.Forms.TextBox();
         this.label15 = new System.Windows.Forms.Label();
         this.tbBarCodeLocation = new System.Windows.Forms.TextBox();
         this.label16 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.tbIdentSize = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.tbIdentLocation = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.lblImeFont = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.lblIdFont = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.tbImeSize = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.tbImeLocation = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.tbIdSize = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tbIdLocation = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tbPotvrdaSize = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
         this.fontDialog1 = new System.Windows.Forms.FontDialog();
         this.panel1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItem1});
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 0;
         this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItem4,
                                                                                  this.menuItem7,
                                                                                  this.menuItem5,
                                                                                  this.menuItem3,
                                                                                  this.menuItem6,
                                                                                  this.menuItem2});
         this.menuItem1.Text = "Potvrda";
         // 
         // menuItem4
         // 
         this.menuItem4.Index = 0;
         this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this.menuItem4.Text = "&Save";
         this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
         // 
         // menuItem7
         // 
         this.menuItem7.Index = 1;
         this.menuItem7.Text = "Reset to default";
         this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
         // 
         // menuItem5
         // 
         this.menuItem5.Index = 2;
         this.menuItem5.Text = "-";
         // 
         // menuItem3
         // 
         this.menuItem3.Index = 3;
         this.menuItem3.Text = "Print preview...";
         this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
         // 
         // menuItem6
         // 
         this.menuItem6.Index = 4;
         this.menuItem6.Text = "-";
         // 
         // menuItem2
         // 
         this.menuItem2.Index = 5;
         this.menuItem2.Text = "Exit";
         this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 611);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Size = new System.Drawing.Size(680, 22);
         this.statusBar1.TabIndex = 0;
         this.statusBar1.Text = "statusBar1";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.button1);
         this.panel1.Controls.Add(this.groupBox1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(208, 611);
         this.panel1.TabIndex = 1;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 464);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "Apply";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.tbBarCodeSize);
         this.groupBox1.Controls.Add(this.label15);
         this.groupBox1.Controls.Add(this.tbBarCodeLocation);
         this.groupBox1.Controls.Add(this.label16);
         this.groupBox1.Controls.Add(this.label12);
         this.groupBox1.Controls.Add(this.tbIdentSize);
         this.groupBox1.Controls.Add(this.label13);
         this.groupBox1.Controls.Add(this.tbIdentLocation);
         this.groupBox1.Controls.Add(this.label14);
         this.groupBox1.Controls.Add(this.lblImeFont);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.lblIdFont);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.tbImeSize);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.tbImeLocation);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.tbIdSize);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.tbIdLocation);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tbPotvrdaSize);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(16, 16);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(176, 440);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Potvrda Info (mm)";
         // 
         // label9
         // 
         this.label9.Location = new System.Drawing.Point(8, 408);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(32, 23);
         this.label9.TabIndex = 27;
         this.label9.Text = "Size:";
         this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbBarCodeSize
         // 
         this.tbBarCodeSize.Location = new System.Drawing.Point(80, 408);
         this.tbBarCodeSize.Name = "tbBarCodeSize";
         this.tbBarCodeSize.Size = new System.Drawing.Size(80, 20);
         this.tbBarCodeSize.TabIndex = 26;
         this.tbBarCodeSize.Text = "0, 0";
         // 
         // label15
         // 
         this.label15.Location = new System.Drawing.Point(8, 384);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(56, 23);
         this.label15.TabIndex = 25;
         this.label15.Text = "Location:";
         this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbBarCodeLocation
         // 
         this.tbBarCodeLocation.Location = new System.Drawing.Point(80, 384);
         this.tbBarCodeLocation.Name = "tbBarCodeLocation";
         this.tbBarCodeLocation.Size = new System.Drawing.Size(80, 20);
         this.tbBarCodeLocation.TabIndex = 24;
         this.tbBarCodeLocation.Text = "0, 0";
         // 
         // label16
         // 
         this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label16.Location = new System.Drawing.Point(8, 360);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(72, 23);
         this.label16.TabIndex = 23;
         this.label16.Text = "Bar Code";
         this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label12
         // 
         this.label12.Location = new System.Drawing.Point(8, 304);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(32, 23);
         this.label12.TabIndex = 20;
         this.label12.Text = "Size:";
         this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbIdentSize
         // 
         this.tbIdentSize.Location = new System.Drawing.Point(80, 304);
         this.tbIdentSize.Name = "tbIdentSize";
         this.tbIdentSize.Size = new System.Drawing.Size(80, 20);
         this.tbIdentSize.TabIndex = 19;
         this.tbIdentSize.Text = "0, 0";
         // 
         // label13
         // 
         this.label13.Location = new System.Drawing.Point(8, 280);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(56, 23);
         this.label13.TabIndex = 18;
         this.label13.Text = "Location:";
         this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.label13.Click += new System.EventHandler(this.label13_Click);
         // 
         // tbIdentLocation
         // 
         this.tbIdentLocation.Location = new System.Drawing.Point(80, 280);
         this.tbIdentLocation.Name = "tbIdentLocation";
         this.tbIdentLocation.Size = new System.Drawing.Size(80, 20);
         this.tbIdentLocation.TabIndex = 17;
         this.tbIdentLocation.Text = "0, 0";
         // 
         // label14
         // 
         this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label14.Location = new System.Drawing.Point(8, 256);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(48, 23);
         this.label14.TabIndex = 16;
         this.label14.Text = "Ident";
         this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.label14.Click += new System.EventHandler(this.label14_Click);
         // 
         // lblImeFont
         // 
         this.lblImeFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblImeFont.Location = new System.Drawing.Point(40, 224);
         this.lblImeFont.Name = "lblImeFont";
         this.lblImeFont.Size = new System.Drawing.Size(120, 23);
         this.lblImeFont.TabIndex = 15;
         this.lblImeFont.Text = "Font:";
         this.lblImeFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblImeFont.Click += new System.EventHandler(this.lblRbkFont_Click);
         // 
         // label10
         // 
         this.label10.Location = new System.Drawing.Point(8, 224);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(32, 23);
         this.label10.TabIndex = 14;
         this.label10.Text = "Font:";
         this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblIdFont
         // 
         this.lblIdFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblIdFont.Location = new System.Drawing.Point(40, 120);
         this.lblIdFont.Name = "lblIdFont";
         this.lblIdFont.Size = new System.Drawing.Size(120, 23);
         this.lblIdFont.TabIndex = 13;
         this.lblIdFont.Text = "Font:";
         this.lblIdFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblIdFont.Click += new System.EventHandler(this.lblSerijaFont_Click);
         // 
         // label8
         // 
         this.label8.Location = new System.Drawing.Point(8, 120);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(32, 23);
         this.label8.TabIndex = 12;
         this.label8.Text = "Font:";
         this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(8, 200);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(32, 23);
         this.label5.TabIndex = 11;
         this.label5.Text = "Size:";
         this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbImeSize
         // 
         this.tbImeSize.Location = new System.Drawing.Point(80, 200);
         this.tbImeSize.Name = "tbImeSize";
         this.tbImeSize.Size = new System.Drawing.Size(80, 20);
         this.tbImeSize.TabIndex = 10;
         this.tbImeSize.Text = "0, 0";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(8, 176);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(56, 23);
         this.label6.TabIndex = 9;
         this.label6.Text = "Location:";
         this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbImeLocation
         // 
         this.tbImeLocation.Location = new System.Drawing.Point(80, 176);
         this.tbImeLocation.Name = "tbImeLocation";
         this.tbImeLocation.Size = new System.Drawing.Size(80, 20);
         this.tbImeLocation.TabIndex = 8;
         this.tbImeLocation.Text = "0, 0";
         // 
         // label7
         // 
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label7.Location = new System.Drawing.Point(8, 152);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(48, 23);
         this.label7.TabIndex = 7;
         this.label7.Text = "Ime";
         this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(8, 96);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(32, 23);
         this.label4.TabIndex = 6;
         this.label4.Text = "Size:";
         this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbIdSize
         // 
         this.tbIdSize.Location = new System.Drawing.Point(80, 98);
         this.tbIdSize.Name = "tbIdSize";
         this.tbIdSize.Size = new System.Drawing.Size(80, 20);
         this.tbIdSize.TabIndex = 5;
         this.tbIdSize.Text = "0, 0";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 72);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 23);
         this.label3.TabIndex = 4;
         this.label3.Text = "Location:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbIdLocation
         // 
         this.tbIdLocation.Location = new System.Drawing.Point(80, 74);
         this.tbIdLocation.Name = "tbIdLocation";
         this.tbIdLocation.Size = new System.Drawing.Size(80, 20);
         this.tbIdLocation.TabIndex = 3;
         this.tbIdLocation.Text = "0, 0";
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label2.Location = new System.Drawing.Point(8, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(48, 23);
         this.label2.TabIndex = 2;
         this.label2.Text = "Id";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbPotvrdaSize
         // 
         this.tbPotvrdaSize.Location = new System.Drawing.Point(80, 26);
         this.tbPotvrdaSize.Name = "tbPotvrdaSize";
         this.tbPotvrdaSize.Size = new System.Drawing.Size(80, 20);
         this.tbPotvrdaSize.TabIndex = 1;
         this.tbPotvrdaSize.Text = "0, 0";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "Size:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.label1.Click += new System.EventHandler(this.label1_Click);
         // 
         // panel2
         // 
         this.panel2.AutoScroll = true;
         this.panel2.AutoScrollMinSize = new System.Drawing.Size(5000, 5000);
         this.panel2.BackColor = System.Drawing.Color.White;
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(208, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(472, 611);
         this.panel2.TabIndex = 2;
         this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
         // 
         // sqlConnection1
         // 
         this.sqlConnection1.ConnectionString = "workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source=\".\";p" +
            "ersist security info=False;initial catalog=NewTombola";
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(680, 633);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.statusBar1);
         this.Menu = this.mainMenu1;
         this.Name = "Form1";
         this.Text = "MexPotvrda Editor";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.Form1_Load);
         this.panel1.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

      }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

      private void pd_PrintPage(object sender, PrintPageEventArgs e)
      {
         GraphicsContainer graphicsContainer = e.Graphics.BeginContainer();
         e.Graphics.PageUnit = GraphicsUnit.Pixel;
         mexPotvrda.Draw(e.Graphics);
         e.Graphics.EndContainer(graphicsContainer);
      }
      
      private void ticketObject_TicketChanged(object sender, EventArgs e)
      {
         panel2.Invalidate();
      }

      private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         if(mexPotvrda != null)
         {
            Graphics g = e.Graphics;
            GraphicsContainer graphicsContainer = g.BeginContainer();
            //g.PageUnit = GraphicsUnit.Pixel;

            Point pt = this.AutoScrollPosition;
            g.TranslateTransform(pt.X, pt.Y);

            g.ScaleTransform(0.73f, 0.73f);

            g.PageUnit = GraphicsUnit.Millimeter;

            g.FillRectangle(new SolidBrush(Color.White), 0, 0, panel2.Width, panel2.Height);
            //ticketObject.Draw(1, g, 0, 0, 0, 0.8f, true);
            mexPotvrda.Draw(g);
            g.EndContainer(graphicsContainer);
         }
      }

      private void label1_Click(object sender, System.EventArgs e)
      {
      
      }

      public SizeF StrToSizeF(string str)
      {
         string[] ops = str.Trim().Split(new char[] {','});
         return new SizeF(float.Parse(ops[0]), float.Parse(ops[1]));
      }

      public string SizeFToStr(SizeF s)
      {
         return string.Format("{0:f}, {1:f}", s.Width, s.Height);
      }

      public PointF StrToPointF(string str)
      {
         string[] ops = str.Trim().Split(new char[] {','});
         return new PointF(float.Parse(ops[0]), float.Parse(ops[1]));
      }

      public string PointFToStr(PointF pt)
      {
         return string.Format("{0:f}, {1:f}", pt.X, pt.Y);
      }

      public string FontToStr(Font f)
      {
         return string.Format("{0}, {1}, {2}", f.Name, f.SizeInPoints, f.Style.ToString());
      }

      private void lblSerijaFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = idFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            idFont = fontDialog1.Font;
         }
      }

      private void lblRbkFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = textFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            textFont = fontDialog1.Font;
         }
      }

      private void menuItem3_Click(object sender, System.EventArgs e)
      {
         PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
         printPreviewDialog.Document = pd;
         printPreviewDialog.ShowDialog();
      }

      private void menuItem2_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      private void button1_Click(object sender, System.EventArgs e)
      {
         mexPotvrda.PotvrdaSize = PotvrdaSize;
         mexPotvrda.IdRect = new RectangleF(IdLocation, IdSize);
         mexPotvrda.IdFont = IdFont;
         mexPotvrda.ImeRect = new RectangleF(ImeLocation, ImeSize);
         mexPotvrda.TextFont = TextFont;
         mexPotvrda.IdentRect = new RectangleF(IdentLocation, IdentSize);

         mexPotvrda.BarCodeRect = new RectangleF(BarCodeLocation, BarCodeSize);
         panel2.Invalidate();
      }

      public SizeF PotvrdaSize
      {
         get {return StrToSizeF(tbPotvrdaSize.Text);}
         set
         {
            tbPotvrdaSize.Text = SizeFToStr(value);
         }
      }

      public PointF IdLocation
      {
         get {return StrToPointF(tbIdLocation.Text);}
         set
         {
            tbIdLocation.Text = PointFToStr(value);
         }
      }

      public SizeF IdSize
      {
         get {return StrToSizeF(tbIdSize.Text);}
         set
         {
            tbIdSize.Text = SizeFToStr(value);
         }
      }

      public Font IdFont
      {
         get {return idFont;}
         set 
         {
            idFont = value;
            lblIdFont.Text = FontToStr(value);
         }
      }

      public PointF ImeLocation
      {
         get {return StrToPointF(tbImeLocation.Text);}
         set
         {
            tbImeLocation.Text = PointFToStr(value);
         }
      }

      public SizeF ImeSize
      {
         get {return StrToSizeF(tbImeSize.Text);}
         set
         {
            tbImeSize.Text = SizeFToStr(value);
         }
      }

      public Font TextFont
      {
         get {return textFont;}
         set 
         {
            textFont = value;
            lblImeFont.Text = FontToStr(value);
         }
      }

      public PointF IdentLocation
      {
         get {return StrToPointF(tbIdentLocation.Text);}
         set
         {
            tbIdentLocation.Text = PointFToStr(value);
         }
      }

      public SizeF IdentSize
      {
         get {return StrToSizeF(tbIdentSize.Text);}
         set
         {
            tbIdentSize.Text = SizeFToStr(value);
         }
      }

      public PointF BarCodeLocation
      {
         get {return StrToPointF(tbBarCodeLocation.Text);}
         set
         {
            tbBarCodeLocation.Text = PointFToStr(value);
         }
      }

      public SizeF BarCodeSize
      {
         get {return StrToSizeF(tbBarCodeSize.Text);}
         set
         {
            tbBarCodeSize.Text = SizeFToStr(value);
         }
      }


      public void SaveToFile(string fileName)
      {
         mexPotvrda.SavePotvrdaMeasure(fileName);
      }
         

      public void LoadFromFile(string fileName)
      {
         mexPotvrda.LoadPotvrdaMeasure(fileName);
      }

      private void menuItem4_Click(object sender, System.EventArgs e)
      {
         SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\potvrda.gof");
      }

      private void menuItem7_Click(object sender, System.EventArgs e)
      {
         mexPotvrda.MeasureDefaults();
         FillFields();
         panel2.Invalidate();
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
      }

      private void comboBoxUnits_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      }

      private void label13_Click(object sender, System.EventArgs e)
      {
      
      }

      private void label14_Click(object sender, System.EventArgs e)
      {
      
      }
	}
}
