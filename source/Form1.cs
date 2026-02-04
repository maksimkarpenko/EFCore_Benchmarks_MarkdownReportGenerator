using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarkdownReportGenerator {
    public partial class Form1 : Form {

        List<BenchmarkResult> bencmarkResults = null;

        private DevExpress.XtraCharts.ChartControl chartPrototype;

        public Form1() {
            InitializeComponent();
            InitializeChartPrototype();
        }

        private void InitializeChartPrototype() {
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint(1D, new object[] {
            ((object)(25D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint(1000D, new object[] {
            ((object)(35D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint(2500D, new object[] {
            ((object)(45D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint(5000D, new object[] {
            ((object)(55D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint(1D, new object[] {
            ((object)(20D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint(1000D, new object[] {
            ((object)(30D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint(2500D, new object[] {
            ((object)(40D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint(5000D, new object[] {
            ((object)(50D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint9 = new DevExpress.XtraCharts.SeriesPoint(1D, new object[] {
            ((object)(15D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint10 = new DevExpress.XtraCharts.SeriesPoint(1000D, new object[] {
            ((object)(25D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint11 = new DevExpress.XtraCharts.SeriesPoint(2500D, new object[] {
            ((object)(35D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint12 = new DevExpress.XtraCharts.SeriesPoint(5000D, new object[] {
            ((object)(45D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint13 = new DevExpress.XtraCharts.SeriesPoint(1D, new object[] {
            ((object)(10D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint14 = new DevExpress.XtraCharts.SeriesPoint(1000D, new object[] {
            ((object)(20D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint15 = new DevExpress.XtraCharts.SeriesPoint(2500D, new object[] {
            ((object)(30D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint16 = new DevExpress.XtraCharts.SeriesPoint(5000D, new object[] {
            ((object)(40D))});
            DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
            this.chartPrototype = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrototype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).BeginInit();
            // 
            // chartPrototype
            // 
            xyDiagram1.AxisX.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            xyDiagram1.AxisX.GridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            xyDiagram1.AxisX.GridLines.MinorColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Label.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 20F);
            xyDiagram1.AxisX.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.NumericScaleOptions.GridAlignment = DevExpress.XtraCharts.NumericGridAlignment.Thousands;
            xyDiagram1.AxisX.NumericScaleOptions.MeasureUnit = DevExpress.XtraCharts.NumericMeasureUnit.Thousands;
            xyDiagram1.AxisX.NumericScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Manual;
            xyDiagram1.AxisX.Thickness = 3;
            xyDiagram1.AxisX.Title.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 28F);
            xyDiagram1.AxisX.Title.Text = "Item Count";
            xyDiagram1.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
            xyDiagram1.AxisX.VisualRange.EndSideMargin = 0.33333333333333331D;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "5000";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisX.VisualRange.StartSideMargin = 0.33333333333333331D;
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "5000";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "0";
            xyDiagram1.AxisY.Color = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            xyDiagram1.AxisY.GridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            xyDiagram1.AxisY.GridLines.MinorColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Label.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 20F);
            xyDiagram1.AxisY.Label.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            xyDiagram1.AxisY.Thickness = 3;
            xyDiagram1.AxisY.Title.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 28F);
            xyDiagram1.AxisY.Title.Text = "Time, milliseconds";
            xyDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartPrototype.Diagram = xyDiagram1;
            this.chartPrototype.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartPrototype.Legend.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 22F);
            this.chartPrototype.Legend.MarkerOffset = 0;
            this.chartPrototype.Legend.MarkerSize = new System.Drawing.Size(20, 20);
            this.chartPrototype.Legend.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.chartPrototype.Legend.Title.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 24F);
            this.chartPrototype.Legend.VerticalIndent = 15;
            this.chartPrototype.Location = new System.Drawing.Point(38, 21);
            this.chartPrototype.Name = "chartPrototype";
            pointSeriesLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            pointSeriesLabel1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            pointSeriesLabel1.Border.Thickness = 10;
            pointSeriesLabel1.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 24F);
            pointSeriesLabel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "EF Core 10 (No Security)";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4});
            lineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            lineSeriesView1.LineMarkerOptions.Size = 22;
            lineSeriesView1.LineStyle.Thickness = 4;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = lineSeriesView1;
            pointSeriesLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            pointSeriesLabel2.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            pointSeriesLabel2.Border.Thickness = 10;
            pointSeriesLabel2.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 24F);
            pointSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel2.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series2.Label = pointSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "EF Core 10 (Security)";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint5,
            seriesPoint6,
            seriesPoint7,
            seriesPoint8});
            lineSeriesView2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            lineSeriesView2.LineMarkerOptions.Size = 22;
            lineSeriesView2.LineStyle.Thickness = 4;
            lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = lineSeriesView2;
            pointSeriesLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            pointSeriesLabel3.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            pointSeriesLabel3.Border.Thickness = 10;
            pointSeriesLabel3.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 24F);
            pointSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel3.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series3.Label = pointSeriesLabel3;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "XPO (No Security)";
            series3.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint9,
            seriesPoint10,
            seriesPoint11,
            seriesPoint12});
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            lineSeriesView3.LineMarkerOptions.Size = 22;
            lineSeriesView3.LineStyle.Thickness = 4;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.View = lineSeriesView3;
            pointSeriesLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            pointSeriesLabel4.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            pointSeriesLabel4.Border.Thickness = 10;
            pointSeriesLabel4.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 24F);
            pointSeriesLabel4.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel4.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series4.Label = pointSeriesLabel4;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "XPO (Security)";
            series4.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint13,
            seriesPoint14,
            seriesPoint15,
            seriesPoint16});
            lineSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            lineSeriesView4.LineMarkerOptions.Size = 22;
            lineSeriesView4.LineStyle.Thickness = 4;
            lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.View = lineSeriesView4;
            this.chartPrototype.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
            this.chartPrototype.Size = new System.Drawing.Size(1434*12/10, 637*12/10);  // (1434, 637);
            this.chartPrototype.TabIndex = 0;
            this.chartPrototype.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl1_CustomDrawSeriesPoint);
            this.chartPrototype.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrototype)).EndInit();
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e) {
            e.LabelText = string.Empty;
        }

        void Execute(Action action) {
            Cursor.Current = Cursors.WaitCursor;
            try {
                action();
            }
            catch(Exception ex) {
                while (ex.InnerException != null) {
                    ex = ex.InnerException;
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Execute(() => {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    Cursor.Current = Cursors.WaitCursor;
                    btnExport.Enabled = false;
                    BenchmarkReportReader rdr = new BenchmarkReportReader(openFileDialog1.FileNames);
                    bencmarkResults = rdr.ReadReport();
                    RefreshReport();
                    btnExport.Enabled = true;
                }
            });
        }

        private void btnExport_Click(object sender, EventArgs e) {
            Execute(() => {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    Cursor.Current = Cursors.WaitCursor;
                    string fileName = saveFileDialog1.FileName;
                    string ext = Path.GetExtension(fileName).ToLower();
                    if (ext == ".html") {
                        ChartGenerator chartGenerator = new ChartGenerator(chartPrototype, ImageFormat);
                        ReportExporterHTML reportExporter = new ReportExporterHTML(bencmarkResults, chartGenerator, ImageFormat);
                        reportExporter.Export(fileName);
                    } else if (ext == ".md") {
                        ChartGenerator chartGenerator = new ChartGenerator(chartPrototype, ImageFormat);
                        ReportExporterMarkdown reportExporter = new ReportExporterMarkdown(bencmarkResults, chartGenerator, ImageFormat);
                        reportExporter.Export(fileName);
                    }
                }
            });
        }

        private void RefreshReport() {
            string tmpPath = Path.Combine(Path.GetTempPath(), "ormBenchmarkReportPreview.html");
            ChartGenerator chartGenerator = new ChartGenerator(chartPrototype, ImageFormat);
            ReportExporterHTML reportExporter = new ReportExporterHTML(bencmarkResults, chartGenerator, ImageFormat);
            reportExporter.Export(tmpPath);
            webBrowser1.Navigate("file://" + tmpPath);
        }

        private void cbImageFormatSvg_CheckedChanged(object sender, EventArgs e) {
            RefreshReport();
        }

        string ImageFormat {
            get {
                return cbImageFormatSvg.Checked ? "svg" : "png";
            }
        }
    }
}
