using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorApp2
{
    [DataContract]
    class TrendMapResultChild
    {
        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public string SearchKeyword { get; set; }

        [DataMember]
        public int Score { get; set; }

        [DataMember]
        public int Frequency { get; set; }

        [DataMember]
        public IList<string> CategoryList { get; set; }
    }
}
