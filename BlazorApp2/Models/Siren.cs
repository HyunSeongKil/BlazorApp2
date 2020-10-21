using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    /// <summary>
    /// 신고
    /// </summary>
    public class Siren
    {
        public string SirenId { get; set; }
        public string CubeId { get; set; }
        public string ReasonCode { get; set; }
        public string Cn { get; set; }
        /// <summary>
        /// 상태코드
        /// </summary>        
        public string SttusCode { get; set; }
    }
}
