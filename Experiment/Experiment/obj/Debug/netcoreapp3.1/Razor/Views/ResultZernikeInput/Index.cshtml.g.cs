#pragma checksum "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\ResultZernikeInput\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc5bfbb183ad4402d07cd23dbe7be108be199589"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ResultZernikeInput_Index), @"mvc.1.0.view", @"/Views/ResultZernikeInput/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\_ViewImports.cshtml"
using Experiment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\_ViewImports.cshtml"
using Experiment.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\ResultZernikeInput\Index.cshtml"
using System.Drawing.Imaging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\ResultZernikeInput\Index.cshtml"
using Experiment.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc5bfbb183ad4402d07cd23dbe7be108be199589", @"/Views/ResultZernikeInput/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"faf0ffdfc37e829f0a6ace78ab6ffd92b50a618d", @"/Views/_ViewImports.cshtml")]
    public class Views_ResultZernikeInput_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Experiment.ViewModels.ZernikeInputResultModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<img");
            BeginWriteAttribute("src", " src=\"", 253, "\"", 359, 1);
#nullable restore
#line 11 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\ResultZernikeInput\Index.cshtml"
WriteAttributeValue("", 259, $"data:image/png;base64,{Convert.ToBase64String(Model.OutputImage.ToByteArray(ImageFormat.Bmp))}", 259, 100, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<img");
            BeginWriteAttribute("src", " src=\"", 369, "\"", 473, 1);
#nullable restore
#line 12 "D:\Alexej Huber\Projects\git\InterferenceFringes\Experiment\Experiment\Views\ResultZernikeInput\Index.cshtml"
WriteAttributeValue("", 375, $"data:image/png;base64,{Convert.ToBase64String(Model.HeightMap.ToByteArray(ImageFormat.Bmp))}", 375, 98, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Experiment.ViewModels.ZernikeInputResultModel> Html { get; private set; }
    }
}
#pragma warning restore 1591