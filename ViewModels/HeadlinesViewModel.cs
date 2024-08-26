using System;
using System.Threading.Tasks;
using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiNewsApp.Models;
using MauiNewsApp.Services;

namespace MauiNewsApp.ViewModels
{
	public partial class HeadlinesViewModel : BaseViewModel
	{
        private readonly INewsService newsService;

        [ObservableProperty]
        private NewsResult currentNews;

        public HeadlinesViewModel(INewsService newsService)
		{
			this.newsService = newsService;
		}

		public async Task Initialize(string scope) => await Initialize(scope.ToLower() switch
		{
            "local" => NewsScope.Local,
            "global" => NewsScope.Global,
            "headlines" => NewsScope.Headlines,
            _ => NewsScope.Headlines
        });

        public async Task Initialize(NewsScope scope)
        {
            CurrentNews = await newsService.GetNews(scope);
        }

        [RelayCommand]
        public void ItemSelected(object selectedItem)
        {
            var selectedArticle = selectedItem as Article;
            var url = HttpUtility.UrlEncode(selectedArticle.Url);
            // Placeholder for more code later on
        }
    }
}

