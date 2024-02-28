using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApplicationTest.Models;

namespace WebApplicationTest.TagHelpers
{
    public class SortHeaderTagHelper : TagHelper
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string minstanding { get; set; }

        public SortState Property { get; set; } // значение текущего свойства, для которого создается тег
        public SortState Current { get; set; }  // значение активного свойства, выбранного для сортировки
        public string? Action { get; set; }  // действие контроллера, на которое создается ссылка
        public bool Up { get; set; }    // сортировка по возрастанию или убыванию

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; } = null!;

        IUrlHelperFactory urlHelperFactory;
        public SortHeaderTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "a";
            //string? url = urlHelper.Action(Action, new { sortOrder = Property });

            var routeValues = new
            {
                FName,
                LName,
                minstanding,
                sortOrder = Property
            };

            string url = urlHelper.Action(Action, routeValues);

            output.Attributes.SetAttribute("href", url);

            // если текущее свойство имеет значение CurrentSort
            if (Current == Property)
            {
                string arrowSymbol = Up ? "▲" : "▼";
                output.PreContent.Append(arrowSymbol);
            }

        }
    }
}
