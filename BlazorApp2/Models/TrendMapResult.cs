using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorApp2
{
    /// <summary>
    /// 트렌드맵 호출 결과
    /// </summary>
    [DataContract]
    class TrendMapResult
    {
        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public int Frequency { get; set; }

        [DataMember]
        public string CategorySetName { get; set; }

        [DataMember]
        public IList<string> CategoryList { get; set; }

        [DataMember]
        public IList<TrendMapResultChild> ChildList { get; set; }

        public override string ToString()
        {
            PropertyInfo[] pis = this.GetType().GetProperties();
            PropertyInfo pi;
            string s = "";
            for(int i=0; i< pis.Length; i++)
            {
                pi = pis[i];

                s += " " + pi.Name + ":" + pi.GetValue(this);
            }

            return s;
        }
    }
}
