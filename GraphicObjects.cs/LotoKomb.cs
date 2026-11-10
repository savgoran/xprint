using System;
using System.Collections;
using System.IO;
using System.Text;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for LotoKomb.
	/// </summary>
	public class LotoKomb
	{
      public string rez;
      public string ser;
      public string rbk;
      public string kb;
      public ArrayList combs = new ArrayList();

      public LotoKomb()
      {
         ser = "001";
         rbk = "1234567";
         kb = "12345";
         for(int i = 0; i < 4; i++)
            combs.Add(new byte[] {1, 2, 3, 4, 5, 6, 7});
      }
      
      public LotoKomb(char[] comb)
      {
         StringBuilder sb = new StringBuilder();
         sb.Append(comb);
         ser = sb.ToString(0, 3);
         rbk = sb.ToString(3, 7);
         kb = sb.ToString(10, 5);

         combs.Add(GetComb(sb.ToString(15, 14)));
         combs.Add(GetComb(sb.ToString(29, 14)));
         combs.Add(GetComb(sb.ToString(43, 14)));
         combs.Add(GetComb(sb.ToString(57, 14)));
      }

      public static LotoKomb GetLotoKomb(int index)
      {
         char[] comb = new char[129];
         FileStream fs = new FileStream(@"C:\Program Files\Common Files\LutrijaCG\Baze\L39001.txt", FileMode.Open, FileAccess.Read);

         fs.Seek((index - 1) * 129, SeekOrigin.Begin);

         BinaryReader br =  new BinaryReader(fs);

         comb = br.ReadChars(127);
         
         LotoKomb mb = new LotoKomb(comb);

         fs.Close();

         return mb;
      }

      public static LotoKomb EmptyKomb()
      {
         return new LotoKomb();
      }

      public static int Count()
      {
         FileInfo fi = new FileInfo(@"C:\Program Files\Common Files\LutrijaCG\Baze\L39001.txt");
         return Convert.ToInt32(fi.Length / 129);
      }

      public override string ToString()
      {
         string str = string.Format("{0}/{1} {2}\n", ser, rbk, kb);
         str = str + CombToString();
         return str;
      }

      private byte[] GetComb(string strcomb)
      {
         int num;
         byte[] onecomb = new byte[7];

         for(int i = 0; i < 7; i++)
         {
            num = Convert.ToInt32(strcomb.Substring(i*2, 2));
            onecomb[i] = (byte) num;
         }
         
         return onecomb;
      }

      private int GetNumCol(int num)
      {
         if(num == 90)
         {
            return 8;
         }
         else
         {
            return Convert.ToInt32(num / 10);
         }
      }

      private string CombToString()
      {
         string str = "";
         byte[] comb0 = (byte[]) combs[0];

         for(int i = 0; i < 7; i++)
         {
            int num = Convert.ToInt32(comb0[i]);
            str += string.Format("{0:00} ", num);
         }
         return str;
      }
	}
}
