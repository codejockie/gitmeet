using System;
using System.ComponentModel;
using GitMeet.Models;
using GitMeet.Views;
using Xamarin.Forms;

namespace GitMeet
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            activityIndicator.IsVisible = true;
            activityIndicator.IsRunning = true;
            searchBtn.IsEnabled = false;

            var location = locEntry.Text.Trim();
            var language = langEntry.Text.Trim();

            try
            {
                listView.ItemsSource = await App.UserManager.GetUsersAsync(location, language);

                activityIndicator.IsRunning = false;
                activityIndicator.IsVisible = false;
                searchBtn.IsEnabled = true;
            }
            catch (Exception exc)
            {
                await DisplayAlert("An Error Occured", $"{exc.Message}", "Ok");
            }
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
                User user = args.SelectedItem as User;
                DetailsPage detailsPage = new DetailsPage();

                try
                {
                    detailsPage.BindingContext = await App.UserManager.GetUserAsync(user.Login);
                }
                catch (Exception exc)
                {
                    await DisplayAlert("An Error Occured", $"{exc.Message}", "Ok");
                }

                await Navigation.PushAsync(detailsPage);
            }
        }
    }
}
