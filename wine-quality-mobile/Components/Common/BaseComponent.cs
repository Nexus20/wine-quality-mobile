using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using wine_quality_mobile.Resources.Languages;
using wine_quality_mobile.States;

namespace wine_quality_mobile.Components.Common;

public class BaseComponent : ComponentBase
{
    [Inject]
    protected AppState AppState { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected IStringLocalizer<Localizations> Localizer { get; set; } = null!;
}