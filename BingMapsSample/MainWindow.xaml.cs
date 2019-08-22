// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace BingMapsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            plot.Tag = bingmap;

            List<double> lat = new List<double>(), lon = new List<double>(), data = new List<double>();
            using (var reader = new StreamReader(@"data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    double x = Double.Parse(values[3]);
                    x = Math.Floor(x) + (x - Math.Floor(x)) / 0.60;
                    double y = Double.Parse(values[2]);
                    y = Math.Floor(y) + (y - Math.Floor(y)) / 0.60;

                    lon.Add(x);
                    lat.Add(y);
                    //data.Add(Double.Parse(values[2], CultureInfo.InvariantCulture));
                    double z = Double.Parse(values[4]);
                    z = 10 * Math.Sqrt(z);
                    //z = 10 * Math.Sqrt(z);
                    data.Add(z*10);
                }
            }

            markers.PlotColorSize(lon.ToArray(), lat.ToArray(), data.ToArray(), data.ToArray());
        }
    }
}
