using System;
using System.Collections;
using System.IO;
using System.Text;

namespace GraphicObjects
{
	/// <summary>
	/// Summary description for MontoKomb.
	/// </summary>
	public class MontoKomb
	{
      public string rez;
      public string ser;
      public string rbk;
      public string kb;
      public ArrayList combs = new ArrayList();

      public MontoKomb(char[] comb)
      {
         StringBuilder sb = new StringBuilder();
         sb.Append(comb);
         rez = sb.ToString(0, 5);
         ser = sb.ToString(5, 3);
         rbk = sb.ToString(8, 7);
         kb = sb.ToString(15, 5);

         combs.Add(GetComb(sb.ToString(20, 30)));
         combs.Add(GetComb(sb.ToString(50, 30)));
         combs.Add(GetComb(sb.ToString(80, 30)));
         combs.Add(GetComb(sb.ToString(110, 30)));
         combs.Add(GetComb(sb.ToString(140, 30)));
         combs.Add(GetComb(sb.ToString(170, 30)));
      }

      public static MontoKomb GetMontoKomb(int index)
      {
         char[] comb = new char[200];
         FileStream fs = new FileStream(@"C:\Program Files\Common Files\LutrijaCG\Baze\002.txt", FileMode.Open, FileAccess.Read);
         fs.Seek((index - 1) * 202, SeekOrigin.Begin);

         BinaryReader br =  new BinaryReader(fs);

         comb = br.ReadChars(200);
         
         MontoKomb mb = new MontoKomb(comb);

         fs.Close();

         return mb;
      }

      public static int Count()
      {
         FileInfo fi = new FileInfo(@"C:\Program Files\Common Files\LutrijaCG\Baze\002.txt");
         return Convert.ToInt32(fi.Length / 202);
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
         byte[] onecomb = new byte[27];
         
         for(int i = 0; i < 27; i++)
         {
            onecomb[i] = 126;
         }

         for(int j = 0; j < 3; j++)
         {
            for(int i = 0; i < 5; i++)
            {
               num = Convert.ToInt32(strcomb.Substring((j*10) + i*2, 2));
               onecomb[j + (GetNumCol(num) * 3)] = (byte) num;
            }
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
         int pos = 0;
         int start = 0;
         byte[] comb0 = (byte[]) combs[5];

         for(int row=0; row<3; row++)
         {
            for(int col=0; col<9; col++)
            {
               int num = Convert.ToInt32(comb0[pos]);
               if(num == 126)
               {
                  str += "-- ";
               }
               else
               {
                  str += string.Format("{0:00} ", num);
               }
               pos += 3;
            }
            str += "\n";
            start += 1;
            pos = start;
         }
         return str;
      }
	}
}
