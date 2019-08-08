using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DataModify
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyConnectorsystem();
            ModifyConnector();
        }

        //修改connectorsystem
        static void ModifyConnectorsystem()
        {
            List<Data> m_Data = new List<Data>();

            string sFileFrom = @"E:\20190807-3_connectorsystem.inp";
            string sFileTo = @"E:\20190807-3_connectorsystem0.inp";

            FileStream fs = new FileStream(sFileFrom, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            FileStream fw = new FileStream(sFileTo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);

            string line = string.Empty;

            //IsolaterRuber前的直接复制
            while (!(line = sr.ReadLine()).Contains("IsolaterRuber"))
            {
                sw.Write(line);
                sw.Write("\r\n");
            }

            //IsolaterRuber开始进行判断修改
            while (line != null)
            {
                Data data = new Data();
                for (int i = 0; i < 14; i++)
                {
                    data.str.Add(line);
                    line = sr.ReadLine();
                }
                if (IsSame(data, m_Data)) Modify(data, m_Data);
                m_Data.Add(data);
            }
            sr.Close();
            fs.Close();

            for (int i = 0; i < m_Data.Count(); i++)
            {
                for (int j = 0; j < m_Data[i].str.Count(); j++)
                {
                    sw.Write(m_Data[i].str[j]);
                    sw.Write("\n");
                }
            }
            sw.Close();
            fw.Close();
        }

        //修改connector
        static void ModifyConnector()
        {
            List<Data> m_Data = new List<Data>();

            string sFileFrom = @"E:\20190807-3_connector.inp";
            string sFileTo = @"E:\20190807-3_connector0.inp";

            FileStream fs = new FileStream(sFileFrom, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            FileStream fw = new FileStream(sFileTo, FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);

            string line = string.Empty;

            //IsolaterRuber前的直接复制
            while (!(line = sr.ReadLine()).Contains("IsolaterRuber"))
            {
                sw.Write(line);
                sw.Write("\r\n");
            }

            //IsolaterRuber开始进行判断修改
            while (line != null)
            {
                Data data = new Data();
                for (int i = 0; i < 12; i++)
                {
                    data.str.Add(line);
                    line = sr.ReadLine();
                }
                if (IsSame(data, m_Data)) Modify2(data, m_Data);
                m_Data.Add(data);
            }
            sr.Close();
            fs.Close();

            for (int i = 0; i < m_Data.Count(); i++)
            {
                for (int j = 0; j < m_Data[i].str.Count(); j++)
                {
                    sw.Write(m_Data[i].str[j]);
                    sw.Write("\n");
                }
            }
            sw.Close();
            fw.Close();
        }
        //判断是否重复
        static bool IsSame(Data data, List<Data> m_Data)
        {
            for (int i = 0; i < m_Data.Count(); i++)
            {
                if (data.str[0].Contains(m_Data[i].str[0])) return true;
            }
            return false;
        }
        //修改数据
        static void Modify(Data data, List<Data> m_Data)
        {
            data.str[0] = data.str[0] + "-1";

            data.str[7] = data.str[7] + "-1";

            string[] pieces = data.str[9].Split(',');
            data.str[9] = pieces[0] + ", " + pieces[1] + "-1, " + pieces[2] + "-1";

            string[] pieces3 = data.str[11].Split(',');
            data.str[11] = pieces3[0] + "-1,";

            data.str[12] = data.str[12] + "-1";

            string[] pieces2 = data.str[13].Split(',');
            data.str[13] = (int.Parse(pieces2[1])+61000000).ToString() + ", " + pieces2[1] + ", " + pieces2[2];
        }
        static void Modify2(Data data, List<Data> m_Data)
        {
            data.str[0] = data.str[0] + "-1";

            string[] pieces = data.str[7].Split(',');
            data.str[7] = pieces[0] + ", " + pieces[1] + "-1, " + pieces[2] + "-1";

            string[] pieces3 = data.str[9].Split(',');
            data.str[9] = pieces3[0] + "-1,";

            data.str[10] = data.str[10] + "-1";

            string[] pieces2 = data.str[11].Split(',');
            data.str[11] = (int.Parse(pieces2[1]) + 61000000).ToString() + ", " + pieces2[1] + ", " + pieces2[2];
        }

    }
    class Data
    {
        public List<string> str = new List<string>();
    }
}
