using BlazorApp2.Shared;
using BlazorApp2.Models;
using BlazorApp2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp2.Pages
{
    public partial class TravelCube
    {

        private bool isLoading = false;

        private SirenModal sirenModal { get; set; }

        private ReactUsersModal reactUsersModal { get; set; }

        private Cube prevSiblingCube = null;
        private Cube nextSiblingCube = null;
        private Cube parentCube = null;
        private Cube childCube = null;
        private Cube currentCube = new Cube();

        private string reactUsersParamCubeId = "";
        private string reactUsersParamUserId = "";
        private string reactUsersParamGbn = "";


        /// <summary>
        /// 자식 등록 페이지로 이동
        /// </summary>
        private void AddChild()
        {
            //등록 페이지로 이동
            navManager.NavigateTo("/add-child-cube?parentCubeId=" + currentCube.CubeId);
        }

        /// <summary>
        /// 수정 페이지로 이동
        /// </summary>
        private void Modify()
        {
            //수정 페이지로 이동
            navManager.NavigateTo("/modify-cube?cubeId=" + currentCube.CubeId);
        }

        /// <summary>
        /// 삭제
        /// </summary>
        private async void Delete()
        {
            bool b = await jsRuntime.InvokeAsync<bool>("window.confirm", "삭제할까요?");
            System.Diagnostics.Debug.WriteLine(b);

            if (b)
            {
                //TODO at server 자식 존재하지 않으면 삭제, 존재하면 삭제 플래그 처리. 화면에는 "작성자에의해 삭제되었습니다." 표시

                //삭제 후 다음 형제로 이동.
                if (null != nextSiblingCube)
                {
                    SetCurrentCube(nextSiblingCube);
                    return;
                }

                //다음 형제 미존재시 부모로 이동.
                if (null != parentCube)
                {
                    SetCurrentCube(parentCube);
                    return;
                }

                //부모 미존재시 랜덤 이동
                GotoRandom(null);
            }
        }

        /// <summary>
        /// 신고
        /// </summary>
        private void Siren()
        {
            //신고 모달 실행. 신고사유 입력. 저장
            sirenModal.Open();


            //다음 형제로 이동. 다음 형제 미존재시 부모로 이동. 부모 미존재시 랜덤 이동

            //화면에 "신고처리된 글입니다" 표시
        }


        /// <summary>
        /// 상세 페이지로 이동
        /// </summary>
        private void Detail()
        {
            navManager.NavigateTo("/detail-cube?cubeId=" + currentCube.CubeId);
        }





        /// <summary>
        /// indexeddb에 저장된 마지막으로 조회한 cubeid 리턴
        /// </summary>
        /// <returns>CubeId or null</returns>
        private string GetLastestCubeId()
        {
            System.Collections.Specialized.NameValueCollection nameValues = System.Web.HttpUtility.ParseQueryString(new Uri(navManager.Uri).Query);
            if (nameValues.AllKeys.Contains("cubeId"))
            {
                return nameValues["cubeId"];
            }

            //indexeddb에서 추출
            return null;
        }


        /// <summary>
        /// 이전 형제로 이동
        /// </summary>
        /// <param name="args"></param>
        protected void GotoPrevSibling(MouseEventArgs args)
        {
            SetCurrentCube(prevSiblingCube);
        }

        /// <summary>
        /// 다음 형제로 이동
        /// </summary>
        /// <param name="args"></param>
        protected void GotoNextSibling(MouseEventArgs args)
        {
            SetCurrentCube(nextSiblingCube);
        }

        /// <summary>
        /// 부모로 이동
        /// </summary>
        /// <param name="args"></param>
        protected void GotoParent(MouseEventArgs args)
        {
            SetCurrentCube(parentCube);

        }

        /// <summary>
        /// 자식으로 이동
        /// </summary>
        /// <param name="args"></param>
        protected void GotoChild(MouseEventArgs args)
        {
            SetCurrentCube(childCube);
        }

        /// <summary>
        /// 랜덤 이동
        /// </summary>
        /// <param name="args"></param>
        protected async void GotoRandom(MouseEventArgs args)
        {
            SetCurrentCube(await GetRandomCubeAsync());
        }


        /// <summary>
        /// 현재 큐브 설정
        /// </summary>
        /// <param name="cube"></param>
        protected async void SetCurrentCube(Cube cube)
        {
            isLoading = true;
            StateHasChanged();

            currentCube = cube;

            //전후좌우 데이터 미리 조회(비동기)
            Task<Cube> parentCubeTask = GetParentCubeAsync();
            Task<Cube> childCubeTask = GetChildCubeAsync();
            Task<Cube> prevSiblingCubeTask = GetPrevSiblingCubeAsync();
            Task<Cube> nextSiblingCubeTask = GetNextSiblingCubeAsync();


            await Task.WhenAll(parentCubeTask, childCubeTask, prevSiblingCubeTask, nextSiblingCubeTask);

            parentCube = parentCubeTask.Result;
            childCube = childCubeTask.Result;
            prevSiblingCube = prevSiblingCubeTask.Result;
            nextSiblingCube = nextSiblingCubeTask.Result;

            isLoading = false;
            StateHasChanged();

            //todo 트렌드맵 조회 by tag list
            IList<string> keywords = new List<string>();
            foreach (Tag x in currentCube.Tags)
            {
                keywords.Add(x.Nm);
            }

            //TODO CORS땜에 호출 안됨 ㅠ
            //IList<TrendMapResult> results = await GetTrendMapResultsAsync(new TrendMapRequestParam(), keywords);

            //network graph 생성
            //IList<NetworkNode> nodes = Nodes(results);
            //IList<NetworkEdge> edges = Edges(results);

            await jsRuntime.InvokeVoidAsync("createVisNetwork", Util.Serialize(currentCube.Tags, true));

        }

        private IList<NetworkEdge> Edges(IList<TrendMapResult> results)
        {
            IList<NetworkEdge> edges = new List<NetworkEdge>();


            int id1 = 0, id2 = 0;
            foreach (TrendMapResult result in results)
            {
                id1 += 10;
                id2 = 0;

                edges.Add(new NetworkEdge()
                {
                    From = 0,
                    To = id1 + id2++
                });

                foreach (TrendMapResultChild child in result.ChildList)
                {
                    edges.Add(new NetworkEdge()
                    {
                        From = id1 + 0,
                        To = id1 + id2++
                    });
                }
            }

            return edges;
        }

        private IList<NetworkNode> Nodes(IList<TrendMapResult> results)
        {
            IList<NetworkNode> nodes = new List<NetworkNode>();

            nodes.Add(new NetworkNode()
            {
                Id = 0,
                Label = "나"
            });

            int id1 = 0, id2 = 0;

            foreach (TrendMapResult result in results)
            {
                id1 += 10;
                id2 = 0;

                nodes.Add(new NetworkNode()
                {
                    Id = id1 + id2++,
                    Label = result.Label
                });
                foreach (TrendMapResultChild child in result.ChildList)
                {
                    nodes.Add(new NetworkNode()
                    {
                        Id = id1 + id2++,
                        Label = child.Label
                    });
                }
            }

            return nodes;
        }




        /// <summary>
        /// cubeid로 데이터 요청
        /// </summary>
        /// <param name="cubeId"></param>
        /// <returns></returns>
        private async Task<Cube> GetCubeByCubeId(string cubeId)
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }





        /// <summary>
        /// 싫어요 숫자 토글
        /// </summary>
        private async void UpdateUnlikeCo()
        {
            CubeReact cubeReact = await GetCubeReactAsync("userid", currentCube.CubeId);

            //싫어요한적 있으면 갯수 감소
            if (cubeReact.Unlike)
            {
                cubeReact.Unlike = false;

                currentCube.UnlikeCo--;
            }
            else
            {
                //싫어요한적 없으면 갯수 증가
                cubeReact.Unlike = true;

                currentCube.UnlikeCo++;
            }


            UpdateCubeReactAsync(cubeReact);


            StateHasChanged();
        }




        /// <summary>
        /// 신고 완료 후
        /// </summary>
        public void SirenSaved()
        {
            //신고 후 다음 형제로 이동.
            if (null != nextSiblingCube)
            {
                SetCurrentCube(nextSiblingCube);
                return;
            }

            //다음 형제 미존재시 부모로 이동.
            if (null != parentCube)
            {
                SetCurrentCube(parentCube);
                return;
            }

            //부모 미존재시 랜덤 이동
            GotoRandom(null);
        }


        /// <summary>
        /// TODO 좋아요 누른 사용자 목록
        /// </summary>
        private void PopupLikeUserList()
        {
            reactUsersParamCubeId = currentCube.CubeId;
            reactUsersParamUserId = "userId";
            reactUsersParamGbn = "LIKE";

            reactUsersModal.Open();
        }


        /// <summary>
        /// TODO 싫어요 누른 사용자 목록
        /// </summary>
        private void PopupUnlikeUserList()
        {
            reactUsersParamCubeId = currentCube.CubeId;
            reactUsersParamUserId = "userId";
            reactUsersParamGbn = "UNLIKE";

            reactUsersModal.Open();
        }


        /// <summary>
        /// TODO 자식 글 등록 폼 실행
        /// </summary>
        private void PopupChildRegistForm()
        {

        }


        /// <summary>
        /// TODO 콤멘트 등록 폼 실행
        /// </summary>
        private void PopupCommentRegistForm()
        {

        }


        /// <summary>
        /// 팝업 and 카테고리 코드로 필터링 목록
        /// </summary>
        private void PopupAndFilteringByCtgryCode()
        {

        }

        /// <summary>
        /// 팝업 and 태그명으로 필터링 목록
        /// </summary>
        private void PopupAndFilteringByTagNm()
        {

        }


        /// <summary>
        /// 팝업 자식 목록
        /// </summary>
        private void PopupChildrenList()
        {

        }


        /// <summary>
        /// 팝업 콤멘트 목록
        /// </summary>
        private void PopupCommentList()
        {

        }


        /// <summary>
        /// 팝업 작성자가 작성한 데이터 목록
        /// </summary>
        private void PopupAndFilteringByRegisterId()
        {

        }



        async Task<IList<TrendMapResult>> GetTrendMapResultsAsync(TrendMapRequestParam param, IList<string> keywords)
        {
            string url = "http://qt.some.co.kr/TrendMap/JSON/ServiceHandler";
            string p = param.ToGetParamString();

            IList<Task<HttpResponseMessage>> tasks = new List<Task<HttpResponseMessage>>();

            //keyword 갯수만큼 호출
            for (int i = 0; i < keywords.Count; i++)
            {
                tasks.Add(httpClient.GetAsync(url + p + "&keyword=" + keywords[i]));
            }


            await Task.WhenAll(tasks);


            IList<TrendMapResult> results = new List<TrendMapResult>();
            for (int i = 0; i < tasks.Count; i++)
            {
                Task<HttpResponseMessage> t = tasks[i];

                string message = t.Result.Content.ReadAsStringAsync().Result;

                //json문자열을 Class로 변환
                TrendMapResult result = System.Text.Json.JsonSerializer.Deserialize<TrendMapResult>(message, new System.Text.Json.JsonSerializerOptions()
                {
                    PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                });
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// 다음 형제 데이터 요청
        /// </summary>
        /// <returns></returns>
        private async Task<Cube> GetNextSiblingCubeAsync()
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }

        /// <summary>
        /// 이전 형제 데이터 요청
        /// </summary>
        /// <returns></returns>
        private async Task<Cube> GetPrevSiblingCubeAsync()
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }

        /// <summary>
        /// 자식 데이터 요청
        /// </summary>
        /// <returns></returns>
        private async Task<Cube> GetChildCubeAsync()
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }

        /// <summary>
        /// 부모 데이터 요청
        /// </summary>
        /// <returns></returns>
        private async Task<Cube> GetParentCubeAsync()
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }

        /// <summary>
        /// 랜덤 데이터 요청
        /// </summary>
        /// <returns></returns>
        private async Task<Cube> GetRandomCubeAsync()
        {
            await Task.Delay(Util.RndValue(500));

            return Util.CreateDummyCube();
        }


        /// <summary>
        /// 좋아요 숫자 토글
        /// </summary>
        private async void UpdateLikeCo()
        {
            CubeReact cubeReact = await GetCubeReactAsync("userid", currentCube.CubeId);

            //좋아요한적 있으면 갯수 감소
            if (cubeReact.Like)
            {
                cubeReact.Like = false;

                currentCube.LikeCo--;
            }
            else
            {
                //좋아요한적 없으면 갯수 증가
                cubeReact.Like = true;

                currentCube.LikeCo++;
            }


            UpdateCubeReactAsync(cubeReact);


            StateHasChanged();
        }


        /// <summary>
        /// 반응정보 업데이트
        /// </summary>
        /// <param name="cubeReact"></param>
        private async void UpdateCubeReactAsync(CubeReact cubeReact)
        {
            await Task.Delay(Util.RndValue(500));

        }


        /// <summary>
        /// 반응정보 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cubeId"></param>
        /// <returns></returns>
        private async Task<CubeReact> GetCubeReactAsync(string userId, string cubeId)
        {
            await Task.Delay(Util.RndValue(500));

            CubeReact cubeReact = new CubeReact
            {
                Like = Util.RndBool(),
                Unlike = Util.RndBool()
            };

            return cubeReact;
        }
    }
}
