using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    public class Comment
    {
        public string CommentId { get; set; }
        public string CubeId { get; set; }
        public string UserId { get; set; }
        public string UserNm { get; set; }
        public string Cn { get; set; }
        public DateTime RegistDt { get; set; }
    }
}
