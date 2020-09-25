# Blazor WebAssembly

## 공통
	- js는 정적페이지(html)에 위치해야 함
		- razor파일에 위치하면 안됨
		- razor파일에 <script>존재하면 visual studio가 자동으로 warning메시지 표시함


## Todo 페이지
### microsoft에서 기본으로 제공하는 Todo sample에 몇가지 기능 추가
	- 참고 : https://docs.microsoft.com/ko-kr/aspnet/core/tutorials/build-a-blazor-app?view=aspnetcore-3.1
	- 삭제기능 
	- js 함수 호출
	- 값 유지
	- re-render
	- js를 이용한 autofocus (js없이 처리하는 방법을 모르겠음 ㅠ)

## RequestData 페이지
### api 호출 기능
    - 참고 : https://docs.microsoft.com/ko-kr/aspnet/core/blazor/call-web-api?view=aspnetcore-3.1
    - CORS(Cross Origin Resource Sharing)
    - api 호출 결과 Dictionary에 저장
    - Dictionary값 (루프 돌면서) 화면에 표시


__author : HyunSeongKil__
