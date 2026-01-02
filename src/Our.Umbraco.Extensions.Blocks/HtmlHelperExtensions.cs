using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Our.Umbraco.Extensions.Blocks
{
    public static class HtmlHelperExtensions
    {
        public static async Task RenderElement(this IHtmlHelper htmlHelper, IPublishedElement? element, string? folder = null, ViewDataDictionary? viewData = null)
        {
            if (element == null)
            {
                return;
            }

            var alias = element.ContentType.Alias.ToFirstUpperInvariant();

            if (await TryRenderViewComponent(htmlHelper.ViewContext, alias) == true)
            {
                return;
            }

            var view = Path.Combine(folder ?? string.Empty, alias);

            if (viewData == null)
            {
                viewData = new ViewDataDictionary(htmlHelper.ViewData);
            }

            viewData["ViewModel"] = htmlHelper.ViewData.Model;

            await htmlHelper.RenderPartialAsync(view, element, viewData);
        }

        public static async Task RenderElement(this IHtmlHelper htmlHelper, IBlockReference<IPublishedElement, IPublishedElement>? block, string? folder = null, ViewDataDictionary? viewData = null)
        {
            if (block?.Content == null)
            {
                return;
            }

            var alias = block.Content.ContentType.Alias.ToFirstUpperInvariant();

            if (await TryRenderViewComponent(htmlHelper.ViewContext, alias) == true)
            {
                return;
            }

            var view = Path.Combine(folder ?? string.Empty, alias);

            if (viewData == null)
            {
                viewData = new ViewDataDictionary(htmlHelper.ViewData);
            }

            viewData["Settings"] = block.Settings;

            viewData["ViewModel"] = htmlHelper.ViewData.Model;

            await htmlHelper.RenderPartialAsync(view, block.Content, viewData);
        }

        public static async Task RenderElements(this IHtmlHelper htmlHelper, IEnumerable<IPublishedElement>? elements, string? folder = null)
        {
            if (elements?.Any() == true)
            {
                foreach (var element in elements)
                {
                    await htmlHelper.RenderElement(element, folder);
                }
            }
        }

        public static async Task RenderElements(this IHtmlHelper htmlHelper, IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? blocks, string? folder = null)
        {
            if (blocks?.Any() == true)
            {
                foreach (var block in blocks)
                {
                    await htmlHelper.RenderElement(block, folder);
                }
            }
        }

        private static async Task<bool> TryRenderViewComponent(ViewContext viewContext, string name)
        {
            try
            {
                var viewComponentHelper = viewContext.HttpContext.RequestServices.GetService<IViewComponentHelper>();

                var viewComponentResult = await viewComponentHelper?.InvokeAsync(name)!;

                if (viewComponentResult != null)
                {
                    viewContext.Writer.Write(viewComponentResult);

                    return true;
                }
            }
            catch
            {

            }

            return false;
        }
    }
}