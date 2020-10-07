using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    public class Article
    {

        /// <summary>
        /// 제목
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]
        public string Sj { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        [System.ComponentModel.DataAnnotations.Required]        
        public string Cn { get; set; }
        
        /// <summary>
        /// 태그
        /// </summary>
        public string Tag { get; set; }
        
        /// <summary>
        /// 카테고리 코드
        /// </summary>
        public string CategoryCode { get; set; }

    }
}
