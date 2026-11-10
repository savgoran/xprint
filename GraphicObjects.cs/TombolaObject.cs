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
    [Serializable]
    public class TombolaMeasure
    {
        public SizeF TicketSize = new SizeF(63.0f, 191f);
        public RectangleF SerijaRect = new RectangleF(2.7f, 0f, 9.0f, 4.5f);
        public RectangleF TablaRect = new RectangleF(15.0f, 0.0f, 15.0f, 4.5f);
        public RectangleF RbkRect = new RectangleF(35.0f, 0.0f, 28.0f, 4.5f);
        public Font SerijaFont = new Font("Arial", 9);
        public Font TablaFont = new Font("Arial", 9);
        public Font RbkFont = new Font("Arial", 9);
        public Font SMSFont = new Font("Arial", 12);

        public PointF KombPos = new PointF(0.0f, 0.0f);
        public SizeF KombSize = new SizeF(63.0f, 26.0f);
        public SizeF CellSize = new SizeF(7.0f, 7.0f);
        public float Gutter = 6.9f;
        public Font KombFont = new Font("Arial", 12);

        public TombolaMeasure()
        {
            //Default();
        }

        public void Default()
        {
            SizeF TicketSize = this.TicketSize;
            RectangleF SerijaRect = this.SerijaRect;
            RectangleF TablaRect = this.TablaRect;
            RectangleF RbkRect = this.RbkRect;
            Font SerijaFont = this.SerijaFont;
            Font TablaFont = this.TablaFont;
            Font RbkFont = this.RbkFont;

            PointF KombPos = this.KombPos;
            SizeF KombSize = this.KombSize;
            SizeF CellSize = this.CellSize;
            float Gutter = this.Gutter;
            Font KombFont = this.KombFont;
        }

        public void ConvertToPixels()
        {
            GraphicsUnitConverter guc = new GraphicsUnitConverter(96);

            this.TicketSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, TicketSize);
            this.SerijaRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, SerijaRect);
            this.TablaRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, TablaRect);
            this.RbkRect = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, RbkRect);
            this.KombPos = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, KombPos);
            this.KombSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, KombSize);
            this.Gutter = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, Gutter);
            this.CellSize = guc.Convert(GraphicsUnit.Pixel, GraphicsUnit.Millimeter, CellSize);
        }
    }

	/// <summary>
	/// Summary description for TombolaObject.
	/// </summary>
	[Serializable]
    public class TombolaObject: GraphicObject
    {
        private TombolaMeasure tombolaMeasure;
        private int kombCount;

        private TombolaInfo ticketInfo = new TombolaInfo();
      
        #region Constructors

        public TombolaObject(float x, float y)
        {
            this.tombolaMeasure = LoadTombolaMeasure(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tombola1944.gof");
            this.SourceUnit = GraphicsUnit.Millimeter;
            this.Position = new PointF(x, y);
            this.SetSize(new SizeF(this.TicketSize.Width, this.TicketSize.Height));
        }

        #endregion

        #region Properties

        public SizeF TicketSize
        {
            get { return this.tombolaMeasure.TicketSize; }
            set
            {
                this.tombolaMeasure.TicketSize = value;
                this.SetSize(this.tombolaMeasure.TicketSize);
            }
        }

        public RectangleF SerijaRect
        {
            get { return this.tombolaMeasure.SerijaRect; }
            set
            {
                this.tombolaMeasure.SerijaRect = value;
            }
        }

        public RectangleF TablaRect
        {
            get { return this.tombolaMeasure.TablaRect; }
            set
            {
                this.tombolaMeasure.TablaRect = value;
            }
        }

        public RectangleF RbkRect
        {
            get { return this.tombolaMeasure.RbkRect; }
            set
            {
                this.tombolaMeasure.RbkRect = value;
            }
        }

        public Font SerijaFont
        {
            get { return this.tombolaMeasure.SerijaFont; }
            set
            {
                this.tombolaMeasure.SerijaFont = value;
            }
        }

        public Font TablaFont
        {
            get { return this.tombolaMeasure.TablaFont; }
            set
            {
                this.tombolaMeasure.TablaFont = value;
            }
        }

        public Font RbkFont
        {
            get { return this.tombolaMeasure.RbkFont; }
            set
            {
                this.tombolaMeasure.RbkFont = value;
            }
        }

        public PointF KombPos
        {
            get { return this.tombolaMeasure.KombPos; }
            set
            {
                this.tombolaMeasure.KombPos = value;
            }
        }

        public SizeF KombSize
        {
            get { return this.tombolaMeasure.KombSize; }
            set
            {
                this.tombolaMeasure.KombSize = value;
            }
        }

        public SizeF CellSize
        {
            get { return this.tombolaMeasure.CellSize; }
            set
            {
                this.tombolaMeasure.CellSize = value;
            }
        }

        public float Gutter
        {
            get { return this.tombolaMeasure.Gutter; }
            set
            {
                this.tombolaMeasure.Gutter = value;
            }
        }

        public int KombCount
        {
            get { return this.kombCount; }
            set
            {
                this.kombCount = value;
            }
        }

        public Font KombFont
        {
            get { return this.tombolaMeasure.KombFont; }
            set
            {
                this.tombolaMeasure.KombFont = value;
            }
        }

        #endregion


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
            if (this.Rotation != 0)
            {
                m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
                g.Transform = m;
            }

            if (Container != null)
            {
                if (Container.DesignMode)
                {
                    RectangleF rect = new RectangleF(0f, 0f, 10f, 8f);
                    rect.Offset(this.X + 4, this.Y + 4);
                    g.FillRectangle(new SolidBrush(Color.DarkGray), rect);

                    string str = this.IdMark.ToString().PadLeft(2, '0');
                    Font strFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
                    PointF strPoint = new PointF(rect.Left + (rect.Width / 2), rect.Top + ((rect.Height / 2) - (strFont.GetHeight(g) / 2)));
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    g.DrawString(str, strFont, new SolidBrush(Color.White), strPoint, stringFormat);
                }
            }

            Pen defaultPen = new Pen(Color.Black, 0.1f);
            if (drawLines)
            {
                g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);
                g.TranslateTransform(this.X, this.Y);
            }

            DrawCenterString(g, "Tabla " + ticketInfo.TablaBr.ToString().PadLeft(3, '0'), this.TablaFont, Rectangle.Round(TablaRect), ticketBrush, ticketStringFormat);
            
            int i = 0;
            PointF kPos = KombPos;
            for (i = 0; i < 6; i++)
            {
                DrawTable(kPos, g, ticketInfo.GetKomb(i), ticketBrush, ticketStringFormat, drawLines, 1, i+1);
                kPos = new PointF(KombPos.X, kPos.Y + KombSize.Height + Gutter);
            }

            g.EndContainer(graphicsContainer);
        }

        public override void Print(Graphics g, int id)
        {
            bool drawLines = true;
            StringFormat ticketStringFormat = new StringFormat();
            ticketStringFormat.Alignment = StringAlignment.Center;
            Brush ticketBrush = new SolidBrush(Color.Black);

            ticketInfo.SetDataTombola(id);

            GraphicsContainer graphicsContainer = g.BeginContainer();
            g.PageUnit = this.SourceUnit;

            Matrix m = new Matrix();
            if (this.Rotation != 0)
            {
                m.RotateAt(this.Rotation, new PointF(this.X + (this.Width / 2), this.Y + (this.Height / 2)));
                g.Transform = m;
            }

            Pen defaultPen = new Pen(Color.Black, 0.1f);
            if (drawLines)
            {
                // g.DrawRectangle(defaultPen, this.X, this.Y, this.Width, this.Height);
                g.TranslateTransform(this.X, this.Y);
            }

            DrawCenterString(g, "Tabla " + id.ToString().PadLeft(3, '0'), this.TablaFont, Rectangle.Round(TablaRect), ticketBrush, ticketStringFormat);

            int i = 0;
            int rbk = (id - 1) * 6 + 1;
            PointF kPos = KombPos;
            for (i = 0; i < 6; i++)
            {
                DrawTable(kPos, g, ticketInfo.GetKomb(i), ticketBrush, ticketStringFormat, drawLines, this.IdMark + 20, rbk);
                kPos = new PointF(KombPos.X, kPos.Y + KombSize.Height + Gutter);
                rbk += 1;
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

        private void DrawTable(PointF pos, Graphics g, byte[] komb, Brush ticketBrush, StringFormat ticketStringFormat, bool drawLines, int serija, int rbk)
        {
            RectangleF cellRect = new RectangleF(pos, CellSize);
            RectangleF newSerijaRect = new RectangleF(pos, SerijaRect.Size);
            RectangleF newRbkRect = new RectangleF(pos, RbkRect.Size);
            cellRect.Offset(0, newSerijaRect.Height);
            newRbkRect.Offset(RbkRect.Left, 0);
            int i, num;
            StringFormat rightStringFormat = new StringFormat();
            rightStringFormat.Alignment = StringAlignment.Far;

            DrawCenterString(g, "S" + serija.ToString().PadLeft(3, '0'), this.SerijaFont, Rectangle.Round(newSerijaRect), ticketBrush, ticketStringFormat);
            DrawCenterString(g, "Kombinacija " + rbk.ToString().PadLeft(4, '0'), this.RbkFont, Rectangle.Round(newRbkRect), ticketBrush, ticketStringFormat);

            Pen defaultPen = new Pen(Color.Black, 0.1f);
            for (i = 0; i < 27; i++)
            {
                if ((i > 0) && ((i % 3) == 0))
                {
                    cellRect.Offset(CellSize.Width, -(CellSize.Height * 3));
                }

                num = (int)komb[i];
                if (num == 126)
                    num = 0;

                if (drawLines)
                {
                    g.DrawRectangle(defaultPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
                if (num != 0)
                {
                    DrawCenterString(g, num.ToString(), KombFont, cellRect, ticketBrush, ticketStringFormat);
                }
                cellRect.Offset(0, CellSize.Height);
            }
        }

        public TombolaMeasure LoadTombolaMeasure(string fileName)
        {
            TombolaMeasure tombolaMeasure = new TombolaMeasure();

            if (File.Exists(fileName))
            {
                Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                IFormatter binaryFormatter = new BinaryFormatter();
                tombolaMeasure = (TombolaMeasure)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return tombolaMeasure;
        }

	}

    /// <summary>
    /// Summary description for TombolaInfo.
    /// </summary>
    [Serializable]
    internal class TombolaInfo
    {
        private int serija = 4;
        private int rbk = 0;
        private int tablabr = 0;
        private ArrayList kombs = new ArrayList();

        public TombolaInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public byte[] GetKomb(int index)
        {
            if (index < kombs.Count)
            {
                return (byte[])kombs[index];
            }
            else
            {
                return (new byte[27] { 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126, 126 });
            }
        }

        public void SetData(int id)
        {
            if (id == -1)
            {
                this.serija = 1;
                this.rbk = 1;
                this.tablabr = 0;

                kombs.Clear();
                for (int i = 0; i < 6; i++)
                {
                    kombs.Add(new byte[27] { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 });
                }
                return;
            }

            MontoKomb mk = MontoKomb.GetMontoKomb(id);

            this.serija = 1; Convert.ToInt32(mk.ser);
            this.rbk = Convert.ToInt32(mk.rbk);
            this.tablabr = Convert.ToInt32(mk.kb);

            kombs.Clear();
            for (int i = 0; i < 6; i++)
            {
                kombs.Add(mk.combs[i]);
            }
        }

        public void SetDataTombola(int id)
        {

            if (id == -1)
            {
                this.serija = 1;
                this.rbk = 1;
                this.tablabr = 0;

                kombs.Clear();
                for (int i = 0; i < 6; i++)
                {
                    kombs.Add(new byte[27] { 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99, 99 });
                }
                return;
            }

            int from = 0;
            int to = 0;

            //this.serija = 2;
            this.rbk = id;
            this.tablabr = 0;

            // 1 je broj serije
            int startSerIndex = ((this.Serija - 1) * 3000);
            from = (startSerIndex + (((id - 1) * 6) + 1)) % 6000000;
            to = from + 5;


            //SqlConnection sqlConnection = new SqlConnection("workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source='.';persist security info=False;initial catalog=NewTombola");
            SqlConnection sqlConnection = new SqlConnection(ConfigurationSettings.AppSettings["TombolaConnectionString"]);
            SqlCommand sqlCommand = new SqlCommand("SELECT id, komb FROM komplet WHERE [Id] >= @od and [Id] <= @do", sqlConnection);

            sqlCommand.CommandType = CommandType.Text;

            sqlCommand.Parameters.Add("@od", from);
            sqlCommand.Parameters.Add("@do", to);

            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            kombs.Clear();
            while (dr.Read())
            {
                byte[] komb = Array.ConvertAll(dr["komb"].ToString().Split(new Char[] { ',' }), s => Convert.ToByte(s, 10));
                kombs.Add(komb);
            }

            sqlConnection.Close();
        }

        private int CalcKonBr()
        {
            int i = 0;
            int j = 0;
            int num = 0;
            int suma = 0;
            byte[] buff;
            int sign = -1;

            for (i = 0; i < (kombs.Count - 1); i++)
            {
                buff = (byte[])kombs[i];
                for (j = 0; j <= 26; j++)
                {
                    num = buff[j];
                    if (num == 126)
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
            get { return this.serija; }
            set { this.serija = value; }
        }

        public int Rbk
        {
            get { return this.rbk; }
            set { this.rbk = value; }
        }

        public int TablaBr
        {
            get { return this.tablabr; }
            set { this.tablabr = value; }
        }

        #endregion

    }
}
