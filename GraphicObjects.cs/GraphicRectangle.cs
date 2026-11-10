using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for GraphicRectangle.
	/// </summary>
	[Serializable]
   public class GraphicRectangle: GraphicObject
	{
		public GraphicRectangle(float x, float y, float width, float height)
		{
			//
			// TODO: Add constructor logic here
			//

         this.Position = new PointF(x, y);
         this.SetSize(new SizeF(width, height));
		}

      public override void Draw(Graphics g)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Pixel;
         
         Matrix m = new Matrix();
         if(this.Rotation != 0)
         {
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }
         
         g.DrawRectangle(new Pen(Color.Black, 0.1f), this.X, this.Y, this.Width, this.Height);

         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         Draw(g);
      }


	}
}
