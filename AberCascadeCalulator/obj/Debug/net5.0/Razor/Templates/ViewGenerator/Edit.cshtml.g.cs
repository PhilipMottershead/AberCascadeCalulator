#pragma checksum "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d86af62f30c1a0209ad2499199e64a2c2bef13ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Templates_ViewGenerator_Edit), @"mvc.1.0.view", @"/Templates/ViewGenerator/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d86af62f30c1a0209ad2499199e64a2c2bef13ac", @"/Templates/ViewGenerator/Edit.cshtml")]
    public class Templates_ViewGenerator_Edit : Microsoft.VisualStudio.Web.CodeGeneration.Templating.RazorTemplateBase
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("@model ");
#nullable restore
#line 5 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
   Write(Model.ViewDataTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
  
    if (Model.IsPartialView)
    {
    }
    else if (Model.IsLayoutPageSelected)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("@{\r\n    ");
            WriteLiteral("ViewData[\"Title\"] = \"");
#nullable restore
#line 14 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                      Write(Model.ViewName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n");
#nullable restore
#line 15 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
        if (!string.IsNullOrEmpty(Model.LayoutPageFile))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            WriteLiteral("Layout = \"");
#nullable restore
#line 17 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
           Write(Model.LayoutPageFile);

#line default
#line hidden
#nullable disable
            WriteLiteral("\";\r\n");
#nullable restore
#line 18 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("}\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("<h1>");
#nullable restore
#line 21 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
 Write(Model.ViewName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 23 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("@{\r\n    ");
            WriteLiteral("Layout = null;\r\n");
            WriteLiteral("}\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("<!DOCTYPE html>\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("<html>\r\n");
            WriteLiteral("<head>\r\n    ");
            WriteLiteral("<meta name=\"viewport\" content=\"width=device-width\" />\r\n    ");
            WriteLiteral("<title>");
#nullable restore
#line 35 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
        Write(Model.ViewName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</title>\r\n");
            WriteLiteral("</head>\r\n");
            WriteLiteral("<body>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 39 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
        //    PushIndent("    ");
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4>");
#nullable restore
#line 41 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
 Write(Model.ViewDataTypeShortName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
            WriteLiteral("<hr />\r\n");
            WriteLiteral("<div class=\"row\">\r\n    ");
            WriteLiteral("<div class=\"col-md-4\">\r\n        ");
            WriteLiteral("<form asp-action=\"");
#nullable restore
#line 45 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                       Write(Model.ViewName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            ");
            WriteLiteral("<div asp-validation-summary=\"ModelOnly\" class=\"text-danger\"></div>\r\n");
#nullable restore
#line 47 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
        foreach (PropertyMetadata property in Model.ModelMetadata.Properties)
        {
            if (property.IsPrimaryKey)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<input type=\"hidden\" asp-for=\"");
#nullable restore
#line 51 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                       Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n");
#nullable restore
#line 52 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                continue;
            }

            if (property.Scaffold)
            {
                if (property.IsReadOnly)
                {
                    continue;
                }

                if (property.IsForeignKey)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"form-group\">\r\n                ");
            WriteLiteral("<label asp-for=\"");
#nullable restore
#line 65 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                             Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"control-label\"></label>\r\n                ");
            WriteLiteral("<select asp-for=\"");
#nullable restore
#line 66 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                              Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"form-control\" asp-items=\"ViewBag.");
#nullable restore
#line 66 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                                                                              Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></select>\r\n                ");
            WriteLiteral("<span asp-validation-for=\"");
#nullable restore
#line 67 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                       Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"text-danger\"></span>\r\n            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 69 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                    continue;
                }

                bool isCheckbox = property.TypeName.Equals("System.Boolean");
                if (isCheckbox)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"form-group form-check\">\r\n                ");
            WriteLiteral("<label class=\"form-check-label\">\r\n                    ");
            WriteLiteral("<input class=\"form-check-input\" asp-for=\"");
#nullable restore
#line 77 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                                          Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" /> ");
            WriteLiteral("@Html.DisplayNameFor(model => model.");
#nullable restore
#line 77 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                                                                                                          Write(GetValueExpression(property));

#line default
#line hidden
#nullable disable
            WriteLiteral(")\r\n                ");
            WriteLiteral("</label>\r\n            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 80 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                }
                else if (property.IsEnum && !property.IsEnumFlags)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"form-group\">\r\n                ");
            WriteLiteral("<label asp-for=\"");
#nullable restore
#line 84 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                             Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"control-label\"></label>\r\n                ");
            WriteLiteral("<select asp-for=\"");
#nullable restore
#line 85 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                              Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"form-control\"></select>\r\n                ");
            WriteLiteral("<span asp-validation-for=\"");
#nullable restore
#line 86 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                       Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"text-danger\"></span>\r\n            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 88 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                }
                else if (property.IsMultilineText)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"form-group\">\r\n                ");
            WriteLiteral("<label asp-for=\"");
#nullable restore
#line 92 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                             Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"control-label\"></label>\r\n                ");
            WriteLiteral("<textarea asp-for=\"");
#nullable restore
#line 93 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"form-control\"></textarea>\r\n                ");
            WriteLiteral("<span asp-validation-for=\"");
#nullable restore
#line 94 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                       Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"text-danger\"></span>\r\n            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 96 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"form-group\">\r\n                ");
            WriteLiteral("<label asp-for=\"");
#nullable restore
#line 100 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                             Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"control-label\"></label>\r\n                ");
            WriteLiteral("<input asp-for=\"");
#nullable restore
#line 101 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                             Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"form-control\" />\r\n                ");
            WriteLiteral("<span asp-validation-for=\"");
#nullable restore
#line 102 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                       Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"text-danger\"></span>\r\n            ");
            WriteLiteral("</div>\r\n");
#nullable restore
#line 104 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                }
            }
            // Ideally we shouldn't be here  but if the user marks the foreign key as [ScaffoldColumn(false)], we want to atleast try to make it work.
            else if (property.IsForeignKey)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("<input type=\"hidden\" asp-for=\"");
#nullable restore
#line 109 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                                   Write(property.PropertyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" />\r\n");
#nullable restore
#line 110 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
                continue;
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
#nullable restore
#line 125 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
  
    if (Model.ReferenceScriptLibraries)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("@section Scripts {\r\n    ");
            WriteLiteral("@{await Html.RenderPartialAsync(\"_ValidationScriptsPartial\");}\r\n");
            WriteLiteral("}\r\n");
#nullable restore
#line 131 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
    }
    // The following code closes the tag used in the case of a view using a layout page and the body and html tags in the case of a regular view page
    if (!Model.IsPartialView && !Model.IsLayoutPageSelected)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("</body>\r\n");
            WriteLiteral("</html>\r\n");
#nullable restore
#line 137 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 140 "/home/philip/Documents/Git/Aber_Cascade_Calulator/AberCascadeCalulator/Templates/ViewGenerator/Edit.cshtml"
 
    string GetAssociationName(IPropertyMetadata property)
    {
        //Todo: Implement properly.
        return property.PropertyName;
    }

    string GetValueExpression(IPropertyMetadata property)
    {
        return property.PropertyName;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
