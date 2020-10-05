#pragma checksum "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\RequestData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74502621301928264f73712bead2dc3859573267"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp2.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\RequestData.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\RequestData.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/requestData")]
    public partial class RequestData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\RequestData.razor"
       

    //다른 페이지 갔다와도 값 유지하기 위해 static사용
    //private static IList<ArticleItem> articles = new List<ArticleItem>();
    private IList<ArticleItem> items = new List<ArticleItem>();



    /// <summary>
    /// 데이터 요청
    /// 참고 : CORS(Cross Origin Resource Sharing)
    /// </summary>
    private async void GetData()
    {
        Dictionary<string,object> dic = await client.GetFromJsonAsync<Dictionary<string,object>>("https://reqres.in/api/users");


        foreach(KeyValuePair<string,object> kvp in dic)
        {
            items.Add(new ArticleItem { Key = kvp.Key, Value = kvp.Value.ToString(), Type = kvp.Value.GetType().ToString() });
        }

        //값이 변경되었으니 화면 다시 렌더링시키기
        StateHasChanged();
    }





    public class ArticleItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient client { get; set; }
    }
}
#pragma warning restore 1591
