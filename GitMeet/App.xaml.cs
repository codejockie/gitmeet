using System.Net.Http;
using GitMeet.Data;
using Xamarin.Forms;

namespace GitMeet
{
    public partial class App : Application
    {
        public static UsersManager UserManager { get; set; }

        public App()
        {
            InitializeComponent();

            var httpClient = new HttpClient();
            UserManager = new UsersManager(new RestService(httpClient));

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.Accent,
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
