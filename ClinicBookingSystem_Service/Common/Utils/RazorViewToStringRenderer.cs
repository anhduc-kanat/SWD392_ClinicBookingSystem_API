using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorLight;

namespace ClinicBookingSystem_Service.Common.Utils;

public class RazorViewToStringRenderer
{
    private readonly RazorLightEngine _engine;

    public RazorViewToStringRenderer()
    {
        _engine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Directory.GetCurrentDirectory()) // or a specific path to your templates
            .UseMemoryCachingProvider()
            .Build();
    }

    public async Task<string> RenderViewToStringAsync<TModel>(string viewPath, TModel model)
    {
        string templatePath = Path.Combine(Directory.GetCurrentDirectory(), viewPath);
        string templateContent = await File.ReadAllTextAsync(templatePath);
        string result = await _engine.CompileRenderStringAsync(viewPath, templateContent, model);
        return result;
    }
}