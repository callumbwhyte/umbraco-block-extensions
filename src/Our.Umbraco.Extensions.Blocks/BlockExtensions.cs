using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Our.Umbraco.Extensions.Blocks
{
    public static class BlockExtensions
    {
        public static IPublishedElement? GetBlock(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? blocks, Func<IPublishedElement, bool>? predicate = null)
        {
            return blocks.GetBlocks(predicate).FirstOrDefault();
        }

        public static T? GetBlock<T>(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? blocks, Func<T, bool>? predicate = null)
            where T : IPublishedElement
        {
            return blocks.GetBlocks(predicate).FirstOrDefault();
        }

        public static IEnumerable<IPublishedElement> GetBlocks(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? blocks, Func<IPublishedElement, bool>? predicate = null)
        {
            return blocks.GetBlocks<IPublishedElement>(predicate);
        }

        public static IEnumerable<T> GetBlocks<T>(this IEnumerable<IBlockReference<IPublishedElement, IPublishedElement>>? blocks, Func<T, bool>? predicate = null)
            where T : IPublishedElement
        {
            var items = blocks?.Select(x => x.Content).OfType<T>() ?? [];

            if (predicate != null)
            {
                return items.Where(predicate);
            }

            return items;
        }

        public static T? GetContent<T>(this IBlockReference<IPublishedElement, IPublishedElement> block)
            where T : IPublishedElement
        {
            if (block.Content is T content)
            {
                return content;
            }

            return default;
        }

        public static T? GetSettings<T>(this IBlockReference<IPublishedElement, IPublishedElement> block)
            where T : IPublishedElement
        {
            if (block.Settings is T settings)
            {
                return settings;
            }

            return default;
        }
    }
}