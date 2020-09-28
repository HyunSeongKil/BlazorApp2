#pragma checksum "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\Pages\InfiniteScroll.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4f1e6495b4fe874ef36db73c2ce3e9f7cbdd039"
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
#line 1 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/infinitescroll")]
    public partial class InfiniteScroll : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 35 "C:\Users\hyunseongkil\Source\Repos\BlazorApp2\BlazorApp2\Pages\InfiniteScroll.razor"
       
    bool IsLoading = false;
    Random rnd = new Random();
    IList<Item> items = new List<Item>();

    //@see https://blazor-university.com/javascript-interop/calling-javascript-from-dotnet/passing-html-element-references/
    private ElementReference spinner;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstRender"></param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            //js 함수를 호출하여 dotnet객체 참고정보를 전달
            await JsRuntime.InvokeVoidAsync("setDotNetRef", DotNetObjectReference.Create(this));

            //초기 데이터 로드
            LoadDatas();

            StateHasChanged();
        }
    }


    /// <summary>
    /// js가 호출할 수 있는 메소드
    /// 반드시 public 이어야 함
    /// 여기서는 데모용으로 랜덤값을 생성했으나, 실제에서는 api를 호출하여 데이터를 생성하게 됨
    /// </summary>
    [JSInvokable]
    public async void LoadDatas()
    {
        ShowPinner(true);

        await Task.Delay(1000);

        for (int i=0; i<10; i++)
        {
            items.Add(new Item()
            {
                No = rnd.Next(),
                Title = DateTime.Now.ToString()
            });
        }

        ShowPinner(false);
    }

    private void ShowPinner(bool b)
    {
        IsLoading = b;
        StateHasChanged();
    }

    class Item
    {
        public int No { get; set; }
        public string Title { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
    }
}
#pragma warning restore 1591