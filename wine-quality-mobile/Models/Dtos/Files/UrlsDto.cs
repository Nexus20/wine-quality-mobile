namespace wine_quality_mobile.Models.Dtos.Files;

public class UrlsDto
{
    public UrlsDto(List<FileNameWithUrlDto> urls)
    {
        Urls = urls;
    }

    public List<FileNameWithUrlDto> Urls { get; }
}