namespace wine_quality_mobile.Models.Dtos.Files;

public class ChartPointDto {
    
    public ChartPointDto(double x, double y) {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }
}