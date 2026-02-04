using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Csv;

namespace MarkdownReportGenerator {
    class BenchmarkReportReader {
        readonly string[] fileNames;
        public BenchmarkReportReader(string[] fileNames) {
            this.fileNames = fileNames;
        }

        public List<BenchmarkResult> ReadReport() {
            List<BenchmarkResult> results = new List<BenchmarkResult>();
            foreach(string fileName in fileNames) {
                string ext = Path.GetExtension(fileName).ToLower();
                if(ext == ".json") {
                    results.AddRange(ParseJsonReport(fileName));
                } else {
                    throw new InvalidOperationException(string.Format("File format {0} is not supported.", ext));
                }
            }
            return results;
        }

        decimal ParseMilliseconds(string text) {
            string val = text.Replace(",", "");
            if(val.StartsWith("\"")) {
                val = val.Substring(1);
            }
            if(val.EndsWith("\"")) {
                val = val.Substring(0, val.Length - 1);
            }
            if(val == "NA") {
                return 0;
            }
            if(val.EndsWith(" ms")) {
                val = val.Substring(0, val.Length - 3);
                return Convert.ToDecimal(val, CultureInfo.InvariantCulture);
            } else if(val.EndsWith(" us") || val.EndsWith(" μs")) {
                val = val.Substring(0, val.Length - 3);
                return Convert.ToDecimal(val, CultureInfo.InvariantCulture) / 1000.0m;
            } else if(val.EndsWith(" s")) {
                val = val.Substring(0, val.Length - 2);
                return Convert.ToDecimal(val, CultureInfo.InvariantCulture) * 1000;
            } else throw new InvalidOperationException("Invalid time value: " + text);
        }

        List<BenchmarkResult> ParseJsonReport(string fileName) {
            List<BenchmarkResult> results = new List<BenchmarkResult>();
            JsonReport report = JsonConvert.DeserializeObject<JsonReport>(File.ReadAllText(fileName));
            foreach(var benchmark in report.Benchmarks) {
                Dictionary<string,string> parameters = benchmark.GetParameters();
                if (parameters["TestProvider"] == "EF Co(...)rity) [21]") {
                    parameters["TestProvider"] = "EF Core 10 (Security)";
                }
                if (parameters["TestProvider"] == "EF Co(...)rity) [24]") {
                    parameters["TestProvider"] = "EF Core 10 (No Security)";
                }
                BenchmarkResult res = new BenchmarkResult() {
                    Method = benchmark.Method,
                    RowCount = Convert.ToInt32(parameters["ItemsForTestIteration"]),
                    Provider = parameters["TestProvider"],
                    TimeMilliseconds = benchmark.Statistics != null ? Math.Round(Convert.ToDecimal(benchmark.Statistics.Mean / 1000000.0), 3) : 0
                };
                results.Add(res);
            }
            return results;
        }
    }


    class JsonReport {
        public string Title { get; set; }
        public HostEnvironmentInfoRecord HostEnvironmentInfo { get; set; }
        public BenchmarkRecord[] Benchmarks { get; set; }
        public class HostEnvironmentInfoRecord {
        }
        public class BenchmarkRecord {
            public string Method { get; set; }
            public string Parameters { get; set; }
            public StatisticsRecord Statistics { get; set; }
            public class StatisticsRecord {
                public double Mean { get; set; }
            }
            public Dictionary<string, string> GetParameters() {
                var parameters = new Dictionary<string, string>();
                if(!string.IsNullOrWhiteSpace(Parameters)) {
                    foreach(string paramExpr in Parameters.Split('&')) {
                        string[] paramPair = paramExpr.Split('=');
                        parameters.Add(paramPair[0], paramPair[1]);
                    }
                }
                return parameters;
            }
        }
    }
}
