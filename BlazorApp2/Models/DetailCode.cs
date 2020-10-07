using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    /// <summary>
    /// 상세 코드
    /// </summary>
    public class DetailCode
    {
        /// <summary>
        /// 상세 코드 아이디
        /// </summary>
        public string DetailCodeId { get; set; }

        /// <summary>
        /// 상세 코드 명
        /// </summary>
        public string DetailCodeNm { get; set; }

        /// <summary>
        /// 그룹 코드 아이디
        /// </summary>
        public string GroupCodeId { get; set; }
    }
}
