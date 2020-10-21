using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Models
{
    public class CubeReact
    {
        public string CubeReactId { get; set; }
        public string CubeId { get; set; }
        public string UserId { get; set; }
        public string UserNm { get; set; }
        public bool Like { get; set; } = false;
        public bool Unlike { get; set; } = false;
        public DateTime RegistDt { get; set; }
    }
}
