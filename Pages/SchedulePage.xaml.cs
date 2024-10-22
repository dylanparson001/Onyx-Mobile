using MauiOnyx.ViewModels;

namespace MauiOnyx.Pages;

public partial class SchedulePage : ContentPage
{
    private readonly ScheduleViewModel _viewModel;

    public SchedulePage(ScheduleViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }
    protected override async void OnAppearing()
    {
        await (BindingContext as ScheduleViewModel)?.GetFieldStaff();
    }
}