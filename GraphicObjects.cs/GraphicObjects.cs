using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GraphicObjects
{

   /// <summary>
	/// Summary description for GraphicObjects.
	/// </summary>
	[Serializable]
   public class GraphicObjectsCollection: CollectionBase
	{
      public PrintPageSettings CollectionPageSettings;
      public int Depth = 500;
      public float HorizontalResolution = 96;
      public float VerticalResolution = 96;
      [NonSerialized] private bool designMode = false;
      
      public GraphicObjectsCollection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

      public void DrawObjects(Graphics g, float scale)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         
         g.ScaleTransform(scale, scale);
         g.PageUnit = GraphicsUnit.Millimeter;

         for(int i = 0; i <= (this.InnerList.Count - 1); i++)
         {
            //g.PageUnit = ((GraphicObject) InnerList[i]).SourceUnit;
            ((GraphicObject) InnerList[i]).Draw(g);
         }

         g.EndContainer(graphicsContainer);
      }

      public void DrawSelectedObjects(Graphics g, object[] graphicObjects, float scale)
      {
         if(graphicObjects == null) return;
         
         GraphicsContainer graphicsContainer = g.BeginContainer();

         g.ScaleTransform(scale, scale);
         g.PageUnit = GraphicsUnit.Millimeter;

         foreach(GraphicObject go in graphicObjects)
         {
            //g.PageUnit = go.SourceUnit;
            RectangleF rect = new RectangleF(go.LeftUpPoint, new Size(4, 4));
            rect.Offset(-2, -2);
            g.DrawRectangle(new Pen(Color.Blue, 0.1f), rect.X, rect.Y, rect.Width, rect.Height);
         }

         g.EndContainer(graphicsContainer);
      }

      public void PrintObjects(int currentPage, Graphics g)
      {
         GraphicsContainer graphicsContainer = g.BeginContainer();
         g.PageUnit = GraphicsUnit.Millimeter;
         for(int i = 0; i <= (this.InnerList.Count - 1); i++)
         {
            
            GraphicObject go = ((GraphicObject) InnerList[i]); //.Draw(g);
            //g.PageUnit = go.SourceUnit;
            if(InnerList[i] is TicketObject)
            {
               go.Print(g, currentPage + ((go.IdMark-1) * this.Depth));
            }
            if(InnerList[i] is MexPotvrda)
            {
               // ponavljanje 4 puta
               (go as MexPotvrda).position = ((currentPage - 1) % 4) + 1;
               go.Print(g, (decimal.ToInt32(decimal.Divide((decimal) currentPage - 1, 4)) + 1) + ((go.IdMark-1) * this.Depth));
            }
            if (InnerList[i] is MercatorMexPotvrda)
            {
               // ponavljanje 4 puta
               (go as MercatorMexPotvrda).position = ((currentPage - 1) % 4) + 1;
               go.Print(g, (decimal.ToInt32(decimal.Divide((decimal)currentPage - 1, 4)) + 1) + ((go.IdMark - 1) * this.Depth));
            }
            if(InnerList[i] is LotoTicket)
            {
               go.Print(g, currentPage + ((go.IdMark-1) * this.Depth));
            }
            if(InnerList[i] is LotoTicket2)
            {
               go.Print(g, currentPage + ((go.IdMark-1) * this.Depth));
            }
            if(InnerList[i] is LotoTicket4)
            {
               go.Print(g, currentPage + ((go.IdMark-1) * this.Depth));
            }
            if (InnerList[i] is TombolaObject)
            {
                go.Print(g, currentPage);
            }
            //t.Draw(currentPage + ((go.IdMark-1) * this.Depth), g, go.X, go.Y, go.Rotation, 1.0f, false);
         }
         g.EndContainer(graphicsContainer);
      }

      public GraphicObject FindObjectAtPoint(PointF pt)
      {
         GraphicObject go;
         for(int i = 0; i <= (this.InnerList.Count - 1); i++)
         {
            go = (GraphicObject) InnerList[i];
            if(go.HitTest(pt))
            {
               return go;
            }
         }
         return null;
      }

      public object[] FindObjectsInRect(RectangleF rect)
      {
         GraphicObject go;
         ArrayList al = new ArrayList();

         for(int i = 0; i < this.InnerList.Count; i++)
         {
            go = (GraphicObject) InnerList[i];
            if(go.HitRectTest(rect))
            {
               al.Add(go);
            }
         }
         return al.ToArray();
      }

      public int Add(GraphicObject value)
      {
         value.Container = this;
         value.IdMark = this.Count + 1;
         return this.List.Add(value);
      }

      public void Insert(int index, GraphicObject value)
      {
         value.Container = this;
         this.List.Insert(index, value);
      }

      public void Remove(GraphicObject value)
      {
         this.List.Remove(value);
      }

      public GraphicObject Item(int index)
      {
         return (GraphicObject) this.List[index];
      }

      public bool Contains(GraphicObject value)
      {
         return this.List.Contains(value);
      }

      public int IndexOf(GraphicObject value)
      {
         return this.List.IndexOf(value);
      }

      public bool DesignMode
      {
         get {return this.designMode;}
         set {this.designMode = value;}
      }

      public TicketObject LoadFromFile(string fileName)
      {
         TicketObject ticketObject = null;
         
         if(File.Exists(fileName))
         {
            IFormatter formatter = new BinaryFormatter(); 
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            ticketObject = (TicketObject) formatter.Deserialize(stream);
            stream.Close();
         }

         return ticketObject;
      }
	}

   [Serializable]
   public class PrintPageSettings
   {
      public string PaperName;
      public Size PageSize;
      public Rectangle PaperMargins;
      public bool Landscape;
      public int PageSizeIndex;
      
      public PrintPageSettings(PageSettings ps, int paperSizeIndex)
      {
         this.PaperName = ps.PaperSize.PaperName;
         this.PageSize = new Size(ps.PaperSize.Width, ps.PaperSize.Height);
         this.PaperMargins = new Rectangle(ps.Margins.Left, ps.Margins.Top, ps.Margins.Right, ps.Margins.Bottom);
         this.Landscape = ps.Landscape;
         this.PageSizeIndex = (int) paperSizeIndex;
      }

      public PageSettings GetPageSettings(PageSettings ps)
      {
         //PageSettings ps = new PageSettings();
         ps.PaperSize = ps.PrinterSettings.PaperSizes[this.PageSizeIndex];
         ps.Margins = new Margins(
            this.PaperMargins.Left, 
            this.PaperMargins.Top,
            this.PaperMargins.Width,
            this.PaperMargins.Height);
         ps.Landscape = this.Landscape;
         return ps;
      }

   }
}
