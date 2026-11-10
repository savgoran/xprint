using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for TextObject.
	/// </summary>
	[Serializable]
   public class TextObject: GraphicObject
	{
		private string text = "";
      private Font font;
      private Color color = Color.Black;
      
      #region Constructors
      
      public TextObject(PointF textPosition, string text, Font textFont, Color textColor)
		{
			this.Position = textPosition;
         this.text = text;
         this.Font = textFont;
         this.color = textColor;
		}

      public TextObject(float x, float y, string text, Font textFont, Color textColor)
      {
         this.Position = new PointF(x, y);
         this.text = text;
         this.Font = textFont;
         this.color = textColor;
      }

      #endregion

      public Font Font
      {
         get {return this.font;}
         set {this.font = value;}
      }

      public string Text
      {
         get {return this.text;}
         set {this.text = value;}
      }

      public Color Color
      {
         get {return this.color;}
         set {this.color = value;}
      }

      public override void Draw(Graphics g)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Pixel;
         if(this.Rotation != 0)
         {
            Matrix m = new Matrix();
            m.RotateAt(this.Rotation, this.Center);
            g.Transform = m;
         }
         SizeF textSize = g.MeasureString(this.Text, this.Font);
         this.SetSize(textSize);
         g.DrawString(this.Text, this.Font, new SolidBrush(this.Color), this.Position);
         g.EndContainer(graphicsContainer);
      }

      public override void Print(Graphics g, int id)
      {
         this.Draw(g);
      }

	}
}
