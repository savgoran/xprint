using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using DrawSurface;
using GraphicObjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DrawSurfaceTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.StatusBar statusBar1;
      private DrawSurface.DrawSurface drawSurface1;
      //private Single scale = 1.0f;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem2;
      private System.Windows.Forms.ToolBar toolBar1;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem menuItem7;
      private System.Windows.Forms.MenuItem menuItem8;
      private System.Windows.Forms.MenuItem menuItem9;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.MenuItem menuItem10;
      private System.Windows.Forms.MenuItem menuItem11;
      private System.Windows.Forms.ToolBarButton toolBarButton2;
      private System.Windows.Forms.ToolBarButton tbbZoomIn;
      private System.Windows.Forms.ToolBarButton tbbZoomOut;
      private System.Drawing.Printing.PrintDocument printDocument;
      private System.Windows.Forms.ToolBarButton toolBarButton3;
      private System.Windows.Forms.ToolBarButton tbbTicketAdd;
      private System.Windows.Forms.ToolBarButton tbbFileOpen;
      const string DefaultText = "Shema Edit v1.0";
      private System.Windows.Forms.StatusBarPanel statusBarPanel1;
      private System.Windows.Forms.StatusBarPanel statusBarPanel2;
      private System.Windows.Forms.Panel panel1;
      private string fileName = "untitled";
      private System.Windows.Forms.MenuItem menuItemShowGrid;
      private System.Windows.Forms.StatusBarPanel statusBarPanelDepth;
      private System.Windows.Forms.MenuItem menuItem12;
      private System.Windows.Forms.MenuItem menuItem13;
      private System.Windows.Forms.MenuItem menuItemPropertyShow;
      private System.Windows.Forms.MenuItem menuItem14;
      private System.Windows.Forms.MenuItem menuItem15;
      private System.Windows.Forms.OpenFileDialog openFileDialog2;
      private System.Windows.Forms.ToolBarButton tbbPictureAdd;
      private System.Windows.Forms.StatusBarPanel statusBarPanel3;
      private System.Windows.Forms.ToolBarButton tbbLoto2;
      private System.Windows.Forms.ToolBarButton tbbLoto4;
      private System.Windows.Forms.ToolBarButton toolBarButton1;
      private System.Windows.Forms.ToolBarButton tbbPotvrda;
      private ToolBarButton tbbMMPotvrda;
      private ToolBarButton tbbTombolaButton;
      private PropertyForm propertyForm;
      //private TicketObject ticketObject = new TicketObject();

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
         
         drawSurface1 = new DrawSurface.DrawSurface();
         drawSurface1.Parent = panel1;
         drawSurface1.Zoom = 0.8f;
         drawSurface1.Dock = DockStyle.Fill;
         drawSurface1.DrawingObjects.DesignMode = true;
         drawSurface1.SelectedObjectChanged += new SelectedObjectChangedEventHandler(drawSurface1_SelectedObjectChanged);
         drawSurface1.DrawSurfaceChanged += new DrawSurfaceChangedEventHandler(drawSurface1_DrawSurfaceChanged);
         drawSurface1.MouseMove += new MouseEventHandler(drawSurface1_MouseMove);

         Depth = drawSurface1.DrawingObjects.Depth;

         this.Text = DefaultText;
         SetupSurface();

         propertyForm = new PropertyForm();
         propertyForm.drawSurface = drawSurface1;

         Size screenSize = SystemInformation.PrimaryMonitorSize;
         propertyForm.Location = new Point(20, screenSize.Height - propertyForm.Height - 20);

         propertyForm.Show(this);
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
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelDepth = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItemShowGrid = new System.Windows.Forms.MenuItem();
            this.menuItemPropertyShow = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbFileOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbbZoomIn = new System.Windows.Forms.ToolBarButton();
            this.tbbZoomOut = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tbbTicketAdd = new System.Windows.Forms.ToolBarButton();
            this.tbbPictureAdd = new System.Windows.Forms.ToolBarButton();
            this.tbbLoto2 = new System.Windows.Forms.ToolBarButton();
            this.tbbLoto4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbbPotvrda = new System.Windows.Forms.ToolBarButton();
            this.tbbMMPotvrda = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tbbTombolaButton = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 455);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanelDepth,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(688, 22);
            this.statusBar1.TabIndex = 3;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel1.MinWidth = 150;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "statusBarPanel1";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel2.MinWidth = 150;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "statusBarPanel2";
            this.statusBarPanel2.Width = 150;
            // 
            // statusBarPanelDepth
            // 
            this.statusBarPanelDepth.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanelDepth.Name = "statusBarPanelDepth";
            this.statusBarPanelDepth.Text = "Depth: 0";
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "Zoom: 0.5";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem14,
            this.menuItem11,
            this.menuItem12});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem8,
            this.menuItem9,
            this.menuItem10,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem2});
            this.menuItem1.Text = "File";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "New";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItem8.Text = "Open";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 2;
            this.menuItem9.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItem9.Text = "Save";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 3;
            this.menuItem10.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "Page Setup";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "Print Preview";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 6;
            this.menuItem5.Text = "Print";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 7;
            this.menuItem6.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 8;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem15});
            this.menuItem14.Text = "Edit";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 0;
            this.menuItem15.Text = "Delete";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemShowGrid,
            this.menuItemPropertyShow});
            this.menuItem11.Text = "View";
            // 
            // menuItemShowGrid
            // 
            this.menuItemShowGrid.Index = 0;
            this.menuItemShowGrid.Text = "Show Grid";
            this.menuItemShowGrid.Click += new System.EventHandler(this.menuItemShowGrid_Click);
            // 
            // menuItemPropertyShow
            // 
            this.menuItemPropertyShow.Checked = true;
            this.menuItemPropertyShow.Index = 1;
            this.menuItemPropertyShow.Text = "PropertyShow";
            this.menuItemPropertyShow.Click += new System.EventHandler(this.menuItemPropertyShow_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem13});
            this.menuItem12.Text = "Options";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 0;
            this.menuItem13.Text = "Depth";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbFileOpen,
            this.toolBarButton2,
            this.tbbZoomIn,
            this.tbbZoomOut,
            this.toolBarButton3,
            this.tbbTicketAdd,
            this.tbbPictureAdd,
            this.tbbLoto2,
            this.tbbLoto4,
            this.toolBarButton1,
            this.tbbPotvrda,
            this.tbbMMPotvrda,
            this.tbbTombolaButton});
            this.toolBar1.ButtonSize = new System.Drawing.Size(23, 22);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(688, 28);
            this.toolBar1.TabIndex = 5;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbFileOpen
            // 
            this.tbbFileOpen.ImageIndex = 0;
            this.tbbFileOpen.Name = "tbbFileOpen";
            this.tbbFileOpen.ToolTipText = "Open File...";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbZoomIn
            // 
            this.tbbZoomIn.ImageIndex = 9;
            this.tbbZoomIn.Name = "tbbZoomIn";
            // 
            // tbbZoomOut
            // 
            this.tbbZoomOut.ImageIndex = 10;
            this.tbbZoomOut.Name = "tbbZoomOut";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbTicketAdd
            // 
            this.tbbTicketAdd.ImageIndex = 4;
            this.tbbTicketAdd.Name = "tbbTicketAdd";
            // 
            // tbbPictureAdd
            // 
            this.tbbPictureAdd.ImageIndex = 5;
            this.tbbPictureAdd.Name = "tbbPictureAdd";
            // 
            // tbbLoto2
            // 
            this.tbbLoto2.ImageIndex = 6;
            this.tbbLoto2.Name = "tbbLoto2";
            // 
            // tbbLoto4
            // 
            this.tbbLoto4.ImageIndex = 7;
            this.tbbLoto4.Name = "tbbLoto4";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbPotvrda
            // 
            this.tbbPotvrda.Name = "tbbPotvrda";
            // 
            // tbbMMPotvrda
            // 
            this.tbbMMPotvrda.Name = "tbbMMPotvrda";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "tombola1944.bmp");
            this.imageList1.Images.SetKeyName(9, "zoom_minus.bmp");
            this.imageList1.Images.SetKeyName(10, "zoom_plus.bmp");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.Filter = "Shema Files (*.bin)|*.bin|All Files (*.*)|*.*";
            this.openFileDialog1.Title = "Open shema file";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bin";
            this.saveFileDialog1.Filter = "Shema Files (*.bin)|*.bin|All Files (*.*)|*.*";
            this.saveFileDialog1.Title = "Save shema file";
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 427);
            this.panel1.TabIndex = 6;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Bitmap Files (*.bmp)|*.bmp";
            // 
            // tbbTombolaButton
            // 
            this.tbbTombolaButton.ImageIndex = 8;
            this.tbbTombolaButton.Name = "tbbTombolaButton";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "ShemaEdit v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

      public int GetPaperSizeIndex(string paperName)
      {
         PaperSize pkSize;
         for(int i = 0; i < printDocument.PrinterSettings.PaperSizes.Count; i++)
         {
            pkSize = printDocument.PrinterSettings.PaperSizes[i];
            if(pkSize.PaperName.Equals(paperName))
            {
               return i;
            }
         }
         return -1;
      }

      public string FileName
      {
         get {return this.fileName;}
         set
         {
            this.fileName = value;
            this.Text = DefaultText + " - " + Path.GetFileName(value);
            if(drawSurface1.Modifed)
               this.Text = this.Text + "*";
         }
      }

      public int Depth
      {
         get {
            return this.drawSurface1.DrawingObjects.Depth;
         }
         set {
            this.drawSurface1.DrawingObjects.Depth = value;
            statusBarPanelDepth.Text = string.Format("Depth: {0}", value);
         }
      }

      public bool PropertyFormShow
      {
         get {return propertyForm.Visible;}
         set {propertyForm.Visible = value;}
      }

      private void menuItem8_Click(object sender, System.EventArgs e)
      {
         OpenFile();
      }

      private void OpenFile()
      {
         openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(
            Environment.SpecialFolder.Personal);
         if(openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            drawSurface1.LoadFromFile(openFileDialog1.FileName);
            drawSurface1.DrawingObjects.DesignMode = true;
            
            printDocument.DefaultPageSettings = drawSurface1.DrawingObjects.CollectionPageSettings.GetPageSettings(printDocument.DefaultPageSettings);

            SetupSurface();
            FileName = openFileDialog1.FileName;
         }
      }

      private void SaveFile()
      {
         if(this.fileName == "untitled")
         {
            saveFileDialog1.InitialDirectory = System.Environment.GetFolderPath(
               Environment.SpecialFolder.Personal);
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               drawSurface1.SaveToFile(saveFileDialog1.FileName);
               FileName = saveFileDialog1.FileName;
            }
         }
         else
         {
            drawSurface1.SaveToFile(this.fileName);
         }
      }

      private void PageSetup()
      {
         PageSetupDialog pageSetupDialog = new PageSetupDialog();
         pageSetupDialog.Document = printDocument;
         if(pageSetupDialog.ShowDialog() == DialogResult.OK)
         {
            //drawSurface1.DrawingObjects.CollectionPageSettings = new PrintPageSettings(printDocument.DefaultPageSettings, this.GetPaperSizeIndex(printDocument.DefaultPageSettings.PaperSize.PaperName));
            SetupSurface();
         }
      }

      private void SetupSurface()
      {
         PageSettings defSettings = printDocument.DefaultPageSettings;
         drawSurface1.DrawingObjects.CollectionPageSettings = new PrintPageSettings(defSettings, this.GetPaperSizeIndex(defSettings.PaperSize.PaperName));

         Rectangle bounds = defSettings.Bounds;

         drawSurface1.HorizRes = defSettings.PrinterResolution.X;
         drawSurface1.VertRes = defSettings.PrinterResolution.Y;

         drawSurface1.MarginBounds = new Rectangle(
            bounds.Left + defSettings.Margins.Left,
            bounds.Top + defSettings.Margins.Top,
            bounds.Width - defSettings.Margins.Left - defSettings.Margins.Right,
            bounds.Height - defSettings.Margins.Top - defSettings.Margins.Bottom);
         drawSurface1.SurfaceBounds = bounds;
      }
      
      private void PrintPreview()
      {
         PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
         printPreviewDialog.Document = printDocument;
         printPreviewDialog.SetDesktopLocation(0, 0);
         printPreviewDialog.SetDesktopBounds(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
         printPreviewDialog.ShowDialog(this);
      }

      private void Print()
      {
         PrintDialog printDialog = new PrintDialog();
         printDialog.Document = printDocument;
         if(printDialog.ShowDialog() == DialogResult.OK)
         {
            printDocument.Print();
         }
      }

      private void menuItem9_Click(object sender, System.EventArgs e)
      {
         SaveFile();
      }

      private void menuItem2_Click(object sender, System.EventArgs e)
      {
         this.Close();
      }

      private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if(e.Button == tbbFileOpen)
         {
            OpenFile();
         }
         if(e.Button == tbbZoomIn)
         {
            if(drawSurface1.Zoom > 0.02)
               drawSurface1.Zoom -= 0.02f;
            statusBarPanel3.Text = string.Format("Zoom: {0}", drawSurface1.Zoom);
         }
         if(e.Button == tbbZoomOut)
         {
            if(drawSurface1.Zoom < 2.0)
               drawSurface1.Zoom += 0.02f;
            statusBarPanel3.Text = string.Format("Zoom: {0}", drawSurface1.Zoom);
         }
         if(e.Button == tbbTicketAdd)
         {
            Random rand = new Random();
            TicketObject gr = new TicketObject(rand.Next(50), rand.Next(50));
            //GraphicRectangle gr = new GraphicRectangle(rand.Next(50), rand.Next(50), 100, 200);
            drawSurface1.DrawingObjects.Add(gr);
            drawSurface1.Invalidate();
         }
         if(e.Button == tbbPictureAdd)
         {
            Random rand = new Random();
            LotoTicket lt = new LotoTicket(rand.Next(50), rand.Next(50));
            drawSurface1.DrawingObjects.Add(lt);
            drawSurface1.Invalidate();
         }
         if(e.Button == tbbLoto2)
         {
            Random rand = new Random();
            LotoTicket2 lt = new LotoTicket2(rand.Next(50), rand.Next(50));
            drawSurface1.DrawingObjects.Add(lt);
            drawSurface1.Invalidate();
         }
         if(e.Button == tbbLoto4)
         {
            Random rand = new Random();
            LotoTicket4 lt = new LotoTicket4(rand.Next(50), rand.Next(50));
            drawSurface1.DrawingObjects.Add(lt);
            drawSurface1.Invalidate();
         }
         if(e.Button == tbbPotvrda)
         {
            Random rand = new Random();
            MexPotvrda mp = new MexPotvrda(rand.Next(50), rand.Next(50));
            drawSurface1.DrawingObjects.Add(mp);
            drawSurface1.Invalidate();
         }
         if (e.Button == tbbMMPotvrda)
         {
            Random rand = new Random();
            MercatorMexPotvrda mmp = new MercatorMexPotvrda(rand.Next(50), rand.Next(50));
            drawSurface1.DrawingObjects.Add(mmp);
            drawSurface1.Invalidate();
         }
         if (e.Button == tbbTombolaButton)
         {
             Random rand = new Random();
             TombolaObject tombola = new TombolaObject(rand.Next(50), rand.Next(50));
             drawSurface1.DrawingObjects.Add(tombola);
             drawSurface1.Invalidate();
         }
         
      }

      private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
         drawSurface1.DrawingObjects.PrintObjects(1, e.Graphics);
      }

      private void menuItem4_Click(object sender, System.EventArgs e)
      {
         PrintPreview();
      }

      private void menuItem5_Click(object sender, System.EventArgs e)
      {
         Print();
      }

      private void menuItem3_Click(object sender, System.EventArgs e)
      {
         PageSetup();
      }

      private void drawSurface1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         PointF pt = drawSurface1.MMPos;
         statusBarPanel1.Text = string.Format("( {0:f}, {1:f} )", pt.X, pt.Y);
      }

      private void drawSurface1_DrawSurfaceChanged(object sender, System.EventArgs e)
      {
         FileName = this.fileName;
      }

      private void drawSurface1_SelectedObjectChanged(object sender, DrawSurface.SelectedObjectChangedEventArgs e)
      {
         propertyForm.SelectedObjectPosition = e.SelectedObjectsPosition;
      }

      private void menuItemShowGrid_Click(object sender, System.EventArgs e)
      {
         drawSurface1.ShowGrid = !drawSurface1.ShowGrid;
         menuItemShowGrid.Checked = drawSurface1.ShowGrid;
      }

      public TicketObject LoadFromFile(string fileName)
      {
         TicketObject ticketObject = null;
         
         if(File.Exists(fileName))
         {
            IFormatter formatter = new BinaryFormatter(); 
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            ticketObject = (TicketObject) formatter.Deserialize(stream);
            stream.Close();
         }

         return ticketObject;
      }

      private void menuItem13_Click(object sender, System.EventArgs e)
      {
         DepthForm depthForm = new DepthForm();
         depthForm.Depth = this.Depth;
         if(depthForm.ShowDialog() == DialogResult.OK)
         {
            this.Depth = depthForm.Depth;
         }
      }

      private void menuItem7_Click(object sender, System.EventArgs e)
      {
         if(drawSurface1.Modifed)
         {
            switch(MessageBox.Show("Save changes?", "Confirmation", MessageBoxButtons.YesNoCancel))
            {
               case DialogResult.Yes:
               {
                  SaveFile();
                  break;
               }
               case DialogResult.No:
               {
                  break;
               }
               case DialogResult.Cancel:
               {
                  return;
                  //break;
               }
            }

         }
         drawSurface1.DrawingObjects.Clear();
         FileName = "untitled";
         drawSurface1.Invalidate();
         drawSurface1.Invalidate();
      }

      private void menuItemPropertyShow_Click(object sender, System.EventArgs e)
      {
         menuItemPropertyShow.Checked = !menuItemPropertyShow.Checked;
         PropertyFormShow = menuItemPropertyShow.Checked;
      }

      private void menuItem15_Click(object sender, System.EventArgs e)
      {
      }            
	}
}
