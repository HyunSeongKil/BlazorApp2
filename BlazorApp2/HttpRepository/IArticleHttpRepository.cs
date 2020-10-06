using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.HttpRepository
{
    public interface IArticleHttpRepository
    {
        Task CreateArticle();
    }
}
