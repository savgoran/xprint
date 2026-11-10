using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for Ticket.
	/// </summary>
	public class Ticket
	{
      private SizeF m_Size = new Size(50, 100);
      
      public Ticket()
      {
         //
         // TODO: Add constructor logic here
         //

         
      }

      public void Draw(Graphics g, float x, float y, float angle)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Millimeter;

         if(angle != 0.0f)
         {
            Matrix m = new Matrix();
            m.RotateAt(angle, new PointF(x + (m_Size.Width / 2), y + (m_Size.Height / 2)));
            g.Transform = m;
         }

         g.DrawString("TOMBOLA", new Font("Arial", 20), new SolidBrush(Color.Black), new RectangleF(x, y, x+100, y+50), new StringFormat());

         g.EndContainer(graphicsContainer);
      }

	}
}
