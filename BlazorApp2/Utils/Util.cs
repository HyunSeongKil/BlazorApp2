using BlazorApp2.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace BlazorApp2.Utils
{
    public class Util
    {
        static Random rnd = new Random();


        public static string CreateUid(string pre = "")
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano += 100L;

            return pre + nano;
        }


        public static string GetParameter(NavigationManager navManager, string key)
        {
            NameValueCollection nameValues = HttpUtility.ParseQueryString(new Uri(navManager.Uri).Query);

            if (nameValues.AllKeys.Contains(key))
            {
                return nameValues[key];
            }

            return null;
        }


        public static Cube CreateDummyCube()
        {
            IList<string> dummyCtgrys = new List<string>()
            {
                "음악",
                "미술",
                "체육",
                "문화",
                "세계"
            };

            IList<string> dummyTags = new List<string>()
            {
                "클래식",
                "락",
                "한국발라드",
                "서양미술",
                "동양미술",
                "육상",
                "여자배구",
                "세계사",
            };



            IList<Tag> tags = new List<Tag>();
            for (int i = 0, end = rnd.Next(5); i < end; i++)
            {
                tags.Add(new Tag()
                {
                    Nm = dummyTags[rnd.Next(dummyTags.Count)]
                });
            }

            Cube cube = new Cube()
            {
                CubeId = CreateUid("C"),
                Sj = "제목 " + rnd.Next(),
                Cn = "내용 내용\n 주절 주절\n " + rnd.Next(),
                CtgryCodeNm = dummyCtgrys[rnd.Next(5)],
                LikeCo = rnd.Next(100),
                UnlikeCo = rnd.Next(100),
                Rdcnt = rnd.Next(100),
                CommentCo = rnd.Next(100),
                Tags = tags,
                RegisterId = "gravity",
                RegisterNm = "그라비티",
                RegistDt = DateTime.Now
            };

            //System.Diagnostics.Debug.WriteLine($"i:{no} cube:{cube}");
            return cube;
        }



        /// <summary>
        /// @see https://blog.naver.com/PostView.nhn?blogId=jskimmail&logNo=221700687117&categoryNo=46&parentCategoryNo=0&viewDate=&currentPage=1&postListTopCurrentPage=1&from=search
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="toCamel">property를 camel형식으로 변환할지 여부. default=false</param>
        /// <returns></returns>
        public static string Serialize(object obj, bool toCamel=false)
        {
            //직렬화시 한글 안 깨지게 하기위해 option 사용
            string jsonString = System.Text.Json.JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNamingPolicy = (toCamel ? JsonNamingPolicy.CamelCase : null),
                WriteIndented = true
            });
            //System.Diagnostics.Debug.WriteLine(jsonString);

            return jsonString;
        }

        /// <summary>
        /// 랜덤값 리턴
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int RndValue(int maxValue=1000)
        {
            return new Random().Next(maxValue);
        }


        /// <summary>
        /// 랜덤한 bool값 구하기
        /// </summary>
        /// <returns></returns>
        public static bool RndBool()
        {
            int sec = DateTime.Now.Second;
            Console.WriteLine($"{sec} {0 == sec % 2}");
            return (0 == (sec % 2));
        }
    }
}
