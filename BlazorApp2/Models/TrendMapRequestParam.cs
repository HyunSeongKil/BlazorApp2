using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    public class TrendMapRequestParam
    {
        /// <summary>
        /// todo enum
        /// </summary>
        public string Lang { get; set; } = "ko";

        /// <summary>
        /// 문서 범위
        /// todo enum
        /// </summary>
        public string Source { get; set; } = "blog";
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Keyword { get; set; }
        public int TopN { get; set; } = 10;
        /// <summary>
        /// 유효 빈도 범위 min
        /// </summary>
        public int CutOffFrequencyMin { get; set; } = 0;

        /// <summary>
        /// 유효 빈도 범위 max
        /// </summary>
        public int CutOffFrequencyMax { get; set; } = 0;

        /// <summary>
        /// 정렬방식
        /// todo enum
        /// </summary>
        public string[] OutputOption { get; set; } = new string[] { "score" };

        /// <summary>
        /// 분류체계
        /// todo enum
        /// </summary>
        public string CategorySetName { get; set; } = "SM";

        /// <summary>
        /// todo enum
        /// </summary>
        public string Command { get; set; } = "GetKeywordAssociation";

        public string ToGetParamString()
        {
            string s = "?_=" + DateTime.Now.Ticks;

            s += "&lang=" + this.Lang;
            s += "&source=" + this.Source;
            s += "&startDate=" + this.StartDate.ToString("yyyyMMdd");
            s += "&endDate=" + this.EndDate.ToString("yyyyMMdd");
            if (!string.IsNullOrEmpty(this.Keyword))
            {
                s += "&keyword=" + this.Keyword;
            }
            s += "&topN=" + this.TopN;
            s += "&cutOffFrequencyMin=" + this.CutOffFrequencyMin;
            s += "&cutOffFrequencyMax=" + this.CutOffFrequencyMax;
            s += "&outputOption=" + this.OutputOption[0];
            s += "&categorySetName=" + this.CategorySetName;
            s += "&command=" + this.Command;

            return s;
        }
    }
}
