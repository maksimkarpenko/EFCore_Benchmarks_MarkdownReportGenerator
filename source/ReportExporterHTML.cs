using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownReportGenerator {
    class ReportExporterHTML : ReportExporterBase {
        protected override string ExportFormat => "HTML";
        public ReportExporterHTML(List<BenchmarkResult> benchmarkResults, ChartGenerator chartGenerator, string imageFormat) 
            : base(benchmarkResults, chartGenerator, imageFormat) { }

        protected override void WriteTable(TextWriter wr, string[,] table) {
            int rows = table.GetLength(0);
            int cols = table.GetLength(1);
            wr.WriteLine("<table border='1' width='100%'>");
            wr.WriteLine("<thead>");
            wr.WriteLine("<tr>");
            for(int j = 0; j < cols; j++) {
                wr.Write("<th>");
                wr.Write(table[0, j]);
                wr.Write("</th>");
            }
            wr.WriteLine("</tr>");
            wr.WriteLine("</thead>");
            for (int i = 1; i < rows; i++) {
                wr.WriteLine("<tr>");
                for (int j = 0; j < cols; j++) {
                    wr.Write("<td>");
                    wr.Write(table[i, j]);
                    wr.Write("</td>");
                }
                wr.WriteLine("</tr>");
            }
            wr.WriteLine("</table>");
        }
    }
}
