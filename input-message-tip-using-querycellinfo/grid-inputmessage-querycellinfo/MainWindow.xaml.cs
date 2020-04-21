using Syncfusion.Windows.Controls.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace grid_inputmessage_querycellinfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dataTable;
        Random random;
        public MainWindow()
        {
            InitializeComponent();
            Width = 1000;
            Height = 600;
            this.LoadData();
            grid.Width = 700;
            grid.Height = 400;
            grid.Model.HeaderStyle.Borders.All = new System.Windows.Media.Pen(System.Windows.Media.Brushes.LightGray, 1);
            grid.Model.RowCount = dataTable.Rows.Count;
            grid.Model.ColumnCount = dataTable.Columns.Count;
            grid.Model.RowHeights.DefaultLineSize = 30;
            grid.Model.ColumnWidths.DefaultLineSize = 115;
            grid.Model.ColumnWidths[0] = 115;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            grid.QueryCellInfo += Grid_QueryCellInfo;
        }
        private void Grid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            e.Style.ShowDataValidationTooltip = true;

            GridCommentStyleInfo gridStyleInfo = new GridCommentStyleInfo();
            if (e.Style.RowIndex == 0 || e.Style.ColumnIndex == 0)
            {
                e.Style.CellType = "DataBoundTemplate";
                e.Style.CellItemTemplateKey = "TextBlockTemplate1";
            }
            if (e.Style.RowIndex == 0)
                e.Style.CellValue = dataTable.Columns[e.Style.ColumnIndex];
            else
                e.Style.CellValue = dataTable.Rows[e.Style.RowIndex][e.Style.ColumnIndex];
            

            //Show message tip for specific index
            if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 2)
            {
                e.Style.DataValidationTooltip = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
            }
            // Show message tip for row.
            if (e.Cell.ColumnIndex > 0 && e.Cell.RowIndex == 1)
                e.Style.DataValidationTooltip = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
            // Show message tip for column.
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex == 2)
                e.Style.DataValidationTooltip = e.Style.GridModel[e.Style.RowIndex, 0].CellValue + ": \nPopulation rate in " + e.Style.RowIndex + " is " + e.Style.CellValue.ToString();


        }
        public void LoadData()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Country"));
            dataTable.Columns.Add(new DataColumn("2005"));
            dataTable.Columns.Add(new DataColumn("2006"));
            dataTable.Columns.Add(new DataColumn("2007"));
            dataTable.Columns.Add(new DataColumn("2008"));
            random = new Random();

            var row = dataTable.NewRow();
            row["Country"] = "USA";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "India";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "China";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "Japan";
            LoadCellValues(row);
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["Country"] = "UK";
            LoadCellValues(row);
            dataTable.Rows.Add(row);
        }

        public void LoadCellValues(DataRow row)
        {
            for (int i = 1; i <= 4; i++)
            {
                row[i] = ((double)random.Next(2, 18)).ToString() + "%";
            }
        }
    }
}
