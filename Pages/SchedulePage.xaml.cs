using MauiOnyx.ViewModels;

namespace MauiOnyx.Pages;

public partial class SchedulePage : ContentPage
{
	public SchedulePage(ScheduleViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}