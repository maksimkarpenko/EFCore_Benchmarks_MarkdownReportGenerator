using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace MarkdownReportGenerator {
    class ChartGenerator {
        DevExpress.XtraCharts.ChartControl chartPrototype;
        List<string> seriesNames;
        List<List<KeyValuePair<double, double>>> seriesPoints;
        readonly string imageFormat; // svg | png

        public ChartGenerator(DevExpress.XtraCharts.ChartControl chartPrototype, string imageFormat) {
            this.chartPrototype = chartPrototype;
            seriesNames = new List<string>();
            seriesPoints = new List<List<KeyValuePair<double, double>>>();
            this.imageFormat = imageFormat;
        }

        public void AddSeries(string seriesName, List<KeyValuePair<double, double>> points) {
            seriesNames.Add(seriesName);
            seriesPoints.Add(points);
        }

        public void Clear() {
            seriesNames.Clear();
            seriesPoints.Clear();
        }

        private void PrepareChart() {
            var axisX = (chartPrototype.Diagram as XYDiagram).AxisX;
            double maxValue = 0;
            foreach (string name in seriesNames) {
                int index = seriesNames.IndexOf(name);
                var points = seriesPoints[index];
                var series = chartPrototype.Series[name];
                series.Points.Clear();
                foreach (var pt in points) {
                    series.Points.Add(new DevExpress.XtraCharts.SeriesPoint(pt.Key, pt.Value));
                    maxValue = Math.Max(pt.Key, maxValue);
                }
            }

            axisX.WholeRange.Auto = false;
            axisX.VisualRange.Auto = false;
            axisX.NumericScaleOptions.AutoGrid = false;
            axisX.WholeRange.SideMarginsValue = axisX.VisualRange.SideMarginsValue = 0;
            if (maxValue <= 500) {
                axisX.NumericScaleOptions.ScaleMode = ScaleMode.Manual;
                axisX.NumericScaleOptions.GridSpacing = 100;
                axisX.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Ones;
                axisX.WholeRange.MinValue = axisX.VisualRange.MinValue = 0;
                axisX.WholeRange.MaxValue = axisX.VisualRange.MaxValue = 520;
            } else {
                axisX.NumericScaleOptions.ScaleMode = ScaleMode.Manual;
                axisX.NumericScaleOptions.GridSpacing = 1;
                axisX.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Thousands;
                axisX.WholeRange.MinValue = axisX.VisualRange.MinValue = 800;
                axisX.WholeRange.MaxValue = axisX.VisualRange.MaxValue = 5200;
            }
        }

        public void SaveToFile(string fileName) {
            if (!Directory.Exists(Path.GetDirectoryName(fileName))) {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }
            PrepareChart();
            if (imageFormat == "svg") {
                chartPrototype.ExportToSvg(fileName);
            } else {
                chartPrototype.ExportToImage(fileName, ImageFormat.Png);
            }
        }
    }
}
