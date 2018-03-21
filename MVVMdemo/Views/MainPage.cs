using System;

using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMdemo.ViewModels;

namespace MVVMdemo.Views
{
    public class MainPage:ContentPage 
    {
        StackLayout _form;
        Button buttonToViewModel;

        MainViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = new MainViewModel(Navigation)); }
        }
        MainViewModel _viewModel;
        public MainPage()
        {
            //setting bindingContext
            BindingContext = ViewModel;

            var username = new Entry() { VerticalOptions = LayoutOptions.Start, Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence | KeyboardFlags.Spellcheck) };
            var myLabel = new Label() { VerticalOptions = LayoutOptions.Start, Text="LABEL", TextColor=Color.Red, BackgroundColor=Color.Green};

            buttonToViewModel = new Button
            {
                VerticalOptions = LayoutOptions.Start,
                Text = "Button to ViewModel",
                TextColor = Color.Red,
                BackgroundColor = Color.Green
            };

            var buttonToSecondPage = new Button() 
            {
                VerticalOptions = LayoutOptions.Start, 
                Text = "Button to second page",
                TextColor = Color.BlueViolet, 
                BackgroundColor = Color.Black 
            };

            _form = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Yellow,
                Children = { username, myLabel,buttonToViewModel,buttonToSecondPage }
            };

            //assigning viewModel commands to buttons
            buttonToViewModel.Command = ViewModel.ChangeText;
            buttonToSecondPage.Command = ViewModel.GoToSecondPage;
            //assigning viewModel commands to buttons ENDED

            //
            buttonToSecondPage.Clicked += (s, e) => ((Button)s).TextColor = Color.Bisque;
            

            //setting bindings
            buttonToViewModel.SetBinding(Button.TextProperty, "ButtonTextValue");
            myLabel.SetBinding(Label.TextProperty, "ButtonTextValue");
            //setting bindings ENDED

            Content = _form;
        }
    }
}