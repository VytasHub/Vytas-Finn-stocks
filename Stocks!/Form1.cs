using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace Stocks_
{
    public partial class Form1 : Form
    {
        List<Stocks> stocksList = new List<Stocks>();
        Random rnd = new Random();
        string colour = "red";
        PointPairList list1 = new PointPairList();
        PointPairList list2 = new PointPairList();
        double x = 0;

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();

          //  zedGraph.
;           CreateGraph(zedGraph);
            GraphPane myPane = zedGraph.GraphPane;
            zedGraph.GraphPane.YAxis.Scale.Max = 10;
            //MessageBox.Show( zedGraph.GraphPane.ToString());
            
         
           
        }


        void timer_Tick(object sender, EventArgs e)
        {
           
            double rand = rnd.Next(3);
            x = x + 0.2;

          //  MessageBox.Show("raww");

            //foreach (Stocks stock in stocksList)
            //{
            //    lineChart.Series[stock.stockName].Points.AddY(rand);

            //    if (lineChart.Series[stock.StockName].Points.Count > 20)
            //    {
            //        lineChart.Series[stock.StockName].Points.RemoveAt(0);
            //    }
            //}
            list1.Add(x, rand);
            //LineItem myCurve = zedGraph.GraphPane.AddCurve("Porsche",
            //list1, Color.Red, SymbolType.Diamond);
            zedGraph.GraphPane.XAxis.Scale.Max = x;
            if (x > 10)
            {
                zedGraph.GraphPane.XAxis.Scale.Min = x - 10;
            }
            zedGraph.Invalidate();
            
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            int num;
            if (stkNameTxt.Text != "" && int.TryParse(StkVauleTxt.Text, out num))
            {
                Stocks stock = new Stocks();

                stock.stockName = stkNameTxt.Text;

                stock.stockValue = num;

                stocksList.Add(stock);

                addNewSeries(stock);
            }
        }


        private void addNewSeries(Stocks stock)
        {
            lineChart.Series.Add(stock.stockName);
            lineChart.Series[stock.stockName].ChartType = SeriesChartType.Spline;

            lineChart.Legends.Add(stock.stockName);
            lineChart.Series[stock.stockName].Color = ColorTranslator.FromHtml(colour);
        }

        private void comboComboBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            colour = comboComboBx.SelectedItem.ToString();
        }

        private void zedGraph_Load(object sender, EventArgs e)
        {
            //GraphPane Pane = zedGraph.GraphPane;
           
            //double x, y, z;
            //PointPairList list1 = new PointPairList();
            //for(int i = 0; i<100; i++)
            //{
            //    list1.Add(i,i/2);
            //}
            //LineItem myLine = Pane.AddCurve("blargh", list1, Color.Azure, SymbolType.Diamond);
            //zedGraph.AxisChange();
        }
        private void CreateGraph(ZedGraphControl zgc)
        {

           
 
            LineItem myCurve = zedGraph.GraphPane.AddCurve("Porsche",
                 list1, Color.Red, SymbolType.Diamond);

            zedGraph.AxisChange();
            
        }


 
      
      
    }
}
