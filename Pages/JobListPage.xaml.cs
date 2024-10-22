using MauiOnyx.Models;
using MauiOnyx.ViewModels;
using System.Web;

namespace MauiOnyx.Pages;

[QueryProperty(nameof(Id), "")]
public partial class JobListPage : ContentPage
{
    public string Id { get; set; }
    public List<Jobs> JobList{ get; set; }
    private readonly JobListViewModel _viewModel;

    public JobListPage(JobListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

}