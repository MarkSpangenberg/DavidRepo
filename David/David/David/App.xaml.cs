using System;
using David.Services;
using David.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace David {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            ApplicationRepository applicationrep = new ApplicationRepository();

            MainPage = new NavigationPage(new HomeTabbedPage()) {
                BarBackgroundColor = Color.LightGray,
                BarTextColor = Color.Black
            };
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
