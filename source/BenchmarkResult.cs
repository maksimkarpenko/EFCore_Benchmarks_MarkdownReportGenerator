using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkdownReportGenerator {
    class BenchmarkResult {
        public string Method;
        public string Provider;
        public int RowCount;
        public decimal TimeMilliseconds;
    }
}
