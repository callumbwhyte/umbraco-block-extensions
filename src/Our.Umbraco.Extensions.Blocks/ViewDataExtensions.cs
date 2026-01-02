using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Our.Umbraco.Extensions.Blocks
{
    public static class ViewDataExtensions
    {
        public static IPublishedElement? GetSettings<T>(this ViewDataDictionary<T> viewData)
            where T : IPublishedElement
        {
            viewData.TryGetValue("Settings", out var settings);

            return settings as IPublishedElement;
        }
    }
}