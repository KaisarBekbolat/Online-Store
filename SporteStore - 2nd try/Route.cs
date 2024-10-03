using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SporteStore___2nd_try;

public static class Route
{
    public static void Routing(this IEndpointRouteBuilder routeBuilder){
        routeBuilder.MapControllerRoute("catpage", "{category}/page{productPage:int}", new { controller = "Home", Action = "Index" });

        routeBuilder.MapControllerRoute("page", "Page{productPage:int}", new { controller = "Home", action = "Index" });

        routeBuilder.MapControllerRoute("category", "{category}", new { controller = "Home", action = "Index" });

        routeBuilder.MapControllerRoute("pagination", "Products/PageProduct{productPage:int}", new { controller = "Home", action = "Index" });
        // TODO there was CONFILIC of LINKS as follows: 1) ""catpage", "{category}/page{productPage:int}"" and
        // 2) ""("pagination", "Products/Page{productPage:int}"
        // So WHENEVER i tried to OPEN page for example "/Products/Page2"- it lead to run of FIRST "catpage" MapContollerRoute
        // This is why it was LAST was changed to "Product/PageProduct" - addition of Product-postfix
    }
}
