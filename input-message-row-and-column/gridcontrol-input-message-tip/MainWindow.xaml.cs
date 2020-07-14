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

namespace gridcontrol_input_message_tip
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
            grid.QueryCellInfo += Grid_QueryCellInfo;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;

            //Add input message tip for specific row
            for (int i = 1; i <= 4; i++)
            {
                string comment = grid.Model[1, 0].CellValue + " :\nPopulation rate in " + grid.Model[1, i].ColumnIndex + " is " + grid.Model[1, i].CellValue;
                grid.Model[1, i].DataValidationTooltip = comment;
                grid.Model[1, i].ShowDataValidationTooltip = true;
            }

            //Add input message tip for specific column
            for (int i = 1; i <= 4; i++)
            {
                string comment = grid.Model[i, 0].CellValue + " :\nPopulation rate in " + grid.Model[i, 2].RowIndex + " is " + grid.Model[i, 2].CellValue;
                grid.Model[i, 2].DataValidationTooltip = comment;
                grid.Model[i, 2].ShowDataValidationTooltip = true;
            }
            GridTooltipService.SetShowTooltips(grid, true);
        }

        private void Grid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
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
