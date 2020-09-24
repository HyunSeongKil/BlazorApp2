#pragma checksum "D:\work\blazor\BlazorApp2\BlazorApp2\Pages\Todo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "917d509787c1f590f4fb2faea2cc465ce880d96f"
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
#line 1 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\work\blazor\BlazorApp2\BlazorApp2\_Imports.razor"
using BlazorApp2.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo")]
    public partial class Todo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "D:\work\blazor\BlazorApp2\BlazorApp2\Pages\Todo.razor"
       
    //다른 페이지 갔다와도 값 유지하기 위해 static사용
    private static IList<TodoItem> todos = new List<TodoItem>();
    private string newTodo;
    private static int no = 0;
    //input element 참고 변수
    private ElementReference inpTodo;


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
            //js함수 호출
            await JsRuntime.InvokeVoidAsync("setFocus", inpTodo);
        }
    }


    /// <summary>
    /// todo item 추가
    /// </summary>
    private void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(newTodo))
        {
            todos.Add(new TodoItem { No = no++, Title = newTodo });
            newTodo = string.Empty;
        }
    }

    /// <summary>
    /// input element에서 keyup
    /// </summary>
    /// <param name="e"></param>
    private void keyup(KeyboardEventArgs e)
    {
        if ("Enter".Equals(e.Code))
        {
            AddTodo();
        }
    }


    /// <summary>
    /// item 삭제
    /// </summary>
    /// <param name="e"></param>
    /// <param name="item"></param>
    private async void DeleteItem(MouseEventArgs e, TodoItem item)
    {
        //js 함수 호출
        bool b = await JsRuntime.InvokeAsync<bool>("confirm", "삭제하시겠습니까?");
        
        //디버깅 메시지
        System.Diagnostics.Debug.WriteLine(item);


        todos.Remove(item);


        //값이 변경되었으니 화면 다시 렌더링시키기
        StateHasChanged();

    }



    public class TodoItem
    {
        public int No { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
    }
}
#pragma warning restore 1591
