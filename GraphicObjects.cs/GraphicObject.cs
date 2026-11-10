using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for GraphicObject.
	/// </summary>
	[Serializable]
   public abstract class GraphicObject
	{
		public GraphicObjectsCollection Container;
      private PointF position; // = new Point();
      private SizeF size; // = new Size();
      private Single rotation = 0.0f;
      private PointF leftUpPoint;
      private int idMark; // = 0;
      private float dpiX = 300; // original horizontal resolution
      private float dpiY = 300; // original vertical resolution
      private GraphicsUnit sourceUnit = GraphicsUnit.Pixel;
      
      public GraphicObject()
		{
			//
			// TODO: Add constructor logic here
			//
		}

      public bool HitTest(PointF pt)
      {
         GraphicsPath gPath = new GraphicsPath();
         gPath.AddRectangle(new RectangleF(X, Y, Width, Height));
         if(this.Rotation != 0)
         {
            Matrix m = new Matrix();
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            gPath.Transform(m);
         }
         return gPath.IsVisible(pt);
      }

      public bool HitRectTest(RectangleF rect)
      {
         GraphicsPath gPath = new GraphicsPath();
         gPath.AddRectangle(new RectangleF(this.X, this.Y, this.Width, this.Height));
         if(this.Rotation != 0)
         {
            Matrix m = new Matrix();
            //m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            m.RotateAt(this.Rotation, this.Center);
            gPath.Transform(m);
         }
         RectangleF pathRect = gPath.GetBounds();
         return rect.Contains(pathRect);
      }

      public void SetMMpos(PointF mmPoint)
      {
         RectangleF rect = new RectangleF(LeftUpPoint.X, this.Y, this.X - leftUpPoint.X, leftUpPoint.Y - this.Y);
         rect = SetBottomLeftRectPos(mmPoint, rect);
         this.Position = new PointF(rect.Right, rect.Top);
      }

      private RectangleF SetBottomLeftRectPos(PointF pt, RectangleF rect)
      {
         return new RectangleF(
            new PointF(pt.X, pt.Y - rect.Height),
            rect.Size);
      }

      public void Offset(PointF value)
      {
         this.Position = new PointF(this.Position.X + value.X, this.Position.Y + value.Y);
      }

      public void SetPositionFromRotation(float angle, PointF rotationPoint)
      {
         GraphicsPath gPath = new GraphicsPath();
         gPath.AddRectangle(new RectangleF(this.X, this.Y, this.Width, this.Height));
         if(angle != 0)
         {
            Matrix m = new Matrix();
            //m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            m.RotateAt(this.Rotation, this.Center);
            this.Rotation += angle;
            m.RotateAt(angle, rotationPoint, MatrixOrder.Append);
            gPath.Transform(m);

            this.SetMMpos(gPath.GetBounds().Location);
         }
      }

      #region Properties
      
      public PointF Position
      {
         get {return this.position;}
         set {this.position = value;}
      }

      public PointF Center
      {
         get
         {
            return new PointF(this.Position.X + (this.Width / 2), this.Position.Y + (this.Height / 2));
         }
      }

      public float X
      {
         get {return this.position.X;}
      }

      public float Y
      {
         get {return this.position.Y;}
      }

      public float DpiX
      {
         get {return this.dpiX;}
         set {this.dpiX = value;}
      }

      public float DpiY
      {
         get {return this.dpiY;}
         set {this.dpiY = value;}
      }

      public SizeF GetSize()
      {
         return this.size;
      }

      public void SetSize(SizeF value)
      {
         this.size = value;
      }

      public float Height
      {
         get {return this.size.Height;}
      }

      public float Width
      {
         get {return this.size.Width;}
      }

      public Single Rotation
      {
         get {return this.rotation;}
         set {this.rotation = (value % 360);}
      }

      public PointF LeftUpPoint
      {
         get 
         {
            this.leftUpPoint = this.Bounds.Location;
            return this.leftUpPoint;
         }
         set {this.leftUpPoint = value;}
      }

      public int IdMark
      {
         get {return this.idMark;}
         set {this.idMark = value;}
      }

      public RectangleF Bounds
      {
         get 
         {
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddRectangle(new RectangleF(this.X, this.Y, this.Width, this.Height));
            if(this.Rotation != 0)
            {
               Matrix m = new Matrix();
               //m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
               m.RotateAt(this.Rotation, this.Center);
               gPath.Transform(m);
            }
            return gPath.GetBounds();
         }
      }

      public GraphicsUnit SourceUnit
      {
         get {return this.sourceUnit;}
         set {this.sourceUnit = value;}
      }

      #endregion

      public abstract void Draw(Graphics g);
      public abstract void Print(Graphics g, int id);
	}
}
