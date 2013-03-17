using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (var index = 1; index <= pagingInfo.TotalPages; index++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(index));
                tag.InnerHtml = index.ToString();
                if (index == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag);
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}