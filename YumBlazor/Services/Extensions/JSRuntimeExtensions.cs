using Microsoft.JSInterop;

namespace YumBlazor.Services.Extensions;

public static class JsRuntimeExtensions
{
    public static async Task ToastrSuccess(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("showToastr", "success", message);
    }

    public static async Task ToastrError(this IJSRuntime jsRuntime, string message)
    {
        await jsRuntime.InvokeVoidAsync("showToastr", "error", message);
    }
}