﻿#region #usings
using System;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...
#endregion #usings

namespace CandleStickChart {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

#region #code
private void Form1_Load(object sender, EventArgs e) {
    // Create a new chart.
    ChartControl candlestickChart = new ChartControl();

    // Create a candlestick series.
    Series series1 = new Series("Stock Prices", ViewType.CandleStick);

    // Specify the date-time argument scale type for the series,
    // as it is qualitative, by default.
    series1.ArgumentScaleType = ScaleType.DateTime;

    // Add points to it.
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 1),
        new object[] { 24.00, 25.00, 25.00, 24.875 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 2),
        new object[] { 23.625, 25.125, 24.00, 24.875 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 3),
        new object[] { 26.25, 28.25, 26.75, 27.00 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 6),
        new object[] { 26.50, 27.875, 26.875, 27.25 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 7),
        new object[] { 26.375, 27.50, 27.375, 26.75 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 8),
        new object[] { 25.75, 26.875, 26.75, 26.00 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 9),
        new object[] { 25.75, 26.75, 26.125, 26.25 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 10),
        new object[] { 25.75, 26.375, 26.375, 25.875 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 13),
        new object[] { 24.875, 26.125, 26.00, 25.375 }));
    series1.Points.Add(new SeriesPoint(new DateTime(2017, 3, 14),
        new object[] { 25.125, 26.00, 25.625, 25.75 }));

    // Add the series to the chart.
    candlestickChart.Series.Add(series1);

    // Access the view-type-specific options of the series.
    CandleStickSeriesView myView = (CandleStickSeriesView)series1.View;

    myView.LineThickness = 2;
    myView.LevelLineLength = 0.25;

    // Specify the series reduction options.
    myView.ReductionOptions.ColorMode = ReductionColorMode.OpenToCloseValue;
    myView.ReductionOptions.FillMode = CandleStickFillMode.FilledOnReduction;
    myView.ReductionOptions.Level = StockLevel.Open;
    myView.ReductionOptions.Visible = true;

    // Access the chart's diagram.
    XYDiagram diagram = ((XYDiagram)candlestickChart.Diagram);

    // Access the type-specific options of the diagram.
    diagram.AxisY.WholeRange.MinValue = 22;

    // Exclude weekends from the X-axis range,
    // to avoid gaps in the chart's data.
    diagram.AxisX.DateTimeScaleOptions.WorkdaysOnly = true;

    // Hide the legend (if necessary).
    candlestickChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

    // Add a title to the chart (if necessary).
    candlestickChart.Titles.Add(new ChartTitle());
    candlestickChart.Titles[0].Text = "Candlestick Chart";

    // Add the chart to the form.
    candlestickChart.Dock = DockStyle.Fill;
    this.Controls.Add(candlestickChart);
}
#endregion #code

    }
}
