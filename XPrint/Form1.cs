using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;
using GraphicObjects;

namespace XPrint
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private IContainer components;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Drawing.Printing.PrintDocument printDocument1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.PrintDialog printDialog1;
      private GraphicObjectsCollection printObjects = new GraphicObjectsCollection();
      private int currentPage = 0;
      private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.NumericUpDown numericUpDownVer;
      private System.Windows.Forms.NumericUpDown numericUpDownHor;
      private System.Windows.Forms.Button buttonReset;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel3;
      private System.Windows.Forms.ListView listView1;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private int toPage = 0;
      private string binFileName;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem menuItem7;
      private EventLog myLog;
      FormPrint formPrint = new FormPrint();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
         GetDef();
         printDocument1.PrinterSettings.MinimumPage = 0;
         printDocument1.PrinterSettings.MaximumPage = 10000000;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button2 = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownVer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownHor = new System.Windows.Forms.NumericUpDown();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHor)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.Filter = "Shema Files (*.bin)|*.bin|All Files (*.*)|*.*";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 56);
            this.button2.TabIndex = 2;
            this.button2.Text = "Print";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.printDocument1;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDownVer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDownHor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 40);
            this.panel1.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(352, 8);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(56, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(176, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vertical offset:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownVer
            // 
            this.numericUpDownVer.DecimalPlaces = 2;
            this.numericUpDownVer.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownVer.Location = new System.Drawing.Point(264, 10);
            this.numericUpDownVer.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownVer.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownVer.Name = "numericUpDownVer";
            this.numericUpDownVer.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownVer.TabIndex = 2;
            this.numericUpDownVer.ValueChanged += new System.EventHandler(this.numericUpHor_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Horizontal offset:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownHor
            // 
            this.numericUpDownHor.DecimalPlaces = 2;
            this.numericUpDownHor.ForeColor = System.Drawing.Color.Black;
            this.numericUpDownHor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHor.Location = new System.Drawing.Point(104, 10);
            this.numericUpDownHor.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownHor.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDownHor.Name = "numericUpDownHor";
            this.numericUpDownHor.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownHor.TabIndex = 0;
            this.numericUpDownHor.ValueChanged += new System.EventHandler(this.numericUpHor_ValueChanged);
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
            this.menuItem2,
            this.menuItem3,
            this.menuItem6,
            this.menuItem4,
            this.menuItem7,
            this.menuItem5});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem2.Text = "Open Shema...";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "Print Preview";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItem4.Text = "Print";
            this.menuItem4.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 5;
            this.menuItem5.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItem5.Text = "E&xit";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 223);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(424, 22);
            this.statusBar1.TabIndex = 4;
            this.statusBar1.Text = "statusBar1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 183);
            this.panel2.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(312, 183);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "from";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "to";
            this.columnHeader2.Width = 100;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(312, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(112, 183);
            this.panel3.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(424, 245);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "PrintX";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
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

      public void LoadFromFile(string fileName)
      {
         IFormatter formatter = new BinaryFormatter(); 
         Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
         this.printObjects = (GraphicObjectsCollection) formatter.Deserialize(stream);
         printDocument1.DefaultPageSettings = 
            this.printObjects.CollectionPageSettings.GetPageSettings(printDocument1.DefaultPageSettings);
         stream.Close();
      }

      private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         if(printObjects != null)
         {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            e.Graphics.TranslateTransform((float) numericUpDownHor.Value, (float) numericUpDownVer.Value);
            printObjects.PrintObjects(currentPage, e.Graphics);
            currentPage += 1;
            e.HasMorePages = (currentPage <= toPage);
         }
      }

      private void button2_Click(object sender, System.EventArgs e)
      {
         //printDialog1.Document = printDocument1;
         //FormPrint formPrint = new FormPrint();
         if(formPrint.ShowDialog() == DialogResult.OK)
         {
            printDocument1.PrinterSettings.FromPage = formPrint.FromPage;
            printDocument1.PrinterSettings.ToPage = formPrint.Top;
            
            currentPage = formPrint.FromPage;
            toPage = formPrint.ToPage;
            myLog.WriteEntry(string.Format("Printing tickets from {0} to {1}", currentPage, toPage));
            printDocument1.Print();
         }
      }

      private void numericUpHor_ValueChanged(object sender, System.EventArgs e)
      {
         NumericUpDown nupdn = (sender as NumericUpDown);
         if(nupdn.Value.CompareTo((decimal) 0.0f) != 0)
         {
            nupdn.ForeColor = Color.Red;
         }
         else
         {
            nupdn.ForeColor = Color.Black;
         }
      }

      private void buttonReset_Click(object sender, System.EventArgs e)
      {
         numericUpDownHor.Value = (decimal) 0.00f;
         numericUpDownVer.Value = (decimal) 0.00f;
      }

      private void menuItem2_Click(object sender, System.EventArgs e)
      {
         openFileDialog1.InitialDirectory = 
            Environment.GetFolderPath(Environment.SpecialFolder.Personal);
         if(openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            BinFileName = openFileDialog1.FileName;
            //LoadFromFile(openFileDialog1.FileName);
            //this.Text = "PrintX - " + Path.GetFileName(openFileDialog1.FileName);
         }
      }

      public decimal VerticalOffset
      {
         get {return numericUpDownVer.Value;}
         set
         {
            numericUpDownVer.Value =  value;
         }
      }

      public decimal HorizontalOffset
      {
         get {return  numericUpDownHor.Value;}
         set 
         {
            numericUpDownHor.Value = value;
         }
      }

      public string BinFileName
      {
         get {return this.binFileName;}
         set
         {
            this.binFileName = value;
            if(File.Exists(value))
            {
               try
               {
                  LoadFromFile(value);
                  this.Text = "PrintX - " + Path.GetFileName(value);
               }
               catch
               {
                  MessageBox.Show("Error loading file!");
                  this.Text = "PrintX - ";
                  this.binFileName = "";
               }
            }
         }
      }

      private void GetDef()
      {
         if(!EventLog.SourceExists("XPrint"))
         {
            EventLog.CreateEventSource("XPrint", "XPrint");
         }
                
         // Create an EventLog instance and assign its source.
         myLog = new EventLog();
         myLog.Source = "XPrint";

         myLog.WriteEntry("XPrint started!", EventLogEntryType.SuccessAudit); 
         
         RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\PrintX", false);
         if(rk != null)
         {
            HorizontalOffset = Convert.ToDecimal(rk.GetValue("HorizontalOffset", 0.0m));
            VerticalOffset = Convert.ToDecimal(rk.GetValue("VerticalOffset", 0.0m));
            BinFileName = (string) rk.GetValue("BinFileName", "");
         }
      }

      private void SetDef()
      {
         RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software\\PrintX", true);
         if(rk == null)
            rk = Registry.LocalMachine.CreateSubKey("Software\\PrintX");
         if(rk != null)
         {
            rk.SetValue("HorizontalOffset", HorizontalOffset);
            rk.SetValue("VerticalOffset", VerticalOffset);
            rk.SetValue("BinFileName", BinFileName);
         }
      }

      private void Form1_Closed(object sender, System.EventArgs e)
      {
         SetDef();
      }

      private void menuItem6_Click(object sender, System.EventArgs e)
      {
         //FormPrint formPrint = new FormPrint();
         if(formPrint.ShowDialog() == DialogResult.OK)
         {
            printDocument1.PrinterSettings.FromPage = formPrint.FromPage;
            printDocument1.PrinterSettings.ToPage = formPrint.Top;
            
            currentPage = formPrint.FromPage;
            toPage = formPrint.ToPage;
            myLog.WriteEntry(string.Format("Printing tickets from {0} to {1}", currentPage, toPage));
            printPreviewDialog1.ShowDialog();
         }  
      }

      private void menuItem5_Click(object sender, EventArgs e)
      {
          Close();
      }
	}
}
