using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace GraphicObjects
{
	public delegate void TicketChangedHandler(object sender, EventArgs e);
   
   [Serializable]
   public class TicketMeasure
   {
      public SizeF TicketSize = new SizeF(74.248f, 191.601f);
      public RectangleF SerijaRect = new RectangleF(2.069f, 30.976f, 16.729f, 7.523f);
      public RectangleF RbkRect = new RectangleF(20.798f, 30.976f, 32.789f, 7.523f);
      public RectangleF KonBrRect = new RectangleF(55.614f, 30.976f, 16.729f, 7.523f);
      public RectangleF SMSRect = new RectangleF(18.689f, 183.424f, 53.648f, 6.000f);
      public Font SerijaFont = new Font("Arial", 12);
      public Font RbkFont = new Font("Arial", 12);
      public Font KonBrFont = new Font("Arial", 12);
      public Font SMSFont = new Font("Arial", 12);

      public PointF KombPos = new PointF(2.069f, 40.626f);
      public SizeF KombSize = new SizeF(70.247f, 21.69f);
      public SizeF CellSize = new SizeF(7.805f, 7.23f);
      public float Gutter = 2.096f;
      public Font KombFont = new Font("Arial", 12);

      public TicketMeasure()
      {
         //Default();
      }

      public void Default()
      {
         SizeF TicketSize = new SizeF(74.248f, 191.601f);
         RectangleF SerijaRect = new RectangleF(2.069f, 30.976f, 16.729f, 7.523f);
         RectangleF RbkRect = new RectangleF(20.798f, 30.976f, 32.789f, 7.523f);
         RectangleF KonBrRect = new RectangleF(55.614f, 30.976f, 16.729f, 7.523f);
         RectangleF SMSRect = new RectangleF(18.689f, 183.424f, 53.648f, 6.000f);
         Font SerijaFont = new Font("Arial", 12);
         Font RbkFont = new Font("Arial", 12);
         Font KonBrFont = new Font("Arial", 12);
         Font SMSFont = new Font("Arial", 12);

         PointF KombPos = new PointF(2.069f, 40.626f);
         SizeF KombSize = new SizeF(70.247f, 21.69f);
         SizeF CellSize = new SizeF(7.805f, 7.23f);
         float Gutter = 2.096f;
         Font KombFont = new Font("Arial", 12);

         //ConvertToPixels();
      }

      public void ConvertToPixels()
      {
         GraphicsUnitConverter guc = new GraphicsUnitConverter(96);

         this.TicketSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, TicketSize);
         this.SerijaRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, SerijaRect);
         this.RbkRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, RbkRect);   
         this.KonBrRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, KonBrRect);
         this.SMSRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, SMSRect);

         this.KombPos = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, KombPos);
         this.KombSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, KombSize);
         this.Gutter = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, Gutter);
         this.CellSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, CellSize);
      }
   }
   
   /// <summary>
	/// Summary description for TicketObject.
	/// </summary>
	[Serializable]
   public class TicketObject: GraphicObject
	{
		private TicketMeasure ticketMeasure;
      private int kombCount;
      
      private TicketInfo ticketInfo = new TicketInfo();
      
      public TicketObject(float x, float y)
      {
         //
         // TODO: Add constructor logic here
         //

         this.ticketMeasure = LoadTicketMeasure(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tombola.gof");
         this.SourceUnit = GraphicsUnit.Millimeter;
         //this.ticketMeasure.ConvertToPixels();
         
         this.Position = new PointF(x, y);
         this.SetSize(new SizeF(this.TicketSize.Width, this.TicketSize.Height));
      }

      #region Properties

      public SizeF TicketSize
      {
         get {return this.ticketMeasure.TicketSize;}
         set 
         {
            this.ticketMeasure.TicketSize = value;
            this.SetSize(this.ticketMeasure.TicketSize);
         }
      }

      public RectangleF SerijaRect
      {
         get {return this.ticketMeasure.SerijaRect;}
         set 
         {
            this.ticketMeasure.SerijaRect = value;
         }
      }

      public RectangleF RbkRect
      {
         get {return this.ticketMeasure.RbkRect;}
         set 
         {
            this.ticketMeasure.RbkRect = value;
         }
      }

      public RectangleF KonBrRect
      {
         get {return this.ticketMeasure.KonBrRect;}
         set 
         {
            this.ticketMeasure.KonBrRect = value;
         }
      }

      public RectangleF SMSRect
      {
         get {return this.ticketMeasure.SMSRect;}
         set 
         {
            this.ticketMeasure.SMSRect = value;
         }
      }

      public Font SerijaFont
      {
         get {return this.ticketMeasure.SerijaFont;}
         set 
         {
            this.ticketMeasure.SerijaFont = value;
         }
      }

      public Font RbkFont
      {
         get {return this.ticketMeasure.RbkFont;}
         set 
         {
            this.ticketMeasure.RbkFont = value;
         }
      }
      
      public Font KonBrFont
      {
         get {return this.ticketMeasure.KonBrFont;}
         set 
         {
            this.ticketMeasure.KonBrFont = value;
         }
      }

      public Font SMSFont
      {
         get {return this.ticketMeasure.SMSFont;}
         set 
         {
            this.ticketMeasure.SMSFont = value;
         }
      }

      public PointF KombPos
      {
         get {return this.ticketMeasure.KombPos;}
         set 
         {
            this.ticketMeasure.KombPos = value;
         }
      }

      public SizeF KombSize
      {
         get {return this.ticketMeasure.KombSize;}
         set 
         {
            this.ticketMeasure.KombSize = value;
         }
      }

      public SizeF CellSize
      {
         get {return this.ticketMeasure.CellSize;}
         set 
         {
            this.ticketMeasure.CellSize = value;
         }
      }

      public float Gutter
      {
         get {return this.ticketMeasure.Gutter;}
         set 
         {
            this.ticketMeasure.Gutter = value;
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
         get {return this.ticketMeasure.KombFont;}
         set 
         {
            this.ticketMeasure.KombFont = value;
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

      //public override void Draw(int id, Graphics g, float x, float y, float angle, float scale, bool drawLines)
      public override void Draw(Graphics g)
      {
         bool drawLines = true;
         StringFormat ticketStringFormat = new StringFormat();
         ticketStringFormat.Alignment = StringAlignment.Center;
         Brush ticketBrush = new SolidBrush(Color.Black);
         
         ticketInfo.SetData(-1);

         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = this.SourceUnit;

         Matrix m = new Matrix();
         if(this.Rotation != 0)
         {
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }

         //g.TranslateTransform(this.X, this.Y);

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
               StringFormat stringFormat = new StringFormat();
               stringFormat.Alignment = StringAlignment.Center;
               g.DrawString(str, strFont, new SolidBrush(Color.White), strPoint, stringFormat); 
            }
         }

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         if(drawLines)
         {
            g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);
            g.TranslateTransform(this.X, this.Y);
            g.DrawRectangle(defaultPen, Rectangle.Round(SerijaRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(RbkRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(KonBrRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(SMSRect));
         }

         DrawCenterString(g, ticketInfo.Serija.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(SerijaRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.Rbk.ToString().PadLeft(7, '0'), this.RbkFont, Rectangle.Round(RbkRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.KonBr.ToString().PadLeft(5, '0'), this.KonBrFont, Rectangle.Round(KonBrRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, 
            string.Format("TOPV {0} {1} {2}", 
            new object[] {
                            ticketInfo.Serija.ToString().PadLeft(3, '0'), 
                            ticketInfo.Rbk.ToString().PadLeft(7, '0'), 
                            ticketInfo.KonBr.ToString().PadLeft(5, '0')
                         }), this.SMSFont, Rectangle.Round(SMSRect), ticketBrush, ticketStringFormat);
         
         int i = 0;
         PointF kPos = KombPos;
         for(i = 0; i < 6; i++)
         {
            DrawTable(kPos, g, ticketInfo.GetKomb(i), ticketBrush, ticketStringFormat, drawLines);
            kPos = new PointF(KombPos.X, kPos.Y + KombSize.Height + Gutter);
         }

         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         bool drawLines = false;
         StringFormat ticketStringFormat = new StringFormat();
         ticketStringFormat.Alignment = StringAlignment.Center;
         Brush ticketBrush = new SolidBrush(Color.Black);
         
         ticketInfo.SetData(id);
         
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = this.SourceUnit;

         //g.ScaleTransform(scale, scale);

         Matrix m = new Matrix();
         if(this.Rotation != 0)
         {
            m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
            g.Transform = m;
         }

         g.TranslateTransform(this.X, this.Y);

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         if(drawLines)
         {
            g.DrawRectangle(defaultPen, this.X, this.Y, this.TicketSize.Width, this.TicketSize.Height);
            g.TranslateTransform(this.X, this.Y);
            g.DrawRectangle(defaultPen, Rectangle.Round(SerijaRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(RbkRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(KonBrRect));
            g.DrawRectangle(defaultPen, Rectangle.Round(SMSRect));
         }

         DrawCenterString(g, ticketInfo.Serija.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(SerijaRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.Rbk.ToString().PadLeft(7, '0'), this.RbkFont, Rectangle.Round(RbkRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, ticketInfo.KonBr.ToString().PadLeft(5, '0'), this.KonBrFont, Rectangle.Round(KonBrRect), ticketBrush, ticketStringFormat);
         DrawCenterString(g, 
            string.Format("TOPV {0} {1} {2}", 
            new object[] {
                            ticketInfo.Serija.ToString().PadLeft(3, '0'), 
                            ticketInfo.Rbk.ToString().PadLeft(7, '0'), 
                            ticketInfo.KonBr.ToString().PadLeft(5, '0')
                         }), this.SMSFont, Rectangle.Round(SMSRect), ticketBrush, ticketStringFormat);
         
         int i = 0;
         PointF kPos = KombPos;
         for(i = 0; i < 6; i++)
         { 
            DrawTable(kPos, g, ticketInfo.GetKomb(i), ticketBrush, ticketStringFormat, drawLines);
            kPos = new PointF(KombPos.X, kPos.Y + KombSize.Height + Gutter);
         }

         g.EndContainer(graphicsContainer);
      }

      private void DrawCenterString(Graphics g, string str, Font font, RectangleF rect, Brush ticketBrush, StringFormat ticketStringFormat)
      {
         PointF pt = new PointF(
            rect.Left + (rect.Width / 2),
            rect.Top + ((rect.Height / 2) - (font.GetHeight(g) / 2)));
         g.DrawString(str, font, ticketBrush, pt.X, pt.Y, ticketStringFormat);
      }

      private void DrawTable(PointF pos, Graphics g, byte[] komb, Brush ticketBrush, StringFormat ticketStringFormat, bool drawLines)
      {
         RectangleF cellRect = new RectangleF(pos, CellSize);
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
               DrawCenterString(g, num.ToString(), KombFont, cellRect, ticketBrush, ticketStringFormat);
            }
            cellRect.Offset(0, CellSize.Height);
         }
      }

      public TicketMeasure LoadTicketMeasure(string fileName)
      {
         TicketMeasure ticketMeasure = new TicketMeasure();

         if(File.Exists(fileName))
         {
            Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter binaryFormatter = new BinaryFormatter();
            ticketMeasure = (TicketMeasure) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
         }

         return ticketMeasure;
      }

      public void SaveTicketMeasure(string fileName)
      {
         Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
         IFormatter binaryFormatter = new BinaryFormatter();
         binaryFormatter.Serialize(fileStream, this.ticketMeasure);
         fileStream.Close();
      }

      public void MeasureDefaults()
      {
         this.ticketMeasure.Default();
      }

      public event TicketChangedHandler TicketChanged;
	}

   /// <summary>
   /// Summary description for TicketInfo.
   /// </summary>
   [Serializable]
   internal class TicketInfo
   {
      private int serija = 4;
      private int rbk = 0;
      private int konbr = 0;
      private ArrayList kombs = new ArrayList();

      public TicketInfo()
      {
         //
         // TODO: Add constructor logic here
         //
      }

      public byte[] GetKomb(int index)
      {
         if(index < kombs.Count)
         {
            return (byte[]) kombs[index];
         }
         else
         {
            return (new byte[27] {126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126});
         }
      }
      
      public void SetData(int id)
      {
         if(id == -1)
         {
            //this.serija = 1;
            this.rbk = 1;
            this.konbr = 0;

            kombs.Clear();
            for(int i = 0; i < 6; i++)
            {
               kombs.Add(new byte[27] {99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99});
            }
            return;
         }

         MontoKomb mk = MontoKomb.GetMontoKomb(id);

         this.serija = 1; Convert.ToInt32(mk.ser);
         this.rbk = Convert.ToInt32(mk.rbk);
         this.konbr = Convert.ToInt32(mk.kb);

         kombs.Clear();
         for(int i = 0; i < 6; i++)
         {
            kombs.Add(mk.combs[i]);
         }
      }
      
      public void SetDataTopVolley(int id)
      {

         if(id == -1)
         {
            //this.serija = 1;
            this.rbk = 1;
            this.konbr = 0;

            kombs.Clear();
            for(int i = 0; i < 6; i++)
            {
               kombs.Add(new byte[27] {99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99});
            }
            return;
         }

         int from = 0;
         int to = 0;
         
         //this.serija = 2;
         this.rbk = id;
         this.konbr = 0;

         // 1 je broj serije
         int startSerIndex = ((this.Serija - 1) * 3000);
         from = (startSerIndex + (((id - 1) * 6) + 1)) % 6000000;
         to = from + 5;

         
         //SqlConnection sqlConnection = new SqlConnection("workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source='.';persist security info=False;initial catalog=NewTombola");
         SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["TicketConnectionString"]);
         SqlCommand sqlCommand = new SqlCommand("SELECT Sadrzaj FROM Kombinacije WHERE [Id] >= @od and [Id] <= @do", sqlConnection);

         sqlCommand.CommandType = CommandType.Text;

         sqlCommand.Parameters.Add("@od", from);
         sqlCommand.Parameters.Add("@do", to);

         sqlConnection.Open();
         SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

         kombs.Clear();
         while(dr.Read())
         {
            byte[] komb = new byte[27];
            dr.GetBytes(0, 0, komb, 0, 27);
            kombs.Add(komb);
         }

         sqlConnection.Close();

         konbr = CalcKonBr();
      }

      private int CalcKonBr()
      {
         int i = 0;
         int j = 0;
         int num = 0;
         int suma = 0;
         byte[] buff;
         int sign = -1;

         for(i = 0; i < (kombs.Count - 1); i++)
         {
            buff = (byte[]) kombs[i];
            for(j = 0; j <= 26; j++)
            {
               num = buff[j];
               if(num == 126)
                  num = 0;
               
               sign = sign * -1;
               num = num * sign;
               suma = suma + num;
            }
         }

         return Math.Abs(suma % 999);
      }

      #region Properties

      public int Serija
      {
         get {return this.serija;}
         set {this.serija = value;}
      }

      public int Rbk
      {
         get {return this.rbk;}
         set {this.rbk = value;}
      }

      public int KonBr
      {
         get {return this.konbr;}
         set {this.konbr = value;}
      }

      #endregion

   }
}
