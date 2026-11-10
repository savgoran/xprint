using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using GraphicObjects;

namespace DrawSurface
{

   /// <summary>
	/// Summary description for DrawSurface.
	/// </summary>
	public class DrawSurface: System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

      private bool dragging = false;
      private bool selectionDragging = false;
      private RectangleF selectionRect;
      private PointF draggingOffset = new Point(0, 0);
      
      private Rectangle surfaceBounds = new Rectangle(0, 0, 826, 1169); //826, 1169
      private PointF mmPos;
      private Rectangle marginBounds = new Rectangle(0, 0, 826, 1169);
      private float zoom = 0.3f;
      private PointF zoomOffset = new PointF(0.0f, 0.0f);
      private int horizRes = 300;
      private int vertRes = 300;
      private SelectedObjectsCollection SelectedObjects;
      private GraphicObjectsCollection drawingObjects = new GraphicObjectsCollection();
      private bool modifed = false;
      private bool showGrid = false;
      private float gridSize = 5.0f;
      private int movingObjectDelay = 0;
      private GraphicsUnit measureUnit = GraphicsUnit.Pixel;

		public DrawSurface()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

         this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         this.SetStyle(ControlStyles.DoubleBuffer, true);
         this.SetStyle(ControlStyles.UserPaint, true);
         this.SetStyle(ControlStyles.ResizeRedraw, true);

			// TODO: Add any initialization after the InitializeComponent call
         this.AutoScroll = true;
         this.MouseDown += new MouseEventHandler(DrawSurface_MouseDown);
         this.MouseMove += new MouseEventHandler(DrawSurface_MouseMove);
         this.MouseUp += new MouseEventHandler(DrawSurface_MouseUp);
         this.KeyDown += new KeyEventHandler(DrawSurface_KeyDown);

