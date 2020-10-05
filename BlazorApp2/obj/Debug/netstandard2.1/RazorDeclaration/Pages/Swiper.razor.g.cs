#pragma checksum "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\Swiper.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a67a568711ab54b1565fb47e9d633bd338fab68"
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
#line 1 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/swiper")]
    public partial class Swiper : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\a\Source\Repos\BlazorApp2\BlazorApp2\Pages\Swiper.razor"
       
    IList<Item> items = new List<Item>();
    static int no = 0;
    Random rnd = new Random();

    /// <summary>
    /// 이 페이지 렌더링 후 호출됨
    /// </summary>
    /// <param name="firstRender">첫번째 렌더링인지 여부</param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        //다른 페이지에서 이 페이지로 들어온 처음이면 true. 이 페이지에서 렌더링이 계속된거면 false
        if (firstRender)
        {
        }
    }

    async void AddItem()
    {
        var dic = await hc.GetFromJsonAsync<Dictionary<string, object>>("https://cat-fact.herokuapp.com/facts/random");
        Console.WriteLine(dic);

        items.Add(new Item()
        {
            No = no++,
            Id = dic["_id"].ToString(),
            User = dic["user"].ToString(),
            Text = dic["text"].ToString(),
            CreatedAt = dic["createdAt"].ToString()
        });



        StateHasChanged();
    }



    class Item
    {
        public int No { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string CreatedAt { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient hc { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
    }
}
#pragma warning restore 1591
