/**
 *  네트워크 그래프
 *  @since 20201015 init
 * */
let NetworkGraphObj = function () {
    this.callCo = -1;
    this.callResults = [];

    this.networkObj = null;
};


NetworkGraphObj.prototype.init = function () {
    console.log(this, '<<.init');
};


/**
 * @param {string} jsonString
 */
NetworkGraphObj.prototype.createVisNetwork = function (jsonString) {
    let tags = JSON.parse(jsonString);
    this.callCo = tags.length;
    this.callResults = [];

    if (0 == tags.length) {
        this.networkObj?.destroy();
    }

    for (let i = 0; i < tags.length; i++) {
        let d = tags[i];

        this.callTrendMapResult(d.nm);
    }

};


/**
 * trendmap 호출. jsonp로 호출해야 함. http, https 혼합되어 있으면 안됨
 * @param {any} keyword
 */
NetworkGraphObj.prototype.callTrendMapResult = function (keyword) {

    //TODO class로 추출하기
    let param = {};
    param.lang = 'ko';
    param.source = 'blog';
    param.startDate = moment().add(-30, 'days').format('yyyyMMDD');
    param.endDate = moment().format('yyyyMMDD');
    param.topN = Pp.random(10, 20);
    param.cutOffFrequencyMin = 0;
    param.cutOffFrequencyMax = 0;
    param.outputOption = 'freq';
    param.categorySetName = 'SM';
    param.command = 'GetKeywordAssociation';
    param.keyword = keyword;


    $.ajax({
        url: 'http://qt.some.co.kr/TrendMap/JSON/ServiceHandler',
        dataType: 'jsonp',
        data: param,
        method: 'get',
        jsonpCallback: 'networkGraphObj.jsonpCallback',
        success: function (res) {
            console.log('success', res);
        },
        error: function (res) {
            console.log('error', res);
        }
    });

};


/**
 * 호출결과 콜백
 * @param {object} res
 */
NetworkGraphObj.prototype.jsonpCallback = function (res) {
    //console.log('jsonpcallback', res);


    this.callResults.push(res);


    //모든 호출 결과를 받았으면
    if (this.callCo === this.callResults.length) {
        //console.log('todo parsing');
        let nodes = this.createNodes();
        let edges = this.createEdges();

        //console.log(nodes, edges);

        let data = {
            nodes: new vis.DataSet(nodes),
            edges: new vis.DataSet(edges)
        };
        let options = {};


        //생성
        this.networkObj = new vis.Network(document.getElementById('mynetwork'), data, options);
    }

};


/**
 * edge 목록 생성
 * */
NetworkGraphObj.prototype.createEdges = function () {
    let edges = [];
    let id1 = 0, id2 = 0;

    if (Pp.isEmpty(this.callResults)) {
        return edges;
    }


    for (let i = 0; i < this.callResults.length; i++) {
        edges.push({ from: 0, to: id1+=100 });
    }

    id1 = 0;
    for (let i = 0; i < this.callResults.length; i++) {
        let result = this.callResults[i];
        if (Pp.isEmpty(result)) {
            continue;
        }

        id1 += 100;
        id2 = 1;


        for (let j = 0; j < result.childList.length; j++) {
            let child = result.childList[j];

            edges.push({ from: id1, to: id1 + id2++ });
        }
    }
    

    return edges;
};


/**
 * node 목록 생성
 * */
NetworkGraphObj.prototype.createNodes = function () {
    let nodes = [];
    let id1 = 0, id2 = 0;

    if (Pp.isEmpty(this.callResults)) {
        return nodes;
    }


    nodes.push({ id: id1, label: '나'});


    for (let i = 0; i < this.callResults.length; i++) {
        let result = this.callResults[i];
        if (Pp.isEmpty(result)) {
            continue;
        }

        id1 += 100;
        id2 = 0;

        nodes.push({id: id1 + id2++, label: result.label});

        for (let j = 0; j < result.childList.length; j++) {
            let child = result.childList[j];

            nodes.push({ id: id1 + id2++, label: child.label });
        }
    }

    return nodes;
}



//
const networkGraphObj = new NetworkGraphObj();
networkGraphObj.init();