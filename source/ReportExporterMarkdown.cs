using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownReportGenerator {
    class ReportExporterMarkdown : ReportExporterBase {
        protected override string ExportFormat => "Markdown";
        public ReportExporterMarkdown(List<BenchmarkResult> benchmarkResults, ChartGenerator chartGenerator, string imageFormat) 
            : base(benchmarkResults, chartGenerator, imageFormat) { }

        protected override void WriteTable(TextWriter wr, string[,] table) {
            int rows = table.GetLength(0);
            int cols = table.GetLength(1);
            const int colWidth = 30;
            for(int j = 0; j < cols; j++) {
                wr.Write("|");
                wr.Write(table[0, j].PadRight(colWidth, ' '));
            }
            wr.WriteLine("|");
            for(int j = 0; j < cols; j++) {
                wr.Write("|");
                wr.Write("".PadLeft(colWidth, '-'));
            }
            wr.WriteLine("|");
            for(int i = 1; i < rows; i++) {
                for(int j = 0; j < cols; j++) {
                    wr.Write("|");
                    wr.Write(table[i, j].PadRight(colWidth, ' '));
                }
                wr.WriteLine("|");
            }
            wr.WriteLine("");
        }
    }
}
