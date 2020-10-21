# Blazor WebAssembly

## 공통
	- js는 정적페이지(html)에 위치해야 함
		. razor파일에 위치하면 안됨
		. razor파일에 <script>존재하면 visual studio가 자동으로 warning메시지 표시함
	- css는 가능하면 빨리 적용되어야 하기 때문에 <head>...</head>사이에 위치함
	- js는 모든 렌더링 완료 후 실행되면 좋게 때문에 </body>바로 전에 위치하면 좋음


## Todo 페이지
### microsoft에서 기본으로 제공하는 Todo sample에 몇가지 기능 추가
	- 삭제기능 
	- js 함수 호출
	- 값 유지
	- re-render
	- js를 이용한 autofocus (js없이 처리하는 방법을 모르겠음 ㅠ)
	- 참고 : https://docs.microsoft.com/ko-kr/aspnet/core/tutorials/build-a-blazor-app?view=aspnetcore-3.1


## RequestData 페이지
### api 호출 기능
    - CORS(Cross Origin Resource Sharing)
    - api 호출 결과 Dictionary에 저장
    - Dictionary값 (루프 돌면서) 화면에 표시
    - 참고 : https://docs.microsoft.com/ko-kr/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1


## InfiniteScroll 페이지
### 무한 스크롤
	- 페이지번호 클릭하는것이 아닌 무한 스크롤
	- js에서 blazor 메소드 호출하는 방법
	- blazor에서 js호출하는 방법
	- js에서 무한 스크롤 처리하는 방법
	- 참고 : https://dev.to/sakun/a-super-simple-implementation-of-infinite-scrolling-3pnd
	- 참고 : https://github.com/wisne/InfiniteScroll-BlazorServer


## Swiper 페이지
### 좌/우 스와이프
	- rest api를 통한 데이터 조회 (참고:https://docs.microsoft.com/ko-kr/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1)
	- 조회된 데이터를 Dictionary로 변환
	- 데이터 직렬화(객체=>json)(참고:https://docs.microsoft.com/ko-kr/dotnet/standard/serialization/system-text-json-how-to)
	- js swiper 라이브러리 사용(참고:https://github.com/nolimits4web/Swiper/blob/master/demos/290-dynamic-slides.html)
	- 동적으로 swipe 아이템 추가(전,후)	
	- .NET에서 js로 json 문자열 전달


## travel cube 페이지
### 큐브(글) 조회
	- 전후좌우 이동 가능
	- 모달창 실행
	- partial class
	- component 생성&사용


IndexedDB 사용 : https://blog.stevensanderson.com/2019/08/03/blazor-indexeddb/

__author : HyunSeongKil__
