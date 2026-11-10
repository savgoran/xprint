using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for LotoTicket2.
	/// </summary>
	[Serializable]
	public class LotoTicket2: GraphicObject
	{
      private RectangleF SerijaRect = new RectangleF(10, 25, 5, 8);
      private RectangleF RbkRect = new RectangleF(19, 25, 12, 8);
      private RectangleF KbRect = new RectangleF(37, 25, 5, 8);
      private RectangleF barcodeRect = new RectangleF(10, 40, 32, 17);
      private PointF tablePos = new PointF(70, 10);
      private PointF tablePos1 = new PointF(80, 10);
      private SizeF cellSize = new SizeF(7, 7);
      //private LotoKomb lotoKomb;
      Font SerijaFont = new Font("Arial", 12);
      public Font barcodFont = new Font("IDAutomationHC39M", 8);
      
      public LotoTicket2(float x, float y)
      {
         //this.potvrdaMeasure = LoadPotvrdaMeasure(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\potvrda.gof");
         this.SourceUnit = GraphicsUnit.Millimeter;
         
         this.Position = new PointF(x, y);
         //this.SetSize(new SizeF(105, 74));

         ReadConf();
      }

      private void ReadConf()
      {
         ReadXmlConf rcf = new ReadXmlConf(@"C:\Program Files\Common Files\LutrijaCG\Baze\L39001-2.xml");

         SizeF ticketSize = rcf.GetSizeF(@"/LotoTicket/TicketSize/");
         this.SetSize(ticketSize);
         
         try
         {
            SerijaRect = rcf.GetRectangleF(@"/LotoTicket/SerijaRect/");
         }
         catch(Exception ex)
         {
            throw new Exception("SerijaRect: " + ex.Message);
         }
         RbkRect = rcf.GetRectangleF(@"/LotoTicket/RbkRect/");
         KbRect = rcf.GetRectangleF(@"/LotoTicket/KbRect/");
         barcodeRect = rcf.GetRectangleF(@"/LotoTicket/BarcodeRect/");
         tablePos = rcf.GetPointF(@"/LotoTicket/TablePos/");
         tablePos1 = rcf.GetPointF(@"/LotoTicket/TablePos1/");
         cellSize = rcf.GetSizeF(@"/LotoTicket/CellSize/");
         SerijaFont = rcf.GetFont(@"/LotoTicket/SerijaFont/");
         barcodFont = rcf.GetFont(@"/LotoTicket/BarcodeFont/");
      }

      public override void Draw(Graphics g)
      {
         bool drawLines = true;
         StringFormat strFormat = new StringFormat();
         strFormat.Alignment = StringAlignment.Center;
         Brush ticketBrush = new SolidBrush(Color.Black);

         LotoKomb lotoKomb = LotoKomb.EmptyKomb();
         
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = this.SourceUnit;

         Matrix m = new Matrix();
         if(this.Rotation != 0)
         {
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }

         if(Container != null)
         {
            if(Container.DesignMode)
            {
               RectangleF rect = new RectangleF(0f, 0f, 10f, 8f);
               rect.Offset(this.X + 4, this.Y + 4);
               g.FillRectangle(new SolidBrush(Color.DarkGray), rect);

               string str = this.IdMark.ToString().PadLeft(2, '0');
               Font strFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
               PointF strPoint = new PointF(rect.Left + (rect.Width / 2), rect.Top + ((rect.Height / 2) - (strFont.GetHeight(g) / 2)) );
               StringFormat strFormat1 = new StringFormat();
               strFormat1.Alignment = StringAlignment.Center;
               g.DrawString(str, strFont, new SolidBrush(Color.White), strPoint, strFormat1); 
            }
         }

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);

         g.TranslateTransform(this.X, this.Y);

         if(drawLines)
         {
            //g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);
            //g.TranslateTransform(this.X, this.Y);
            g.DrawRectangle(defaultPen, Rectangle.Round(SerijaRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(RbkRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(KbRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(barcodeRect));
         }

         DrawCenterString(g, lotoKomb.ser.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(SerijaRect), ticketBrush, strFormat);
         DrawCenterString(g, lotoKomb.rbk.ToString().PadLeft(7, '0'), this.SerijaFont, Rectangle.Round(RbkRect), ticketBrush, strFormat);
         DrawCenterString(g, lotoKomb.kb.ToString().PadLeft(5, '0'), this.SerijaFont, Rectangle.Round(KbRect), ticketBrush, strFormat);

         DrawCenterString(g, "(" + lotoKomb.ser.ToString().PadLeft(3, '0') + lotoKomb.rbk.ToString().PadLeft(7, '0') + lotoKomb.kb.ToString().PadLeft(5, '0') + ")", barcodFont, barcodeRect, new SolidBrush(Color.Black), strFormat);

         DrawTable(g, tablePos.X, tablePos.Y, cellSize.Width, cellSize.Height, (byte[]) lotoKomb.combs[0]); 
         DrawTable(g, tablePos1.X, tablePos1.Y, cellSize.Width, cellSize.Height, (byte[]) lotoKomb.combs[1]); 

         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         StringFormat strFormat = new StringFormat();
         strFormat.Alignment = StringAlignment.Center;
         Brush ticketBrush = new SolidBrush(Color.Black);

         LotoKomb lotoKomb = LotoKomb.GetLotoKomb(id);
         
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = this.SourceUnit;

         Matrix m = new Matrix();
         if(this.Rotation != 0)
         {
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         //g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);

         g.TranslateTransform(this.X, this.Y);

         DrawCenterString(g, lotoKomb.ser.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(SerijaRect), ticketBrush, strFormat);
         DrawCenterString(g, lotoKomb.rbk.ToString().PadLeft(7, '0'), this.SerijaFont, Rectangle.Round(RbkRect), ticketBrush, strFormat);
         DrawCenterString(g, lotoKomb.kb.ToString().PadLeft(5, '0'), this.SerijaFont, Rectangle.Round(KbRect), ticketBrush, strFormat);

         DrawCenterString(g, "(" + lotoKomb.ser.ToString().PadLeft(3, '0') + lotoKomb.rbk.ToString().PadLeft(7, '0') + lotoKomb.kb.ToString().PadLeft(5, '0') + ")", barcodFont, barcodeRect, new SolidBrush(Color.Black), strFormat);

         DrawTable(g, tablePos.X, tablePos.Y, cellSize.Width, cellSize.Height, (byte[]) lotoKomb.combs[0]); 
         DrawTable(g, tablePos1.X, tablePos1.Y, cellSize.Width, cellSize.Height, (byte[]) lotoKomb.combs[1]); 

         g.EndContainer(graphicsContainer);
      }

      private void DrawCenterString(Graphics g, string str, Font font, RectangleF rect, Brush ticketBrush, StringFormat ticketStringFormat)
      {
         if(rect.X == -1)
            return;
         
         PointF pt = new PointF(
            rect.Left + (rect.Width / 2),
            rect.Top + ((rect.Height / 2) - (font.GetHeight(g) / 2)));
         g.DrawString(str, font, ticketBrush, pt.X, pt.Y, ticketStringFormat);
      }

      private void DrawTable(Graphics g, float x, float y, float cellWidth, float cellHeight, byte[] comb)
      {
         RectangleF rct = new RectangleF(x, y, cellWidth, cellHeight);
         int num;
         StringFormat stringFormat = new StringFormat();
         stringFormat.Alignment = StringAlignment.Center;
         //byte[] comb = (byte[]) lotoKomb.combs[0];

         for(int i=0; i<7; i++)
         {
            num = (int) comb[i];
            DrawCenterString(g, num.ToString().PadLeft(2, '0'), this.SerijaFont, rct, new SolidBrush(Color.Black), stringFormat); 

            rct.Offset(0, cellHeight);
         }
      }
	}
}
