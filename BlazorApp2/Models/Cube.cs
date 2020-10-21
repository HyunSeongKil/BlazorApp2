using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    public class Cube
    {
        public string CubeId { get; set; }
        public string Sj { get; set; }
        public string Cn { get; set; }
        public string CtgryCode { get; set; }
        public string CtgryCodeNm { get; set; }
        public int LikeCo { get; set; }
        public int UnlikeCo { get; set; }
        public int CommentCo { get; set; }
        public int Rdcnt { get; set; }
        public string ParentCubeId { get; set; }
        public string RegisterId { get; set; }
        public string RegisterNm { get; set; }
        public DateTime RegistDt { get; set; }

        public string _tag { get; set; }

        public IList<Tag> Tags { get; set; }

        public Cube Clone()
        {
            return new Cube()
            {
                CubeId = this.CubeId,
                Sj = this.Sj,
                Cn = this.Cn,
                LikeCo = this.LikeCo,
                UnlikeCo = this.UnlikeCo,
                CommentCo = this.CommentCo,
                Rdcnt = this.Rdcnt,
                RegistDt = this.RegistDt,
                RegisterId = this.RegisterId,
                RegisterNm = this.RegisterNm
            };
        }
    }
}
