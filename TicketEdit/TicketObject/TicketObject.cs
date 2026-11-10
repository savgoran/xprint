using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TicketPrint
{
	public delegate void TicketChangedHandler(object sender, EventArgs e);
   
   /// <summary>
	/// Summary description for TicketObject.
	/// </summary>
	[Serializable]
   public class TicketObject 
	{
		private SizeF ticketSize = new SizeF(74.247f, 191.153f);
      private RectangleF serijaRect = new RectangleF(1.907f, 30.8f, 16.72f, 7.52f);
      private RectangleF rbkRect = new RectangleF(20.636f, 30.8f, 32.78f, 7.52f);
      private RectangleF konbrRect = new RectangleF(55.425f, 30.8f, 16.72f, 7.52f);
      private Font serijaFont = new Font("Arial", 12);
      private Font rbkFont = new Font("Arial", 12);
      private Font konbrFont = new Font("Arial", 12); 

      private PointF kombPos = new PointF(1.907f, 40.497f);
      private SizeF kombSize = new SizeF(70.247f, 23.11f);
      private SizeF cellSize = new SizeF(7.805f, 7.703f);
      private float gutter = 1.473f;
      private int kombCount;
      private Font kombFont = new Font("Arial", 12);
      
      //[NonSerialized] private StringFormat ticketStringFormat = new StringFormat();

      //[NonSerialized] private Brush ticketBrush = new SolidBrush(Color.Black);

      private TicketInfo ticketInfo = new TicketInfo();
      
      public TicketObject()
		{
			//
			// TODO: Add constructor logic here
			//

         //ticketStringFormat = new StringFormat();
         SetDefaults();
		}

      public void SetDefaults()
      {
         //ticketStringFormat.Alignment = StringAlignment.Center;
         //ticketBrush = new SolidBrush(Color.Black);
         ticketInfo = new TicketInfo();
      }


      #region Properties

      public SizeF TicketSize
      {
         get {return this.ticketSize;}
         set 
         {
            this.ticketSize = value;
         }
      }

      public RectangleF SerijaRect
      {
         get {return this.serijaRect;}
         set 
         {
            this.serijaRect = value;
         }
      }

      public RectangleF RbkRect
      {
         get {return this.rbkRect;}
         set 
         {
            this.rbkRect = value;
         }
      }

      public RectangleF KonBrRect
      {
         get {return this.konbrRect;}
         set 
         {
            this.konbrRect = value;
         }
      }

      public Font SerijaFont
      {
         get {return this.serijaFont;}
         set 
         {
            this.serijaFont = value;
         }
      }

      public Font RbkFont
      {
         get {return this.rbkFont;}
         set 
         {
            this.rbkFont = value;
         }
      }
      
      public Font KonBrFont
      {
         get {return this.konbrFont;}
         set 
         {
            this.konbrFont = value;
         }
      }

      public PointF KombPos
      {
         get {return this.kombPos;}
         set 
         {
            this.kombPos = value;
         }
      }

      public SizeF KombSize
      {
         get {return this.kombSize;}
         set 
         {
            this.kombSize = value;
         }
      }

      public SizeF CellSize
      {
         get {return this.cellSize;}
         set 
         {
            this.cellSize = value;
         }
      }

      public float Gutter
      {
         get {return this.gutter;}
         set 
         {
            this.gutter = value;
         }
      }

      public int KombCount
      {
         get {return this.kombCount;}
         set 
         {
            this.kombCount = value;
         }
      }

      public Font KombFont
      {
         get {return this.kombFont;}
         set 
         {
            this.kombFont = value;
         }
      }

      #endregion

      private void OnTicketChanged(EventArgs e)
      {
         if(TicketChanged != null)
         {
            TicketChanged(this, e);
         }
      }

      public void Draw(int id, Graphics g, float x, float y, float angle, float scale, bool drawLines)
      {
         StringFormat ticketStringFormat = new StringFormat();
         ticketStringFormat.Alignment = StringAlignment.Center;
         Brush ticketBrush = new SolidBrush(Color.Black);
         
         ticketInfo.SetData(id);
         
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Millimeter;

         g.ScaleTransform(scale, scale);

         if(angle != 0.0f)
         {
            Matrix m = new Matrix();
            m.RotateAt(angle, new PointF(x + (TicketSize.Width / 2), y + (TicketSize.Height / 2)));
            g.Transform = m;
         }

         g.TranslateTransform(x, y);

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         if(drawLines)
         {
            g.DrawRectangle(defaultPen, Rectangle.Round(new RectangleF(new PointF(x, y), TicketSize)));
            g.DrawRectangle(defaultPen, Rectangle.Round(this.SerijaRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(RbkRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(KonBrRect));
         }

         DrawCenterString(g, ticketInfo.Serija.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(SerijaRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.Rbk.ToString().PadLeft(7, '0'), this.RbkFont, Rectangle.Round(RbkRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.KonBr.ToString().PadLeft(3, '0'), this.KonBrFont, Rectangle.Round(KonBrRect), ticketBrush, ticketStringFormat);
         
         int i = 0;
         PointF kPos = KombPos;
         for(i = 0; i < 6; i++)
         {
            DrawTable(kPos, g, ticketInfo.GetKomb(i), ticketBrush, ticketStringFormat, drawLines);
            kPos = new PointF(KombPos.X, kPos.Y + KombSize.Height + Gutter);
         }

         g.EndContainer(graphicsContainer);
      }

      public void DrawCenterString(Graphics g, string str, Font font, RectangleF rect, Brush ticketBrush, StringFormat ticketStringFormat)
      {
         PointF pt = new PointF(
            rect.Left + (rect.Width / 2),
            rect.Top + ((rect.Height / 2) - (font.GetHeight(g) / 2)));
         g.DrawString(str, font, ticketBrush, pt.X, pt.Y, ticketStringFormat);
      }

      private void DrawTable(PointF pos, Graphics g, byte[] komb, Brush ticketBrush, StringFormat ticketStringFormat, bool drawLines)
      {
         RectangleF cellRect = new RectangleF(pos, cellSize);
         int i, num;

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         for(i = 0; i < 27; i++)
         {
            if((i > 0) && ((i % 3) == 0))
            {
               cellRect.Offset(CellSize.Width, -(CellSize.Height * 3));
            }

            num = (int) komb[i];
            if(num == 126)
               num = 0;

            if(drawLines)
            {
               g.DrawRectangle(defaultPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
            }
            if(num != 0)
            {
               DrawCenterString(g, num.ToString(), kombFont, cellRect, ticketBrush, ticketStringFormat);
            }
            cellRect.Offset(0, CellSize.Height);
         }
      }

      public event TicketChangedHandler TicketChanged;
	}
}
