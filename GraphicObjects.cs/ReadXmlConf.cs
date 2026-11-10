using System;
using System.Drawing;
using System.Xml;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for ReadXmlConf.
	/// </summary>
	public class ReadXmlConf
	{
		private XmlDocument xmlDoc;
      
      public ReadXmlConf(string fileName)
		{
			//
			// TODO: Add constructor logic here
			//

         xmlDoc = new XmlDocument();
         xmlDoc.Load(fileName);
		}

      public RectangleF GetRectangleF(string xpath)
      {
         float x = float.Parse(xmlDoc.SelectSingleNode(xpath + "x").InnerText);
         float y = float.Parse(xmlDoc.SelectSingleNode(xpath + "y").InnerText);
         float width = float.Parse(xmlDoc.SelectSingleNode(xpath + "width").InnerText);
         float height = float.Parse(xmlDoc.SelectSingleNode(xpath + "height").InnerText);

         return new RectangleF(x, y, width, height);
      }

      public PointF GetPointF(string xpath)
      {
         float x = float.Parse(xmlDoc.SelectSingleNode(xpath + "x").InnerText);
         float y = float.Parse(xmlDoc.SelectSingleNode(xpath + "y").InnerText);

         return new PointF(x, y);
      }

      public SizeF GetSizeF(string xpath)
      {
         float width = float.Parse(xmlDoc.SelectSingleNode(xpath + "width").InnerText);
         float height = float.Parse(xmlDoc.SelectSingleNode(xpath + "height").InnerText);

         return new SizeF(width, height);
      }

      public Font GetFont(string xpath)
      {
         string name = GetString(xpath + "name");
         int fontSize = Convert.ToInt32(xmlDoc.SelectSingleNode(xpath + "size").InnerText);

         return new Font(name, fontSize);
      }

      public string GetString(string xpath)
      {
         return xmlDoc.SelectSingleNode(xpath).InnerText.Trim();
      }
	}
}
