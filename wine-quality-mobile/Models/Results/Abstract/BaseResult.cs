namespace wine_quality_mobile.Models.Results.Abstract;

public abstract class BaseResult
{
    public string Id { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}