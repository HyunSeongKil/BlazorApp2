using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Models
{
    /// <summary>
    /// vis.js를 이용한 네트워크 그래프의 node 정보
    /// @see https://visjs.github.io/vis-network/examples/network/basicUsage.html
    /// </summary>
    class NetworkNode
    {
        public int Id { get; set; }

        public string Label { get; set; }
    }
}