         this.SelectedObjects = new SelectedObjectsCollection();
         this.SelectedObjects.SelectedObjectCollectionChanged += new SelectedObjectsCollectionChangedEventHandler(SelectedObjects_SelectedObjectCollectionChanged);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         // 
         // DrawSurface
         // 
         this.Name = "DrawSurface";

      }
		#endregion

      public GraphicObjectsCollection DrawingObjects
      {
         get{return this.drawingObjects;}
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         //base.OnPaint (e);

         Graphics g = e.Graphics;
         g.SmoothingMode = SmoothingMode.AntiAlias;

         Point pt = this.AutoScrollPosition;
         g.TranslateTransform(pt.X, pt.Y);

         this.horizRes = (int) g.DpiX;
         this.vertRes = (int) g.DpiY;

         //g.ScaleTransform(zoom, zoom);
         
         DrawGrid(g);

         drawingObjects.HorizontalResolution = this.horizRes;
         drawingObjects.VerticalResolution = this.vertRes;
         drawingObjects.DrawObjects(g, zoom);
         drawingObjects.DrawSelectedObjects(g, this.SelectedObjects.ToArray(), zoom);

         DrawSelectedRect(g, this.SelectedObjects.SelectedRect, zoom);         

         DrawMargins(g);

         if(this.selectionDragging)
         {
            this.DrawSelectionRect(g);
         }
      }

      protected Single ConvertToHPixels(Single value)
      {
         return value * this.horizRes;
      }

      protected Single ConvertToVPixels(Single value)
      {
         return value * this.vertRes;
      }

      protected RectangleF ConvertToPixels(RectangleF value)
      {
         return new RectangleF(
            ConvertToHPixels(value.X / 100.0f) , 
            ConvertToVPixels(value.Y / 100.0f) , 
            ConvertToHPixels(value.Width / 100.0f) ,
            ConvertToVPixels(value.Height / 100.0f) );
      }

      protected RectangleF ZoomRectangle(RectangleF value)
      {
         return new RectangleF(
            value.X * zoom,
            value.Y * zoom,
            value.Width * zoom,
            value.Height * zoom);
      }

      protected RectangleF DeZoomRectangle(RectangleF value)
      {
         return new RectangleF(
            value.X / zoom,
            value.Y / zoom,
            value.Width / zoom,
            value.Height / zoom);
      }

      public bool ShowGrid
      {
         get {return this.showGrid;}
         set 
         {
            this.showGrid = value;
            this.Invalidate();
         }
      }

      #region Properties

      public float GridSize
      {
         get {return this.gridSize;}
         set 
         {
            this.gridSize = value;
         }
      }
      
      public float Zoom
      {
         get {return this.zoom;}
         set 
         {
            this.zoom = value;
            RectangleF rect = ZoomRectangle(ConvertToPixels(this.surfaceBounds));
            this.AutoScrollMinSize = Size.Round(new SizeF(rect.Width, rect.Height));
            this.Invalidate();
         }
      }

      public Rectangle SurfaceBounds
      {
         get {return this.surfaceBounds;}
         set {
            this.surfaceBounds = value; //Rectangle.Round(ConvertToPixels(new RectangleF(value.Location, value.Size)));
            this.Invalidate();
         }
      }

      public Rectangle MarginBounds
      {
         get {return this.marginBounds;}
         set {
            this.marginBounds = value; //Rectangle.Round(ConvertToPixels(new RectangleF(value.Location, value.Size)));
         }
      }

      public int HorizRes
      {
         get {return this.horizRes;}
         set {this.horizRes = value;}
      }

      public int VertRes
      {
         get {return this.vertRes;}
         set {this.vertRes = value;}
      }

      public PointF MMPos
      {
         get {return this.mmPos;}
         set {this.mmPos = value;}
      }

      public bool Modifed
      {
         get {return this.modifed;}
         set {this.modifed = value;}
      }

      public GraphicsUnit MeasureUnit
      {
         get {return this.measureUnit;}
         set {
            this.measureUnit = value;
            SelectedObjects_SelectedObjectCollectionChanged(this, null);
         }
      }

      #endregion

      public void DrawGrid(Graphics g)
      {
         //GraphicsContainer graphicsContainer = g.BeginContainer();
         //g.PageUnit = GraphicsUnit.Pixel;
         
         //g.PageUnit = GraphicsUnit.Millimeter;
         Single hgs = ConvertToHPixels(gridSize / 25.4f) * zoom;
         Single vgs = ConvertToVPixels(gridSize / 25.4f) * zoom;

         RectangleF rct = ZoomRectangle(ConvertToPixels(this.surfaceBounds));
         
         if(this.AutoScrollMinSize.Height != rct.Height && 
            this.AutoScrollMinSize.Width != rct.Width)
         {
            this.AutoScrollMinSize = Size.Round(new SizeF(rct.Width, rct.Height));
         }

         RectangleF scrRect = new RectangleF(new Point(0, 0), this.Size);
         if(scrRect.Contains(rct))
         {
            zoomOffset = new PointF((this.Width / 2) - (rct.Width / 2), (this.Height / 2) - (rct.Height / 2));
            g.TranslateTransform(zoomOffset.X, zoomOffset.Y);
         }
         else
            zoomOffset = new PointF(0.0f, 0.0f);
         
         Pen gridPen = new Pen(Color.LightGray, 0.01f);
         gridPen.DashStyle = DashStyle.Dash;
         gridPen.DashPattern = new float[] {3.0f, 3.0f};

         g.Clear(Color.DarkGray);
         rct.Offset(5, 5);
         g.FillRectangle(new SolidBrush(Color.Gray), rct);
         rct.Offset(-5, -5);
         g.FillRectangle(new SolidBrush(Color.White), rct);
         g.DrawRectangle(new Pen(Color.Black, 0.1f), Rectangle.Round(rct));

         if(ShowGrid)
         {
            for(Single i = rct.Left + hgs; i < rct.Right; i += hgs)
               g.DrawLine(gridPen, i, rct.Top, i, rct.Bottom);
            for(Single i = rct.Top + vgs; i < rct.Bottom; i += vgs)
               g.DrawLine(gridPen, rct.Left, i, rct.Right, i);
         }

         //g.EndContainer(graphicsContainer);
      }

      private void DrawSelectedRect(Graphics g, RectangleF rect, float scale)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();

         g.PageUnit = GraphicsUnit.Millimeter;
         g.ScaleTransform(scale, scale);

         g.DrawRectangle(new Pen(Color.Green, 0.1f), rect.X, rect.Y, rect.Width, rect.Height);

         g.EndContainer(graphicsContainer);
      }

      private void DrawMargins(Graphics g)
      {
         //GraphicsContainer graphicsContainer = g.BeginContainer();
         //g.PageUnit = GraphicsUnit.Pixel;
         //RectangleF rct = ZoomRectangle(this.marginBounds);
         RectangleF rct = ZoomRectangle(ConvertToPixels(this.marginBounds));
         Pen marginPen = new Pen(Color.DimGray, 0.01f);
         marginPen.DashStyle = DashStyle.Dot;
         g.DrawRectangle(marginPen, Rectangle.Round(rct));
         //g.EndContainer(graphicsContainer);
      }

      private PointF gscTogoc(PointF gsPT)
      {
         PointF newPT = new PointF(
            (gsPT.X - zoomOffset.X - this.AutoScrollPosition.X) / this.zoom, 
            (gsPT.Y - zoomOffset.Y - this.AutoScrollPosition.Y) / this.zoom);
         return newPT;  
      }

      private PointF gocTomm(PointF goPT)
      {
         float pxpercmh = this.horizRes / 25.4f;
         float pxpercmv = this.vertRes / 25.4f;
         /* snap to grid
         PointF newPT = new PointF(
            RoundTo(goPT.X / pxpercmh, this.GridSize), 
            RoundTo(goPT.Y / pxpercmv, this.GridSize));
         */
         PointF newPT = new PointF(
            goPT.X / pxpercmh, 
            goPT.Y / pxpercmv);
         return newPT;
      }

      private RectangleF grcTomm(RectangleF goRCT)
      {
         float pxpercmh = this.horizRes / 25.4f;
         float pxpercmv = this.vertRes / 25.4f;
         RectangleF newRect = new RectangleF(
            goRCT.X / pxpercmh,
            goRCT.Y / pxpercmv,
            goRCT.Width / pxpercmh,
            goRCT.Height / pxpercmv);
         return newRect;
      }

      private Single RoundTo(float f, float rf)
      {
         return (Single) (Math.Round(f / rf) * rf);
      }

      public void SelectedObjectsSetPos(PointF newPos)
      {
         PointF currentSelectionPosition = this.SelectedObjects.SelectedRect.Location;

         this.SelectedObjects.DragPoint = currentSelectionPosition;
         this.SelectedObjects.MoveObjects(newPos);
      }

      #region Save/Load

      public void SaveToFile(string fileName)
      {
         IFormatter formatter = new BinaryFormatter(); 
         Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
         formatter.Serialize(stream, this.drawingObjects);
         stream.Close();

         this.Modifed = false;
         OnSurfaceChanged(new EventArgs());
      }
         

      public void LoadFromFile(string fileName)
      {
         IFormatter formatter = new BinaryFormatter(); 
         Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
         this.drawingObjects = (GraphicObjectsCollection) formatter.Deserialize(stream);
         stream.Close();

         this.Invalidate();

         this.Modifed = false;
         OnSurfaceChanged(new EventArgs());
      }

      #endregion

      #region Events

      private void DrawSurface_MouseDown(object sender, MouseEventArgs e)
      {
         PointF mousePT = gocTomm( this.gscTogoc(new Point(e.X, e.Y)) );

         SelectedObjects.Add(this.drawingObjects.FindObjectAtPoint(mousePT), (Control.ModifierKeys & Keys.Shift) == Keys.Shift, (Control.ModifierKeys & Keys.Control) == Keys.Control);

         if(e.Button == MouseButtons.Left)
         {
            if(this.SelectedObjects.Count > 0)
            {
               dragging = true;
               this.Cursor = Cursors.SizeAll;
               this.SelectedObjects.DragPoint = mousePT;
            }
            else
            {
               this.selectionDragging = true;
               this.selectionRect = new RectangleF(new PointF(e.X, e.Y), SizeF.Empty);
            }
         }
         else if(e.Button == MouseButtons.Right)
         {
            if(this.SelectedObjects.Count > 0)
            {
               this.SelectedObjects.RotateObjects();
               this.Invalidate();
            }
         }
      }

      private void DrawSurface_MouseMove(object sender, MouseEventArgs e)
      {
         PointF dragPT = gocTomm( this.gscTogoc(new Point(e.X, e.Y)) );

         //GraphicsUnitConverter guc = new GraphicsUnitConverter(this.horizRes);
         MMPos = dragPT; //guc.Convert(this.MeasureUnit, GraphicsUnit.Pixel, dragPT);

         if(dragging)
         {
            if(movingObjectDelay == 0)
            {
               if(this.SelectedObjects.Count > 0)
               {
                  this.SelectedObjects.MoveObjects(dragPT);
                  this.Invalidate();
               }
            }
            else
            {
               movingObjectDelay -= 1;
            }
         }
         else if(this.selectionDragging)
         {
            this.selectionRect.Width = e.X - this.selectionRect.Left;
            this.selectionRect.Height = e.Y - this.selectionRect.Top;
            this.Invalidate();
         }
      }

      private void DrawSurface_MouseUp(object sender, MouseEventArgs e)
      {
         if(dragging)
         {
            dragging = false;
            this.Cursor = Cursors.Default;
            this.Modifed = true;
            OnSurfaceChanged(new EventArgs());
         }
         else if(this.selectionDragging)
         {
            this.selectionDragging = false;
            this.selectionRect.Width = e.X - this.selectionRect.Left; 
            this.selectionRect.Height = e.Y - this.selectionRect.Top; 
            
            RectangleF selRect = CreateRect(selectionRect.Location, new PointF(selectionRect.Right, selectionRect.Bottom));
            selRect.Offset(-this.zoomOffset.X, -this.zoomOffset.Y);
            selRect.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);
            selRect = DeZoomRectangle(selRect);
            GraphicsUnitConverter guc = new GraphicsUnitConverter(this.horizRes);
            selRect = guc.Convert(GraphicsUnit.Millimeter, GraphicsUnit.Pixel, selRect);
            this.SelectedObjects.Add(this.drawingObjects.FindObjectsInRect(Rectangle.Round(selRect)), (Control.ModifierKeys & Keys.Shift) == Keys.Shift);
         }
      }

      private void DrawSurface_KeyDown(object sender, KeyEventArgs e)
      {
         PointF currentSelectedLocation = gocTomm(gscTogoc(this.SelectedObjects.SelectedRect.Location));
         this.SelectedObjects.DragPoint = currentSelectedLocation;

         switch(e.KeyCode)
         {
            case Keys.Delete:
            {
               if(this.SelectedObjects.Count > 0)
               {
                  DeleteSelectedObjects();
               }
               break;
            }
            case Keys.Up:
            {
               // take attention on: protected override bool IsInputKey(Keys keyData)
               if(this.SelectedObjects.Count > 0)
               {
                  this.SelectedObjects.MoveObjects(new PointF(currentSelectedLocation.X, currentSelectedLocation.Y - 1.00f));
               }
               break;
            }
            case Keys.Down:
            {
               // take attention on: protected override bool IsInputKey(Keys keyData)
               if(this.SelectedObjects.Count > 0)
               {
                  this.SelectedObjects.MoveObjects(new PointF(currentSelectedLocation.X, currentSelectedLocation.Y + 1.00f));
               }
               break;
            }
            case Keys.Left:
            {
               // take attention on: protected override bool IsInputKey(Keys keyData)
               if(this.SelectedObjects.Count > 0)
               {
                  this.SelectedObjects.MoveObjects(new PointF(currentSelectedLocation.X - 1.00f, currentSelectedLocation.Y));
               }
               break;
            }
            case Keys.Right:
            {
               // take attention on: protected override bool IsInputKey(Keys keyData)
               if(this.SelectedObjects.Count > 0)
               {
                  this.SelectedObjects.MoveObjects(new PointF(currentSelectedLocation.X + 1.00f, currentSelectedLocation.Y));
               }
               break;
            }
         }
      }

      private void SelectedObjects_SelectedObjectCollectionChanged(object sender, EventArgs e)
      {
         this.Invalidate();

         SelectedObjectChangedEventArgs selectedObjectChangedEventArgs = new SelectedObjectChangedEventArgs();
         
         GraphicsUnitConverter guc = new GraphicsUnitConverter(300);
         
         selectedObjectChangedEventArgs.SelectedObjectsPosition = 
            guc.Convert(this.MeasureUnit, GraphicsUnit.Pixel, this.SelectedObjects.SelectedRect.Location);
         this.OnSelectedObjectChanged(selectedObjectChangedEventArgs);
      }

      #endregion

      protected override bool IsInputKey(Keys keyData)
      {
         if(keyData == Keys.Up || 
            keyData == Keys.Down ||
            keyData == Keys.Right ||
            keyData == Keys.Left)
         {
            return true;
         }
         else
         {
            return base.IsInputKey (keyData);
         }
      }


      public void DeleteSelectedObjects()
      {
         GraphicObject go;
         for(int i = 0; i < this.SelectedObjects.Count; i++)
         {
            go = this.SelectedObjects.Item(i);
            this.drawingObjects.Remove(go);
            go.Container = null;
         }
         this.SelectedObjects.Clear();
      }

      private void DrawSelectionRect(Graphics g)
      {
         Pen selectPen = new Pen(Color.Blue, 0.01f);
         selectPen.DashStyle = DashStyle.Dash;
         selectPen.DashPattern = new float[] {3.0f, 3.0f};

         RectangleF normalizedRect = CreateRect(
            this.selectionRect.Location, 
            new PointF(this.selectionRect.Right, this.selectionRect.Bottom));
         //normalizedRect.Offset(this.AutoScrollPosition.X - this.zoomOffset.X, this.AutoScrollPosition.Y - this.zoomOffset.Y);
         normalizedRect.Offset(-this.zoomOffset.X, -this.zoomOffset.Y);
         normalizedRect.Offset(-this.AutoScrollPosition.X, -this.AutoScrollPosition.Y);

         g.DrawRectangle(selectPen, Rectangle.Round(normalizedRect));
      }

      private RectangleF CreateRect(PointF pt1, PointF pt2)
      {
         float left;
         float top;
         float right;
         float bottom;

         if(pt1.X < pt2.X)
         {
            left = pt1.X;
            right = pt2.X;
         }
         else
         {
            left = pt2.X;
            right = pt1.X;
         }

         if(pt1.Y < pt2.Y)
         {
            top = pt1.Y;
            bottom = pt2.Y;
         }
         else
         {
            top = pt2.Y;
            bottom = pt1.Y;
         }

         return new RectangleF(left, top, right-left, bottom-top);
      }

      private void OnSurfaceChanged(EventArgs e)
      {
         if(DrawSurfaceChanged != null)
         {
            DrawSurfaceChanged(this, e);
         }
      }

      private void OnSelectedObjectChanged(SelectedObjectChangedEventArgs e)
      {
         this.Invalidate();
         
         if(SelectedObjectChanged != null)
         {
            SelectedObjectChanged(this, e);
         }
      }

      public event DrawSurfaceChangedEventHandler DrawSurfaceChanged;
      public event SelectedObjectChangedEventHandler SelectedObjectChanged;

	}
}
