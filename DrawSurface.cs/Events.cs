using System;
using System.Drawing;
using GraphicObjects;

namespace DrawSurface
{
   public delegate void DrawSurfaceChangedEventHandler(object sender, System.EventArgs e);

   public class SelectedObjectChangedEventArgs: System.EventArgs
   {
      public PointF SelectedObjectsPosition;

      public SelectedObjectChangedEventArgs()
      {
      }
   }

   public delegate void SelectedObjectChangedEventHandler(object sender, SelectedObjectChangedEventArgs e);
}
