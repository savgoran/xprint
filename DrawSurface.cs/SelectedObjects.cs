using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using GraphicObjects;

namespace DrawSurface
{
	public delegate void SelectedObjectsCollectionChangedEventHandler(object sender, EventArgs e);
   
   /// <summary>
	/// Summary description for SelectedObjects.
	/// </summary>
	public class SelectedObjectsCollection
	{
		private ArrayList selectedObjects = new ArrayList();
      private PointF dragPoint = PointF.Empty;
      
      public SelectedObjectsCollection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

      public void Add(GraphicObject gObj, bool isShift, bool isCtrl)
      {
         if(gObj == null)
         {
            if(!isShift)
            {
               this.selectedObjects.Clear();
               OnSelectedObjectsCollectionChanged(new EventArgs());
            }
            return;
         }

         if(isShift)
         {
            if(this.selectedObjects.Contains(gObj))
            {
               this.selectedObjects.Remove(gObj);
            }
            else
            {
               this.selectedObjects.Add(gObj);
            }
         }
         else
         {
            if(!this.selectedObjects.Contains(gObj))
            {
               this.selectedObjects.Clear();
               this.selectedObjects.Add(gObj);
            }
         }
         
         OnSelectedObjectsCollectionChanged(new EventArgs());
      }

      public void Add(object[] gObjs, bool isShift)
      {
         if(!isShift)
         {
            this.selectedObjects.Clear();
         }

         for(int i = 0; i < gObjs.Length; i++)
         {
            if(!this.selectedObjects.Contains(gObjs[i]))
            {
               this.selectedObjects.Add(gObjs[i]);
            }
         }
         OnSelectedObjectsCollectionChanged(new EventArgs());
      }

      public void Clear()
      {
         this.selectedObjects.Clear();
         OnSelectedObjectsCollectionChanged(new EventArgs());
      }

      public GraphicObject Item(int index)
      {
         return (GraphicObject) this.selectedObjects[index];
      }

      public int Count
      {
         get {return this.selectedObjects.Count;}
      }

      public PointF DragPoint
      {
         get {return this.dragPoint;}
         set {this.dragPoint = value;}
      }

      public RectangleF SelectedRect
      {
         get 
         {
            RectangleF rectF = RectangleF.Empty;
            if(this.selectedObjects.Count > 0)
            {
               rectF = (this.selectedObjects[0] as GraphicObject).Bounds;
               for(int i = 1; i < this.selectedObjects.Count; i++)
               {
                  GraphicObject go = (GraphicObject) this.selectedObjects[i];
                  rectF = RectangleF.Union(rectF, go.Bounds);
               }
            }
            return rectF;
         }
      }

      public object[] ToArray()
      {
         return this.selectedObjects.ToArray();
      }

      public void MoveObjects(PointF newPt)
      {
         PointF diff = new PointF((this.dragPoint.X - newPt.X) * -1, (this.dragPoint.Y - newPt.Y) * -1);
         this.dragPoint = newPt;
         GraphicObject go;

         for(int i = 0; i < this.selectedObjects.Count; i++)
         {
            go = (GraphicObject) this.selectedObjects[i];
            go.Offset(diff);
         }
         OnSelectedObjectsCollectionChanged(new EventArgs());
      }

      public void RotateObjects()
      {
         GraphicObject go;
         RectangleF sr = this.SelectedRect;
         PointF rotationPt = new PointF(sr.Left + (sr.Width / 2), sr.Top + (sr.Height / 2));

         for(int i = 0; i < this.selectedObjects.Count; i++)
         {
            go = (GraphicObject) this.selectedObjects[i];
            go.SetPositionFromRotation(15.0f, rotationPt);
         }
         OnSelectedObjectsCollectionChanged(new EventArgs());
      }

      public void OnSelectedObjectsCollectionChanged(EventArgs e)
      {
         if(SelectedObjectCollectionChanged != null)
         {
            SelectedObjectCollectionChanged(this, e);
         }
      }

      public event SelectedObjectsCollectionChangedEventHandler SelectedObjectCollectionChanged;
	}
}
