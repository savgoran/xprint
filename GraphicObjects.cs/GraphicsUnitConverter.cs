using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicObjects
{
   public class GraphicsUnitConverter
   {
      private int dpiX = 300;

      public GraphicsUnitConverter(int dpiX)
      {
         //
         // TODO: Add constructor logic here
         //
         this.dpiX = dpiX;
      }

      #region Constructors

      public float Convert(GraphicsUnit dstUnit, GraphicsUnit srcUnit, float value)
      {
         decimal dx = ConvertUnit(dstUnit, srcUnit, (decimal) value);
         return (float) Decimal.ToDouble(dx);
      }
      
      public PointF Convert(GraphicsUnit dstUnit, GraphicsUnit srcUnit, PointF value)
      {
         decimal dx = ConvertUnit(dstUnit, srcUnit, (decimal) value.X);
         decimal dy = ConvertUnit(dstUnit, srcUnit, (decimal) value.Y);
         return new PointF((float) Decimal.ToDouble(dx), (float) Decimal.ToDouble(dy));
      }

      public SizeF Convert(GraphicsUnit dstUnit, GraphicsUnit srcUnit, SizeF value)
      {
         decimal dw = ConvertUnit(dstUnit, srcUnit, (decimal) value.Width);
         decimal dh = ConvertUnit(dstUnit, srcUnit, (decimal) value.Height);
         return new SizeF((float) Decimal.ToDouble(dw), (float) Decimal.ToDouble(dh));  
      }

      public RectangleF Convert(GraphicsUnit dstUnit, GraphicsUnit srcUnit, RectangleF value)
      {
         PointF location = Convert(dstUnit, srcUnit, value.Location);
         SizeF size = Convert(dstUnit, srcUnit, value.Size);
         return new RectangleF(location, size);
      }

      #endregion

      private Decimal ConvertUnit(GraphicsUnit dstUnit, GraphicsUnit srcUnit, Decimal value)
      {
         Decimal pixels = ToPixel(value, srcUnit);
         return FromPixel(pixels, dstUnit);
      }

      private Decimal ToPixel(Decimal value, GraphicsUnit unit)
      {
         Decimal ret = 0;

         switch(unit)
         {
            case GraphicsUnit.Millimeter:
            {
               ret = Decimal.Multiply(value, Decimal.Divide(dpiX, 25.4m));                     
               break;
            }
            case GraphicsUnit.Point:
            {
               ret = Decimal.Multiply(value, Decimal.Divide(dpiX, 72m));
               break;
            }
            case GraphicsUnit.Inch:
            {
               ret = Decimal.Multiply(value, dpiX);                     
               break;
            }
            default:
            {
               ret = value;
               break;
            }
         }

         return ret;
      }

      private Decimal FromPixel(Decimal value, GraphicsUnit unit)
      {
         Decimal ret = 0;

         switch(unit)
         {
            case GraphicsUnit.Millimeter:
            {
               ret = Decimal.Divide(value, Decimal.Divide(dpiX, 25.4m));
               break;
            }
            case GraphicsUnit.Point:
            {
               ret = Decimal.Divide(value, Decimal.Divide(dpiX, 72m));
               break;
            }
            case GraphicsUnit.Inch:
            {
               ret = Decimal.Divide(value, dpiX);                     
               break;
            }
            default:
            {
               ret = value;
               break;
            }
         }

         return Decimal.Round(ret, 3);
      }
   }

   public class ResolutionConvert
   {
      public static float Convert(float value, float dstResolution, float srcResolution)
      {
         decimal temp = (decimal) value;
         return (float) decimal.ToDouble( decimal.Multiply(decimal.Divide(temp, (decimal) srcResolution), (decimal) dstResolution) );
      }

      public static PointF Convert(PointF value, float dstResolution, float srcResolution)
      {
         return new PointF(
            Convert(value.X, dstResolution, srcResolution),
            Convert(value.Y, dstResolution, srcResolution));
      }
      
      public static SizeF Convert(SizeF value, float dstResolution, float srcResolution)
      {
         return new SizeF(
            Convert(value.Width, dstResolution, srcResolution),
            Convert(value.Height, dstResolution, srcResolution));
      }

      public static RectangleF Convert(RectangleF value, float dstResolution, float srcResolution)
      {
         return new RectangleF(
            Convert(value.Location, dstResolution, srcResolution),
            Convert(value.Size, dstResolution, srcResolution));
      } 
   }
}
