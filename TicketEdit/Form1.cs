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

namespace TicketEdit
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
      TicketObject ticketObject;
      private System.Data.SqlClient.SqlConnection sqlConnection1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox tbTicketSize;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox tbSerijaLocation;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox tbSerijaSize;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox tbRbkSize;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox tbRbkLocation;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label lblSerijaFont;
      public System.Windows.Forms.FontDialog fontDialog1;
      PrintDocument pd;
      private System.Windows.Forms.Label lblRbkFont;
      private System.Windows.Forms.Label label10;
      private Font serFont;
      private System.Windows.Forms.Label lblKonBrFont;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox tbKonBrSize;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox tbKonBrLocation;
      private System.Windows.Forms.Label label14;
      private Font rbkFont;
      private System.Windows.Forms.Label label15;
      private System.Windows.Forms.Label label16;
      private System.Windows.Forms.Label label17;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.TextBox tbKombSize;
      private System.Windows.Forms.TextBox tbKombLocation;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.TextBox tbCellSize;
      private System.Windows.Forms.Label label20;
      private System.Windows.Forms.TextBox tbGutter;
      private Font konBrFont;
      private Font smsFont;
      private Font kombFont;
      private System.Windows.Forms.Label lblKombFont;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem menuItem7;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label lblSMSFont;
      private System.Windows.Forms.Label label22;
      private System.Windows.Forms.Label label23;
      private System.Windows.Forms.TextBox tbSMSSize;
      private System.Windows.Forms.Label label24;
      private System.Windows.Forms.TextBox tbSMSLocation;
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
         
         ticketObject = new TicketObject(0, 0);
         //ticketObject.TicketChanged += new TicketChangedHandler(ticketObject_TicketChanged);
         //ticketObject.Draw(1, panel2.CreateGraphics());

         //LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tombola.gof");

         FillFields();
		}

      public void FillFields()
      {
         TicketSize = ticketObject.TicketSize;
         SerLocation = ticketObject.SerijaRect.Location;
         SerSize = ticketObject.SerijaRect.Size;
         SerFont = ticketObject.SerijaFont;

         RbkLocation = ticketObject.RbkRect.Location;
         RbkSize = ticketObject.RbkRect.Size;
         RbkFont = ticketObject.RbkFont;

         KonBrLocation = ticketObject.KonBrRect.Location;
         KonBrSize = ticketObject.KonBrRect.Size;
         KonBrFont = ticketObject.KonBrFont;

         SMSLocation = ticketObject.SMSRect.Location;
         SMSSize = ticketObject.SMSRect.Size;
         SMSFont = ticketObject.SMSFont;

         KombLocation = ticketObject.KombPos;
         KombSize = ticketObject.KombSize;
         CellSize = ticketObject.CellSize;

         Gutter = ticketObject.Gutter;
         KombFont = ticketObject.KombFont;
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
         this.label20 = new System.Windows.Forms.Label();
         this.tbGutter = new System.Windows.Forms.TextBox();
         this.label19 = new System.Windows.Forms.Label();
         this.tbCellSize = new System.Windows.Forms.TextBox();
         this.lblKombFont = new System.Windows.Forms.Label();
         this.label15 = new System.Windows.Forms.Label();
         this.label16 = new System.Windows.Forms.Label();
         this.tbKombSize = new System.Windows.Forms.TextBox();
         this.label17 = new System.Windows.Forms.Label();
         this.tbKombLocation = new System.Windows.Forms.TextBox();
         this.label18 = new System.Windows.Forms.Label();
         this.lblKonBrFont = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.tbKonBrSize = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.tbKonBrLocation = new System.Windows.Forms.TextBox();
         this.label14 = new System.Windows.Forms.Label();
         this.lblRbkFont = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.lblSerijaFont = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.tbRbkSize = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.tbRbkLocation = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.tbSerijaSize = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.tbSerijaLocation = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.tbTicketSize = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.panel2 = new System.Windows.Forms.Panel();
         this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
         this.fontDialog1 = new System.Windows.Forms.FontDialog();
         this.label9 = new System.Windows.Forms.Label();
         this.lblSMSFont = new System.Windows.Forms.Label();
         this.label22 = new System.Windows.Forms.Label();
         this.label23 = new System.Windows.Forms.Label();
         this.tbSMSSize = new System.Windows.Forms.TextBox();
         this.label24 = new System.Windows.Forms.Label();
         this.tbSMSLocation = new System.Windows.Forms.TextBox();
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
         this.menuItem1.Text = "Ticket";
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
         this.statusBar1.Location = new System.Drawing.Point(0, 699);
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
         this.panel1.Size = new System.Drawing.Size(208, 699);
         this.panel1.TabIndex = 1;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 664);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "Apply";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.lblSMSFont);
         this.groupBox1.Controls.Add(this.label22);
         this.groupBox1.Controls.Add(this.label23);
         this.groupBox1.Controls.Add(this.tbSMSSize);
         this.groupBox1.Controls.Add(this.label24);
         this.groupBox1.Controls.Add(this.tbSMSLocation);
         this.groupBox1.Controls.Add(this.label9);
         this.groupBox1.Controls.Add(this.label20);
         this.groupBox1.Controls.Add(this.tbGutter);
         this.groupBox1.Controls.Add(this.label19);
         this.groupBox1.Controls.Add(this.tbCellSize);
         this.groupBox1.Controls.Add(this.lblKombFont);
         this.groupBox1.Controls.Add(this.label15);
         this.groupBox1.Controls.Add(this.label16);
         this.groupBox1.Controls.Add(this.tbKombSize);
         this.groupBox1.Controls.Add(this.label17);
         this.groupBox1.Controls.Add(this.tbKombLocation);
         this.groupBox1.Controls.Add(this.label18);
         this.groupBox1.Controls.Add(this.lblKonBrFont);
         this.groupBox1.Controls.Add(this.label11);
         this.groupBox1.Controls.Add(this.label12);
         this.groupBox1.Controls.Add(this.tbKonBrSize);
         this.groupBox1.Controls.Add(this.label13);
         this.groupBox1.Controls.Add(this.tbKonBrLocation);
         this.groupBox1.Controls.Add(this.label14);
         this.groupBox1.Controls.Add(this.lblRbkFont);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.lblSerijaFont);
         this.groupBox1.Controls.Add(this.label8);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.tbRbkSize);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.tbRbkLocation);
         this.groupBox1.Controls.Add(this.label7);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.tbSerijaSize);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.tbSerijaLocation);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.tbTicketSize);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(16, 16);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(176, 632);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Ticket Info (mm)";
         // 
         // label20
         // 
         this.label20.Location = new System.Drawing.Point(8, 576);
         this.label20.Name = "label20";
         this.label20.Size = new System.Drawing.Size(40, 23);
         this.label20.TabIndex = 33;
         this.label20.Text = "Gutter:";
         this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbGutter
         // 
         this.tbGutter.Location = new System.Drawing.Point(80, 576);
         this.tbGutter.Name = "tbGutter";
         this.tbGutter.Size = new System.Drawing.Size(80, 20);
         this.tbGutter.TabIndex = 32;
         this.tbGutter.Text = "0";
         // 
         // label19
         // 
         this.label19.Location = new System.Drawing.Point(8, 552);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(32, 23);
         this.label19.TabIndex = 31;
         this.label19.Text = "Cell:";
         this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbCellSize
         // 
         this.tbCellSize.Location = new System.Drawing.Point(80, 552);
         this.tbCellSize.Name = "tbCellSize";
         this.tbCellSize.Size = new System.Drawing.Size(80, 20);
         this.tbCellSize.TabIndex = 30;
         this.tbCellSize.Text = "0, 0";
         // 
         // lblKombFont
         // 
         this.lblKombFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblKombFont.Location = new System.Drawing.Point(40, 600);
         this.lblKombFont.Name = "lblKombFont";
         this.lblKombFont.Size = new System.Drawing.Size(120, 23);
         this.lblKombFont.TabIndex = 29;
         this.lblKombFont.Text = "Font:";
         this.lblKombFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblKombFont.Click += new System.EventHandler(this.lblKombFont_Click);
         // 
         // label15
         // 
         this.label15.Location = new System.Drawing.Point(8, 600);
         this.label15.Name = "label15";
         this.label15.Size = new System.Drawing.Size(32, 23);
         this.label15.TabIndex = 28;
         this.label15.Text = "Font:";
         this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label16
         // 
         this.label16.Location = new System.Drawing.Point(8, 528);
         this.label16.Name = "label16";
         this.label16.Size = new System.Drawing.Size(32, 23);
         this.label16.TabIndex = 27;
         this.label16.Text = "Size:";
         this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbKombSize
         // 
         this.tbKombSize.Location = new System.Drawing.Point(80, 528);
         this.tbKombSize.Name = "tbKombSize";
         this.tbKombSize.Size = new System.Drawing.Size(80, 20);
         this.tbKombSize.TabIndex = 26;
         this.tbKombSize.Text = "0, 0";
         // 
         // label17
         // 
         this.label17.Location = new System.Drawing.Point(8, 504);
         this.label17.Name = "label17";
         this.label17.Size = new System.Drawing.Size(56, 23);
         this.label17.TabIndex = 25;
         this.label17.Text = "Location:";
         this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbKombLocation
         // 
         this.tbKombLocation.Location = new System.Drawing.Point(80, 504);
         this.tbKombLocation.Name = "tbKombLocation";
         this.tbKombLocation.Size = new System.Drawing.Size(80, 20);
         this.tbKombLocation.TabIndex = 24;
         this.tbKombLocation.Text = "0, 0";
         // 
         // label18
         // 
         this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label18.Location = new System.Drawing.Point(8, 480);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(80, 23);
         this.label18.TabIndex = 23;
         this.label18.Text = "Kombinacija";
         this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblKonBrFont
         // 
         this.lblKonBrFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblKonBrFont.Location = new System.Drawing.Point(40, 328);
         this.lblKonBrFont.Name = "lblKonBrFont";
         this.lblKonBrFont.Size = new System.Drawing.Size(120, 23);
         this.lblKonBrFont.TabIndex = 22;
         this.lblKonBrFont.Text = "Font:";
         this.lblKonBrFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblKonBrFont.Click += new System.EventHandler(this.lblKonBrFont_Click);
         // 
         // label11
         // 
         this.label11.Location = new System.Drawing.Point(8, 328);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(32, 23);
         this.label11.TabIndex = 21;
         this.label11.Text = "Font:";
         this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
         // tbKonBrSize
         // 
         this.tbKonBrSize.Location = new System.Drawing.Point(80, 304);
         this.tbKonBrSize.Name = "tbKonBrSize";
         this.tbKonBrSize.Size = new System.Drawing.Size(80, 20);
         this.tbKonBrSize.TabIndex = 19;
         this.tbKonBrSize.Text = "0, 0";
         // 
         // label13
         // 
         this.label13.Location = new System.Drawing.Point(8, 280);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(56, 23);
         this.label13.TabIndex = 18;
         this.label13.Text = "Location:";
         this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbKonBrLocation
         // 
         this.tbKonBrLocation.Location = new System.Drawing.Point(80, 280);
         this.tbKonBrLocation.Name = "tbKonBrLocation";
         this.tbKonBrLocation.Size = new System.Drawing.Size(80, 20);
         this.tbKonBrLocation.TabIndex = 17;
         this.tbKonBrLocation.Text = "0, 0";
         // 
         // label14
         // 
         this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label14.Location = new System.Drawing.Point(8, 256);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(48, 23);
         this.label14.TabIndex = 16;
         this.label14.Text = "Kon.br.";
         this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblRbkFont
         // 
         this.lblRbkFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblRbkFont.Location = new System.Drawing.Point(40, 224);
         this.lblRbkFont.Name = "lblRbkFont";
         this.lblRbkFont.Size = new System.Drawing.Size(120, 23);
         this.lblRbkFont.TabIndex = 15;
         this.lblRbkFont.Text = "Font:";
         this.lblRbkFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblRbkFont.Click += new System.EventHandler(this.lblRbkFont_Click);
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
         // lblSerijaFont
         // 
         this.lblSerijaFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblSerijaFont.Location = new System.Drawing.Point(40, 120);
         this.lblSerijaFont.Name = "lblSerijaFont";
         this.lblSerijaFont.Size = new System.Drawing.Size(120, 23);
         this.lblSerijaFont.TabIndex = 13;
         this.lblSerijaFont.Text = "Font:";
         this.lblSerijaFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblSerijaFont.Click += new System.EventHandler(this.lblSerijaFont_Click);
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
         // tbRbkSize
         // 
         this.tbRbkSize.Location = new System.Drawing.Point(80, 200);
         this.tbRbkSize.Name = "tbRbkSize";
         this.tbRbkSize.Size = new System.Drawing.Size(80, 20);
         this.tbRbkSize.TabIndex = 10;
         this.tbRbkSize.Text = "0, 0";
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
         // tbRbkLocation
         // 
         this.tbRbkLocation.Location = new System.Drawing.Point(80, 176);
         this.tbRbkLocation.Name = "tbRbkLocation";
         this.tbRbkLocation.Size = new System.Drawing.Size(80, 20);
         this.tbRbkLocation.TabIndex = 8;
         this.tbRbkLocation.Text = "0, 0";
         // 
         // label7
         // 
         this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label7.Location = new System.Drawing.Point(8, 152);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(48, 23);
         this.label7.TabIndex = 7;
         this.label7.Text = "Rbk";
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
         // tbSerijaSize
         // 
         this.tbSerijaSize.Location = new System.Drawing.Point(80, 98);
         this.tbSerijaSize.Name = "tbSerijaSize";
         this.tbSerijaSize.Size = new System.Drawing.Size(80, 20);
         this.tbSerijaSize.TabIndex = 5;
         this.tbSerijaSize.Text = "0, 0";
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
         // tbSerijaLocation
         // 
         this.tbSerijaLocation.Location = new System.Drawing.Point(80, 74);
         this.tbSerijaLocation.Name = "tbSerijaLocation";
         this.tbSerijaLocation.Size = new System.Drawing.Size(80, 20);
         this.tbSerijaLocation.TabIndex = 3;
         this.tbSerijaLocation.Text = "0, 0";
         // 
         // label2
         // 
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label2.Location = new System.Drawing.Point(8, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(48, 23);
         this.label2.TabIndex = 2;
         this.label2.Text = "Serija";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbTicketSize
         // 
         this.tbTicketSize.Location = new System.Drawing.Point(80, 26);
         this.tbTicketSize.Name = "tbTicketSize";
         this.tbTicketSize.Size = new System.Drawing.Size(80, 20);
         this.tbTicketSize.TabIndex = 1;
         this.tbTicketSize.Text = "0, 0";
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
         this.panel2.Size = new System.Drawing.Size(472, 699);
         this.panel2.TabIndex = 2;
         this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
         // 
         // sqlConnection1
         // 
         this.sqlConnection1.ConnectionString = "workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source=\".\";p" +
            "ersist security info=False;initial catalog=NewTombola";
         // 
         // label9
         // 
         this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.label9.Location = new System.Drawing.Point(8, 360);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(64, 23);
         this.label9.TabIndex = 34;
         this.label9.Text = "SMS KOD";
         this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // lblSMSFont
         // 
         this.lblSMSFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
         this.lblSMSFont.Location = new System.Drawing.Point(40, 432);
         this.lblSMSFont.Name = "lblSMSFont";
         this.lblSMSFont.Size = new System.Drawing.Size(120, 23);
         this.lblSMSFont.TabIndex = 40;
         this.lblSMSFont.Text = "Font:";
         this.lblSMSFont.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.lblSMSFont.Click += new System.EventHandler(this.lblSMSFont_Click);
         // 
         // label22
         // 
         this.label22.Location = new System.Drawing.Point(8, 432);
         this.label22.Name = "label22";
         this.label22.Size = new System.Drawing.Size(32, 23);
         this.label22.TabIndex = 39;
         this.label22.Text = "Font:";
         this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // label23
         // 
         this.label23.Location = new System.Drawing.Point(8, 408);
         this.label23.Name = "label23";
         this.label23.Size = new System.Drawing.Size(32, 23);
         this.label23.TabIndex = 38;
         this.label23.Text = "Size:";
         this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbSMSSize
         // 
         this.tbSMSSize.Location = new System.Drawing.Point(80, 408);
         this.tbSMSSize.Name = "tbSMSSize";
         this.tbSMSSize.Size = new System.Drawing.Size(80, 20);
         this.tbSMSSize.TabIndex = 37;
         this.tbSMSSize.Text = "0, 0";
         // 
         // label24
         // 
         this.label24.Location = new System.Drawing.Point(8, 384);
         this.label24.Name = "label24";
         this.label24.Size = new System.Drawing.Size(56, 23);
         this.label24.TabIndex = 36;
         this.label24.Text = "Location:";
         this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // tbSMSLocation
         // 
         this.tbSMSLocation.Location = new System.Drawing.Point(80, 384);
         this.tbSMSLocation.Name = "tbSMSLocation";
         this.tbSMSLocation.Size = new System.Drawing.Size(80, 20);
         this.tbSMSLocation.TabIndex = 35;
         this.tbSMSLocation.Text = "0, 0";
         // 
         // Form1
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(680, 721);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.statusBar1);
         this.Menu = this.mainMenu1;
         this.Name = "Form1";
         this.Text = "Ticket Editor";
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
         ticketObject.Draw(e.Graphics);
         e.Graphics.EndContainer(graphicsContainer);
      }
      
      private void ticketObject_TicketChanged(object sender, EventArgs e)
      {
         panel2.Invalidate();
      }

      private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         if(ticketObject != null)
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
            ticketObject.Draw(g);
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
         fontDialog1.Font = SerFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            SerFont = fontDialog1.Font;
         }
      }

      private void lblRbkFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = RbkFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            RbkFont = fontDialog1.Font;
         }
      }

      private void lblKonBrFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = KonBrFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            KonBrFont = fontDialog1.Font;
         }
      }

      private void lblKombFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = KombFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            KombFont = fontDialog1.Font;
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
         ticketObject.TicketSize = TicketSize;
         ticketObject.SerijaRect = new RectangleF(SerLocation, SerSize);
         ticketObject.SerijaFont = SerFont;
         ticketObject.RbkRect = new RectangleF(RbkLocation, RbkSize);
         ticketObject.RbkFont = RbkFont;
         ticketObject.KonBrRect = new RectangleF(KonBrLocation, KonBrSize);
         ticketObject.KonBrFont = KonBrFont;
         ticketObject.SMSRect = new RectangleF(SMSLocation, SMSSize);
         ticketObject.SMSFont = SMSFont;

         ticketObject.KombPos = KombLocation;
         ticketObject.KombSize = KombSize;
         ticketObject.CellSize = CellSize;
         ticketObject.Gutter = Gutter;
         ticketObject.KombFont = KombFont;

         panel2.Invalidate();
      }

      public SizeF TicketSize
      {
         get {return StrToSizeF(tbTicketSize.Text);}
         set
         {
            tbTicketSize.Text = SizeFToStr(value);
         }
      }

      public PointF SerLocation
      {
         get {return StrToPointF(tbSerijaLocation.Text);}
         set
         {
            tbSerijaLocation.Text = PointFToStr(value);
         }
      }

      public SizeF SerSize
      {
         get {return StrToSizeF(tbSerijaSize.Text);}
         set
         {
            tbSerijaSize.Text = SizeFToStr(value);
         }
      }

      public Font SerFont
      {
         get {return serFont;}
         set 
         {
            serFont = value;
            lblSerijaFont.Text = FontToStr(value);
         }
      }

      public PointF RbkLocation
      {
         get {return StrToPointF(tbRbkLocation.Text);}
         set
         {
            tbRbkLocation.Text = PointFToStr(value);
         }
      }

      public SizeF RbkSize
      {
         get {return StrToSizeF(tbRbkSize.Text);}
         set
         {
            tbRbkSize.Text = SizeFToStr(value);
         }
      }

      public Font RbkFont
      {
         get {return rbkFont;}
         set 
         {
            rbkFont = value;
            lblRbkFont.Text = FontToStr(value);
         }
      }

      public PointF KonBrLocation
      {
         get {return StrToPointF(tbKonBrLocation.Text);}
         set
         {
            tbKonBrLocation.Text = PointFToStr(value);
         }
      }

      public SizeF KonBrSize
      {
         get {return StrToSizeF(tbKonBrSize.Text);}
         set
         {
            tbKonBrSize.Text = SizeFToStr(value);
         }
      }

      public Font KonBrFont
      {
         get {return konBrFont;}
         set 
         {
            konBrFont = value;
            lblKonBrFont.Text = FontToStr(value);
         }
      }
      
      public PointF SMSLocation
      {
         get {return StrToPointF(tbSMSLocation.Text);}
         set
         {
            tbSMSLocation.Text = PointFToStr(value);
         }
      }

      public SizeF SMSSize
      {
         get {return StrToSizeF(tbSMSSize.Text);}
         set
         {
            tbSMSSize.Text = SizeFToStr(value);
         }
      }

      public Font SMSFont
      {
         get {return smsFont;}
         set 
         {
            smsFont = value;
            lblSMSFont.Text = FontToStr(value);
         }
      }

      public PointF KombLocation
      {
         get {return StrToPointF(tbKombLocation.Text);}
         set
         {
            tbKombLocation.Text = PointFToStr(value);
         }
      }

      public SizeF KombSize
      {
         get {return StrToSizeF(tbKombSize.Text);}
         set
         {
            tbKombSize.Text = SizeFToStr(value);
         }
      }

      public SizeF CellSize
      {
         get {return StrToSizeF(tbCellSize.Text);}
         set
         {
            tbCellSize.Text = SizeFToStr(value);
         }
      }

      public float Gutter
      {
         get {return float.Parse(tbGutter.Text);}
         set
         {
            gutter = value;
            tbGutter.Text = gutter.ToString();
         }
      }

      public Font KombFont
      {
         get {return kombFont;}
         set 
         {
            kombFont = value;
            lblKombFont.Text = FontToStr(value);
         }
      }

      public void SaveToFile(string fileName)
      {
         ticketObject.SaveTicketMeasure(fileName);
      }
         

      public void LoadFromFile(string fileName)
      {
         ticketObject.LoadTicketMeasure(fileName);
      }

      private void menuItem4_Click(object sender, System.EventArgs e)
      {
         SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tombola.gof");
      }

      private void menuItem7_Click(object sender, System.EventArgs e)
      {
         ticketObject.MeasureDefaults();
         FillFields();
         panel2.Invalidate();
      }

      private void Form1_Load(object sender, System.EventArgs e)
      {
      }

      private void comboBoxUnits_SelectedIndexChanged(object sender, System.EventArgs e)
      {
      }

      private void lblSMSFont_Click(object sender, System.EventArgs e)
      {
         fontDialog1.Font = SMSFont;
         if(fontDialog1.ShowDialog() == DialogResult.OK)
         {
            SMSFont = fontDialog1.Font;
         }
      }
	}
}
