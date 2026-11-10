using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for ImageObject.
	/// </summary>
	[Serializable]
   public class ImageObject: GraphicObject
	{
      private Image image;
      
      public ImageObject(string picturePath)
		{
			//
			// TODO: Add constructor logic here
			//
         this.image = new Bitmap(picturePath);
         this.Position = new PointF(0, 0);

         this.DpiX = this.image.HorizontalResolution;
         this.DpiY = this.image.VerticalResolution;

         this.SetSize(this.image.Size);
		}

      public override void Draw(Graphics g)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Pixel;
         int newWidth = (int) ((this.image.Width / this.DpiX) * g.DpiX);
         int newHeight = (int) ((this.image.Height / this.DpiY) * g.DpiY);
         this.SetSize(new SizeF(newWidth, newHeight));
         if(this.Rotation != 0)
         {
            Matrix m = new Matrix();
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }
         g.DrawImage(this.image, this.X, this.Y, this.Width, this.Height);
         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         Draw(g);
      }

	}
}
