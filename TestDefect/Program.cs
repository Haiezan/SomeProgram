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

            string sFileFrom = @"F:\00Test_Temp\AA.FEA.txt";
            string sFileTo = @"F:\00Test_Temp\AA.csv";

            FileStream fs = new FileStream(sFileFrom, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            FileStream fw = new FileStream(sFileTo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);

            string line = string.Empty;

            //读取坐标数据
            while (!(line = sr.ReadLine()).Contains("coord ="))
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
            for (int i = 0; i < m_Data.Count; i++)
            {
                sw.Write(m_Data[i] + ",");
                if(i%3==2) sw.Write("\r\n");
            }

            sr.Close();
            fs.Close();

            sw.Close();
            fw.Close();
        }
    }
}
