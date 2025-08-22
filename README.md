# WPF GridControl input message

This repository contains the samples that demonstrates various options in input message feature of [WPF GridControl](https://help.syncfusion.com/wpf/gridcontrol/overview).

### Input Message Tip for row and column

The input message tip can be displayed for any row or column by setting the [ShowDataValidationTooltip](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridStyleInfo_ShowDataValidationTooltip) and the message tip can be customized by setting [DataValidationTooltip](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridStyleInfo_DataValidationTooltip) property.

``` csharp
//Adding input message tip for specific row
grid.Model.RowStyles[1].DataValidationTooltip = "Hello";
grid.Model.RowStyles[1].ShowDataValidationTooltip = true;

//Adding input message tip for specific column
grid.Model.ColStyles[1].DataValidationTooltip = "Hello";
grid.Model.ColStyles[1].ShowDataValidationTooltip = true;
```

An another way to set the input message tip for specific row and column.

``` csharp
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
```

### Set Input Message Tip using QueryCellInfo event

You can set the input message tip for specific cell or row or column by using [QueryCellInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridModel.html#Syncfusion_Windows_Controls_Grid_GridModel_QueryCellInfo) event.

``` csharp
private void Grid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
{
    e.Style.ShowDataValidationTooltip = true;

    //Show message tip for specific cell
    if (e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 1)
        e.Style.DataValidationTooltip = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
    
    // Show message tip for row.
    if (e.Cell.ColumnIndex > 0 && e.Cell.RowIndex == 1)
        e.Style.DataValidationTooltip = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
        
    // Show message tip for column.
    if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex == 2)
        e.Style.DataValidationTooltip = e.Style.GridModel[e.Style.RowIndex, 0].CellValue + ": \nPopulation rate in " + e.Style.RowIndex + " is " + e.Style.CellValue.ToString();
}
```

### Customize the Input Message Tip

The input message tip can be customized by defining DataTemplate. The DataTemplate can be assigned to the [GridStyleInfo.DataValidationTooltipTemplateKey](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html#Syncfusion_Windows_Controls_Grid_GridStyleInfo_DataValidationTooltipTemplateKey) property. If you are using inputTextmessage1 then you need to assign template to its corresponding template key property namely `GridStyleInfo.DataValidationTooltipTemplateKey`.

[GridStyleInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.Windows.Controls.Grid.GridStyleInfo.html) which holds cell information is the `DataContext` for data template of input message tip.

#### XAML

``` xml
<Window.Resources>
    <DataTemplate x:Key="inputTextmessage1">
        <Border BorderBrush="Gray" BorderThickness="2.5" CornerRadius="5">
            <TextBlock Width="Auto" Height="Auto" HorizontalAlignment="Left" VerticalAlignment="Center" Background="LightBlue" FontSize="14" Foreground="Black" Text="{Binding DataValidationTooltip}" />
        </Border>
    </DataTemplate>
</Window.Resources>
```

#### C#

``` csharp
// Set template key to a particular index 
grid.Model[1, 2].DataValidationTooltipTemplateKey = "inputTextmessage1";

// Using QueryCellInfo event
private void Grid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
{
    if(e.Cell.RowIndex == 1 && e.Cell.ColumnIndex == 2)
    {
        e.Style.DataValidationTooltip = e.Style.GridModel[1, 0].CellValue + ": \nPopulation rate in " + e.Style.ColumnIndex + " is " + e.Style.CellValue.ToString();
        e.Style.ShowDataValidationTooltip = true;
        e.Style.DataValidationTooltipTemplateKey = "inputTextmessage1";
    }
}
```