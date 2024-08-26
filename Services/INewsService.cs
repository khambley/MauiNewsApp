using System;
using MauiNewsApp.Models;

namespace MauiNewsApp.Services
{
	public interface INewsService
	{
        public Task<NewsResult> GetNews(NewsScope scope);
    }
}

