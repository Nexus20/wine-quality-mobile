using System.Globalization;
using ChartJs.Blazor;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.LineChart;
using Microsoft.AspNetCore.Components;
using wine_quality_mobile.Enums;
using wine_quality_mobile.Models.Dtos.Files;
using wine_quality_mobile.Models.Requests.WineMaterialBatches;
using wine_quality_mobile.Models.Results.WineMaterialBatches;
using wine_quality_mobile.Services.WineMaterialBatches;

namespace wine_quality_mobile.Components;

public partial class ChartDialog
{
    private bool IsVisible { get; set; } = false;
    
    private Chart _lineChart;
    private LineConfig _config;
    private ParameterChartType _selectedChartType = ParameterChartType.Day;

    private string _wineMaterialBatchGrapeSortPhaseParameterId;

    [Inject] private IWineMaterialBatchService WineMaterialBatchService { get; set; }

    protected override void OnInitialized()
    {
        _config = new LineConfig
        {
            Options = new LineOptions
            {
                Title = new OptionsTitle
                {
                    Display = true,
                    Text = "Chart Title"
                },
                Legend = new Legend
                {
                    Display = true,
                    Position = Position.Bottom
                },
                Responsive = true,
                MaintainAspectRatio = false
            }
        };

        var lineDataset = new LineDataset<double>()
        {
            Label = "Parameter Name",
            Fill = false,
            LineTension = 0.5,
            BorderColor = "black"
        };

        _config.Data.Datasets.Add(lineDataset);

        base.OnInitialized();
    }

    public async Task Show(WineMaterialBatchGrapeSortPhaseParameterDetailsResult parameter)
    {
        try
        {
            _config.Data.Labels.Clear();
            (_config.Data.Datasets.ElementAt(0) as LineDataset<double>)!.Clear();
            
            _wineMaterialBatchGrapeSortPhaseParameterId = parameter.Id;
            
            var requestBody = new GetWineMaterialBatchPhaseParameterChartDataRequest
            {
                WineMaterialBatchGrapeSortPhaseParameterId = parameter.Id,
                ChartType = ParameterChartType.Hour
            };

            var result = await WineMaterialBatchService.GetChartDataForPhaseParameterAsync(requestBody);
            
            foreach (var label in result.Labels)
            {
                _config.Data.Labels.Add(label.ToLocalTime().ToShortDateString());
            }
            
            foreach (var value in result.Values)
            {
                (_config.Data.Datasets.ElementAt(0) as LineDataset<double>)!.Add(value);
            }

            await _lineChart.Update();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        IsVisible = true;
    }

    public void Hide()
    {
        IsVisible = false;
    }

    private async Task ChartTypeChanged(ChangeEventArgs arg)
    {
        try
        {
            _selectedChartType = Enum.Parse<ParameterChartType>(arg.Value!.ToString()!);
            
            var requestBody = new GetWineMaterialBatchPhaseParameterChartDataRequest
            {
                WineMaterialBatchGrapeSortPhaseParameterId = _wineMaterialBatchGrapeSortPhaseParameterId,
                ChartType = _selectedChartType
            };

            var result = await WineMaterialBatchService.GetChartDataForPhaseParameterAsync(requestBody);
            
            _config.Data.Labels.Clear();
            foreach (var label in result.Labels)
            {
                _config.Data.Labels.Add(label.ToLocalTime().ToShortDateString());
            }
            
            (_config.Data.Datasets.ElementAt(0) as LineDataset<double>)!.Clear();
            foreach (var value in result.Values)
            {
                (_config.Data.Datasets.ElementAt(0) as LineDataset<double>)!.Add(value);
            }

            await _lineChart.Update();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}