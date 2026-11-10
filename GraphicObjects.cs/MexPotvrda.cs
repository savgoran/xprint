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
   [Serializable]
   public class PotvrdaMeasure
   {
      public SizeF PotvrdaSize = new SizeF(147, 85);
      public RectangleF barCodRect = new RectangleF(103, 5, 36, 17);
      public Font barcodFont = new Font("IDAutomationHC39M", 10);
      public RectangleF imeRect = new RectangleF(25, 25, 120, 8);
      public RectangleF identRect = new RectangleF(53, 46, 88, 8);
      public Font textFont = new Font("Courier New", 14.4f, FontStyle.Bold, GraphicsUnit.Point);
      public Font idFont = new Font("Arial", 12);
      public RectangleF idRect = new RectangleF(30, 10, 30, 8);
      
      public PotvrdaMeasure()
      {
      }

      public void Default()
      {
         barCodRect = new RectangleF(103, 5, 36, 17);
         barcodFont = new Font("IDAutomationHC39M", 10);
         imeRect = new RectangleF(25, 25, 120, 8);
         identRect = new RectangleF(53, 46, 88, 8);
         textFont = new Font("Courier New", 14.4f, FontStyle.Bold, GraphicsUnit.Point);
         idFont = new Font("Arial", 12);
         idRect = new RectangleF(30, 10, 30, 8);
      }

      public void ConvertToPixels()
      {
         GraphicsUnitConverter guc = new GraphicsUnitConverter(96);

         this.PotvrdaSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, PotvrdaSize);
         this.idRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, idRect);
         this.imeRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, imeRect);   
         this.identRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, identRect);
      }
   }
   
   /// <summary>
	/// Summary description for MexPotvrda.
	/// </summary>
	[Serializable]
   public class MexPotvrda: GraphicObject
	{

      private PotvrdaMeasure potvrdaMeasure;
      public int position = 0;

      /*
      private RectangleF barCodRect = new RectangleF(108, 5, 36, 17);
      private Font barcodFont = new Font("IDAutomationHC39M", 10);
      private RectangleF imeRect = new RectangleF(23, 25, 120, 8);
      private RectangleF identRect = new RectangleF(56, 46, 88, 8);
      private Font textFont = new Font("Courier New", 14.4f, FontStyle.Bold, GraphicsUnit.Point);
      private Font idFont = new Font("Arial", 12);
      private RectangleF idRect = new RectangleF(30, 10, 30, 8);
      */
      private PotvrdaInfo potvrdaInfo = new PotvrdaInfo();
      
      public MexPotvrda(float x, float y)
		{
			//
			// TODO: Add constructor logic here
			//
         this.potvrdaMeasure = LoadPotvrdaMeasure(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\potvrda.gof");
         this.SourceUnit = GraphicsUnit.Millimeter;
         
         this.Position = new PointF(x, y);
         this.SetSize(new SizeF(147, 85));
		}

      public override void Draw(Graphics g)
      {
         StringFormat potvrdaStringFormat = new StringFormat();
         potvrdaStringFormat.Alignment = StringAlignment.Center;
         
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
               StringFormat stringFormat = new StringFormat();
               stringFormat.Alignment = StringAlignment.Center;
               g.DrawString(str, strFont, new SolidBrush(Color.White), strPoint, stringFormat); 
            }
         }

         Pen defaultPen = new Pen(Color.Black, 0.1f);
         g.DrawRectangle(defaultPen, this.X, this.Y, potvrdaMeasure.PotvrdaSize.Width, potvrdaMeasure.PotvrdaSize.Height);
         g.TranslateTransform(this.X, this.Y);
         g.DrawRectangle(defaultPen, Rectangle.Round(potvrdaMeasure.idRect));
         g.DrawRectangle(defaultPen, Rectangle.Round(potvrdaMeasure.identRect));
         g.DrawRectangle(defaultPen, Rectangle.Round(potvrdaMeasure.imeRect));

         DrawCenterString(g, "(1234567)", potvrdaMeasure.barcodFont, potvrdaMeasure.barCodRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         
         potvrdaStringFormat.Alignment = StringAlignment.Near;
         DrawLeftString(g, "1", potvrdaMeasure.idFont, potvrdaMeasure.idRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         DrawLeftString(g, "GORAN SAVKIC", potvrdaMeasure.textFont, potvrdaMeasure.imeRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         DrawLeftString(g, "1234567", potvrdaMeasure.textFont, potvrdaMeasure.identRect, new SolidBrush(Color.Black), potvrdaStringFormat);

         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         potvrdaInfo.SetData(id);
         
         StringFormat potvrdaStringFormat = new StringFormat();
         potvrdaStringFormat.Alignment = StringAlignment.Center;
         
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

         int p = (this.position * 1000000) + Int32.Parse(potvrdaInfo.Rb);

         DrawCenterString(g, string.Format("({0})", p.ToString()), potvrdaMeasure.barcodFont, potvrdaMeasure.barCodRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         //DrawCenterString(g, string.Format("({0})", potvrdaInfo.Ident), potvrdaMeasure.barcodFont, potvrdaMeasure.barCodRect, new SolidBrush(Color.Black), potvrdaStringFormat);

         potvrdaStringFormat.Alignment = StringAlignment.Near;
         DrawLeftString(g, potvrdaInfo.Rb, potvrdaMeasure.idFont, potvrdaMeasure.idRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         DrawLeftString(g, potvrdaInfo.Ime, potvrdaMeasure.textFont, potvrdaMeasure.imeRect, new SolidBrush(Color.Black), potvrdaStringFormat);
         DrawLeftString(g, potvrdaInfo.Ident, potvrdaMeasure.textFont, potvrdaMeasure.identRect, new SolidBrush(Color.Black), potvrdaStringFormat);

         g.EndContainer(graphicsContainer);
      }

      private void DrawCenterString(Graphics g, string str, Font font, RectangleF rect, Brush ticketBrush, StringFormat ticketStringFormat)
      {
         PointF pt = new PointF(
            rect.Left + (rect.Width / 2),
            rect.Top + ((rect.Height / 2) - (font.GetHeight(g) / 2)));
         g.DrawString(str, font, ticketBrush, pt.X, pt.Y, ticketStringFormat);
      }

      private void DrawLeftString(Graphics g, string str, Font font, RectangleF rect, Brush ticketBrush, StringFormat ticketStringFormat)
      {
         PointF pt = new PointF(
            rect.Left,
            rect.Top + ((rect.Height / 2) - (font.GetHeight(g) / 2)));
         g.DrawString(str, font, ticketBrush, pt.X, pt.Y, ticketStringFormat);
      }

      public PotvrdaMeasure LoadPotvrdaMeasure(string fileName)
      {
         PotvrdaMeasure potvrdaMeasure = new PotvrdaMeasure();

         if(File.Exists(fileName))
         {
            Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            IFormatter binaryFormatter = new BinaryFormatter();
            potvrdaMeasure = (PotvrdaMeasure) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
         }

         return potvrdaMeasure;
      }

      public void SavePotvrdaMeasure(string fileName)
      {
         Stream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
         IFormatter binaryFormatter = new BinaryFormatter();
         binaryFormatter.Serialize(fileStream, this.potvrdaMeasure);
         fileStream.Close();
      }

      public void MeasureDefaults()
      {
         this.potvrdaMeasure.Default();
      }

      #region Properties

      public SizeF PotvrdaSize
      {
         get {return potvrdaMeasure.PotvrdaSize;}
         set 
         {
            potvrdaMeasure.PotvrdaSize = value;
            this.SetSize(potvrdaMeasure.PotvrdaSize);
         }
      }

      public RectangleF IdRect
      {
         get {return this.potvrdaMeasure.idRect;}
         set {this.potvrdaMeasure.idRect = value;}
      }

      public RectangleF ImeRect
      {
         get {return this.potvrdaMeasure.imeRect;}
         set {this.potvrdaMeasure.imeRect = value;}
      }

      public RectangleF IdentRect
      {
         get {return this.potvrdaMeasure.identRect;}
         set {this.potvrdaMeasure.identRect = value;}
      }

      public RectangleF BarCodeRect
      {
         get {return this.potvrdaMeasure.barCodRect;}
         set {this.potvrdaMeasure.barCodRect = value;}
      }

      public Font IdFont
      {
         get {return this.potvrdaMeasure.idFont;}
         set 
         {
            this.potvrdaMeasure.idFont = value;
         }
      }

      public Font TextFont
      {
         get {return this.potvrdaMeasure.textFont;}
         set 
         {
            this.potvrdaMeasure.textFont = value;
         }
      }

      #endregion

	}

   [Serializable]
   internal class PotvrdaInfo
   {
      private string rb = "";
      private string ime = "";
      private string ident = "";
      
      public PotvrdaInfo()
      {
      }

      public void SetData(int id)
      {
         SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["PotvrdaConnectionString"]);
         //SqlConnection sqlConnection = new SqlConnection("workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source='.';persist security info=False;initial catalog=Mex");
         SqlCommand sqlCommand = new SqlCommand("SELECT [Id], Ime, Ident FROM Penzioneri WHERE [Id] = @Id", sqlConnection);

         sqlCommand.CommandType = CommandType.Text;

         sqlCommand.Parameters.Add("@Id", id);

         sqlConnection.Open();
         SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

         while(dr.Read())
         {
            this.Rb = dr["Id"].ToString();
            this.Ime = dr["Ime"].ToString();
            this.Ident = dr["Ident"].ToString();
         }

         sqlConnection.Close();
      }

      #region Properties

      public string Rb
      {
         get {return this.rb;}
         set {this.rb = value;}
      }
      
      public string Ime
      {
         get {return this.ime;}
         set {this.ime = value;}
      }

      public string Ident
      {
         get {return this.ident;}
         set {this.ident = value;}
      }

      #endregion


   }
}
