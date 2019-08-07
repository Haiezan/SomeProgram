using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataModify
{
    class Program
    {
        static List<Data> m_Data = new List<Data>();
        static void Main(string[] args)
        {
            string sFileFrom = @"E:\20190807-3_connectorsystem.inp";
            string sFileTo = @"E:\20190807-3_connectorsystem0.inp";

            FileStream fs = new FileStream(sFileFrom, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = string.Empty;

            line = sr.ReadLine();
            while (line != null)
            {
                Data data = new Data();
                for (int i = 0; i < 14; i++) 
                {
                    data.str.Add(line);
                    line = sr.ReadLine();
                }
                if (IsSame(data)) Modify(data);
                m_Data.Add(data); 
            }
            sr.Close();
            fs.Close();


            FileStream fw = new FileStream(sFileTo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);
            for (int i = 0; i < m_Data.Count(); i++)
            {
                for (int j = 0; j < m_Data[i].str.Count(); j++)
                {
                    sw.Write(m_Data[i].str[j]+"\n");
                    sw.Write("\n");
                }
            }
            sw.Close();
            fw.Close();

        }
        static bool IsSame(Data data)
        {
            for (int i = 0; i < m_Data.Count(); i++)
            {
                if (data.str[0].Contains(m_Data[i].str[0])) return true;
            }
            return false;
        }
        static void Modify(Data data)
        {
            data.str[0] = data.str[0] + "-1";

            string[] pieces = data.str[9].Split(',');
            data.str[9] = pieces[0] + ", " + pieces[1] + "-1, " + pieces[2] + "-1";

            data.str[12] = data.str[12] + "-1";

            string[] pieces2 = data.str[13].Split(',');
            data.str[13] = (int.Parse(pieces2[1])+61000000).ToString() + ", " + pieces2[1] + ", " + pieces2[2];
        }
        
    }
    class Data
    {
        public List<string> str = new List<string>();
    }
}
