using DevExpress.XtraSpreadsheet.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownReportGenerator {
    abstract class ReportExporterBase {
        protected List<BenchmarkResult> benchmarkResults;
        protected ChartGenerator chartGenerator;
        protected string fileName;

        public readonly string ImageFormat = "png";  // png | svg
        public readonly CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");

        public ReportExporterBase(List<BenchmarkResult> benchmarkResults, ChartGenerator chartGenerator, string imageFormat) {
            this.benchmarkResults = benchmarkResults;
            this.chartGenerator = chartGenerator;
            this.ImageFormat = imageFormat;
        }
        protected abstract string ExportFormat { get; }
        public void Export(string fileName) {
            this.fileName = fileName;
            var methods = benchmarkResults.Select(r => r.Method).Distinct().OrderBy(t => t);
            using (Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                using (TextWriter wr = new StreamWriter(fs, Encoding.UTF8)) {
                    WriteHeader(wr);
                    foreach(string method in methods) {
                        WriteChartsBlock(wr, method);
                        WriteResultsTable(wr, method);
                    }
                    WriteFooter(wr);
                }
            }
        }
        protected virtual void WriteHeader(TextWriter wr) {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", ExportFormat, "Header.txt");
            string text = File.ReadAllText(path, Encoding.UTF8);
            wr.Write(text);
        }
        protected virtual void WriteFooter(TextWriter wr) {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", ExportFormat, "Footer.txt");
            string text = File.ReadAllText(path, Encoding.UTF8);
            wr.Write(text);
        }
        protected virtual void WriteChartsBlock(TextWriter wr, string testMethod) {
            var providers = benchmarkResults.Select(r => r.Provider).Distinct().OrderBy(t => t).ToList();
            var rowCounts = benchmarkResults.Select(r => r.RowCount).Distinct().OrderBy(t => t).ToList();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", ExportFormat, "ChartsBlock.txt");
            string text = File.ReadAllText(path, Encoding.UTF8);
            
            chartGenerator.Clear();
            for (int i = 0; i < providers.Count; i++) {
                var points = benchmarkResults.Where(t => t.Provider == providers[i] && t.Method == testMethod && t.RowCount <= 500)
                    .OrderBy(t => t.RowCount)
                    .Select(t => new KeyValuePair<double, double>(t.RowCount, (double)t.TimeMilliseconds))
                    .ToList();
                chartGenerator.AddSeries(providers[i], points);
            }
            string smallDsChartFile = Path.Combine(Path.GetDirectoryName(fileName), "images", string.Format("{0}_smallDataSet.{1}", testMethod, ImageFormat));
            chartGenerator.SaveToFile(smallDsChartFile);

            chartGenerator.Clear();
            for (int i = 0; i < providers.Count; i++) {
                var points = benchmarkResults.Where(t => t.Provider == providers[i] && t.Method == testMethod && t.RowCount > 500)
                    .OrderBy(t => t.RowCount)
                    .Select(t => new KeyValuePair<double, double>(t.RowCount, (double)t.TimeMilliseconds))
                    .ToList();
                chartGenerator.AddSeries(providers[i], points);
            }
            string largeDsChartFile = Path.Combine(Path.GetDirectoryName(fileName), "images", string.Format("{0}_largeDataSet.{1}", testMethod, ImageFormat));
            chartGenerator.SaveToFile(largeDsChartFile);

            text = text.Replace("{METHOD}", testMethod);
            text = text.Replace("{IMAGE-FORMAT}", ImageFormat);
            wr.Write(text);
        }
        protected virtual void WriteResultsTable(TextWriter wr, string testMethod) {
            var results = benchmarkResults.Where(r => r.Method == testMethod);
            var providers = results.Select(r => r.Provider).Distinct().OrderBy(t => t).ToList();
            var rowCounts = results.Select(r => r.RowCount).Distinct().OrderBy(t => t).ToList();
            string[,] table = new string[rowCounts.Count + 1, providers.Count + 1];
            table[0, 0] = "Item Count";
            for (int i = 0; i < providers.Count; i++) {
                table[0, i + 1] = string.Format("{0}, ms", providers[i]);
            }
            for (int i = 0; i < rowCounts.Count; i++) {
                table[i + 1, 0] = rowCounts[i].ToString(Culture);
                for (int j = 0; j < providers.Count; j++) {
                    decimal time = results.First(t => t.Provider == providers[j] && t.RowCount == rowCounts[i]).TimeMilliseconds;
                    table[i + 1, j + 1] = time.ToString(Culture);
                }
            }
            WriteTable(wr, table);
        }
        protected abstract void WriteTable(TextWriter wr, string[,] table);
    }
}
