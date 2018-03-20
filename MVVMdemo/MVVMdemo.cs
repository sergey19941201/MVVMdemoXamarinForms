using System;

using Xamarin.Forms;

namespace MVVMdemo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            /*var content = new ContentPage
            {
                Title = "MVVMdemo____",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms____!"
                        }
                    }
                }
            };*/

            MainPage = new NavigationPage(new Views.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
