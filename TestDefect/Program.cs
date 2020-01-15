using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestDefect
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> m_Data = new List<double>();

            string sFileFrom = @"F:\00Test_Temp\KJ\ssg2020\aa.FEA";
            string sFileTo = @"F:\00Test_Temp\AA.csv";

            FileStream fs = new FileStream(sFileFrom, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            FileStream fw = new FileStream(sFileTo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);

            string line = string.Empty;
            line = sr.ReadLine();
            //读取坐标数据
            while (!line.Contains("coord"))
            {
                if ((line = sr.ReadLine()) == null) break;
            }
            while (!(line = sr.ReadLine()).Equals(""))
            {
                string[] pieces = line.Split(' ');
                for (int i = 1; i < pieces.Length; i++)
                {
                    m_Data.Add(double.Parse(pieces[i]));
                }
            }

            //输出坐标
            int Num = m_Data.Count / 3;
            for (int i = 0; i < Num; i++)
            {
                sw.Write(i + 1 + ",");
                sw.Write(m_Data[i] + ",");
                sw.Write(m_Data[i + Num] + ",");
                sw.Write(m_Data[i + 2 * Num] + ",");
                sw.Write("\r\n");
            }

            sr.Close();
            fs.Close();

            sw.Close();
            fw.Close();
        }
    }
}
