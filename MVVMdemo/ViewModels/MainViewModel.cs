using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVMdemo.Models;
using MVVMdemo.Services;
using MVVMdemo.Views;
using Xamarin.Forms;

namespace MVVMdemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //!!!!!!!!!!!!!!!!!ALL IMPORTANT COMMENTS ARE IN SecondPageViewModel and in SecondPage view

        public ICommand GoToSecondPage { protected set; get; }
        public ICommand ChangeText { protected set; get; }
        INavigation Navigation;
        //setting default value
        private string _buttonTextValue = "button to count";
        public string ButtonTextValue 
        { 
            get { return _buttonTextValue; }
            set 
            {
                _buttonTextValue = value;
                OnPropertyChanged("ButtonTextValue");
            } 
        }

        public MainViewModel(INavigation inav)
        {
            Navigation = inav;
            GoToSecondPage = new Command(GoToSecondPageMeth);
            ChangeText= new Command(ChangeTextMeth);
        }

        private async void GoToSecondPageMeth()
        {
            await Navigation.PushAsync(new SecondPage());
        }

        //here we change the value of ButtonTextValue
        int i = 1;
        private void ChangeTextMeth()
        {
            ButtonTextValue = i.ToString();
            i++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
