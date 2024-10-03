using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SporteStore___2nd_try.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace SportsStore.Infrastructure
{
    // [HtmlTargetElement("div", Attributes ="page-model")]   // TODO Here instead of writing "div"
    //                                                        // you wrote "dev" - that was result of not appearing and not working
    //                                                         // TODO is it possible to create custom TAGHelper as "<PageLink>"
    // public class PageLinkTagHelper : TagHelper{
        
    //     private IUrlHelperFactory urlHelperFactory;

    //     public PageLinkTagHelper(IUrlHelperFactory helperFactory){
    //         urlHelperFactory = helperFactory;
    //     }

    //     [ViewContext]
    //     [HtmlAttributeNotBound]
    //     public ViewContext? ViewContext{get;set;}
    //     public PagingInfo? PageModel{get;set;}
    //     public string PageAction{get;set;}
    //     public override void Process(TagHelperContext context, TagHelperOutput output)
    //     {
    //         if(ViewContext!=null && PageModel!=null){
    //             IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
    //             TagBuilder result = new TagBuilder("div");
    //             for(int i=1; i<=PageModel.Pages(); i++){
    //                 TagBuilder tag = new TagBuilder("a");
    //                 tag.Attributes["href"]=urlHelper.Action(PageAction, new {productPage=i});
    //                 tag.InnerHtml.Append(i.ToString()+"  ");
    //                 result.InnerHtml.AppendHtml(tag);
    //             }
    //             output.Content.AppendHtml(result.InnerHtml);
    //         }
    //     }
    // }

    [HtmlTargetElement("div", Attributes ="page-model")]
    public class PageLinkTagHelper : TagHelper{

        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelper){
            urlHelperFactory = urlHelper;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext{get;set;}
        // TODO from above code ONLY "ViewContext" is NOT being bound, other code will be bound
        // so from code below "PageModel" and "PageAction" will be bound from FRONT-END side
        public PagingInfo? PageModel{get;set;}
        public string? PageAction{get;set;}

        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues{get;set;} = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        // Code that was bound will be used BELOW, first USAGE is "PageModel.Pages()" inside loop
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext!=null && PageModel != null){
                TagBuilder result = new TagBuilder("div");
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
        
                for (int i=1; i<= PageModel.Pages(); i++){
                    TagBuilder tag = new TagBuilder("a");
                    PageUrlValues["productPage"] = i;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                    System.Console.WriteLine(tag.Attributes["href"]);
                    if(PageClassesEnabled){
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }
                    tag.InnerHtml.Append(i.ToString()+" ");
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result);
            }
        }
    }
}
