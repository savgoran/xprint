using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TicketPrint
{
	/// <summary>
	/// Summary description for TicketInfo.
	/// </summary>
   [Serializable]
   public class TicketInfo
   {
      private int serija;
      private int rbk;
      private int konbr;
      private ArrayList kombs = new ArrayList();

      public TicketInfo()
      {
         //
         // TODO: Add constructor logic here
         //
      }

      public byte[] GetKomb(int index)
      {
         return (byte[]) kombs[index];
      }
      
      public void SetData(int id)
      {
         int from = 0;
         int to = 0;
         
         this.serija = 1;
         this.rbk = id;
         this.konbr = 0;

         from = ((id - 1) * 6) + 1;
         to = from + 5;

         SqlConnection sqlConnection = new SqlConnection("workstation id=PRONTO;packet size=4096;integrated security=SSPI;data source='.';persist security info=False;initial catalog=NewTombola");
         SqlCommand sqlCommand = new SqlCommand("SELECT Sadrzaj FROM Kombinacije WHERE [Id] >= @od and [Id] <= @do", sqlConnection);

         sqlCommand.CommandType = CommandType.Text;

         sqlCommand.Parameters.Add("@od", from);
         sqlCommand.Parameters.Add("@do", to);

         sqlConnection.Open();
         SqlDataReader dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

         kombs.Clear();
         while(dr.Read())
         {
            byte[] komb = new byte[27];
            dr.GetBytes(0, 0, komb, 0, 27);
            kombs.Add(komb);
         }

         sqlConnection.Close();

         konbr = CalcKonBr();
      }

      private int CalcKonBr()
      {
         int i = 0;
         int j = 0;
         int num = 0;
         int suma = 0;
         byte[] buff;
         int sign = -1;

         for(i = 0; i < (kombs.Count - 1); i++)
         {
            buff = (byte[]) kombs[i];
            for(j = 0; j <= 26; j++)
            {
               num = buff[j];
               if(num == 126)
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
         get {return this.serija;}
         set {this.serija = value;}
      }

      public int Rbk
      {
         get {return this.rbk;}
         set {this.rbk = value;}
      }

      public int KonBr
      {
         get {return this.konbr;}
         set {this.konbr = value;}
      }

      #endregion
	}
}
