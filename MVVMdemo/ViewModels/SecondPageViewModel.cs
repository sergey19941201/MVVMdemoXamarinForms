using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVMdemo.Models;
using MVVMdemo.Services;
using Xamarin.Forms;

namespace MVVMdemo.ViewModels
{
    public class SecondPageViewModel : INotifyPropertyChanged
    {
        //!!!!!!!!!!!!!!!!!ALL IMPORTANT COMMENTS ARE IN SecondPageViewModel and in SecondPage view

        public ICommand BackCommand { protected set; get; }
        public ICommand AddCommand { protected set; get; }
        //Navigation parameter to prevent crash in here "await Navigation.PopAsync();"
        INavigation Navigation;

        //we use ObservableCollection because PropertyChanged works normally with it. List doesn`t do it 
        public ObservableCollection<Employee> _employeesList { get; set; }
        public ObservableCollection<Employee> EmployeesList
        {
            get { return _employeesList; }
            set 
            { 
                _employeesList = value; 
                OnPropertyChanged("EmployeesList");
            }
        }

        //this property will change when nameEntry.Text in the View is changed
        public string _nameEntry;
        public string NameEntry
        {
            get { return _nameEntry; }
            set 
            {
                _nameEntry = value;
                OnPropertyChanged("NameEntry");
            }
        }
        //this property will change when departmentEntry.Text in the View is changed
        public string _departmentEntry;
        public string DepartmentEntry
        {
            get { return _departmentEntry; }
            set
            {
                _departmentEntry = value;
                OnPropertyChanged("DepartmentEntry");
            }
        }

        //Constructor gets navigation parameter to prevent crash in here "await Navigation.PopAsync();"
        public SecondPageViewModel(INavigation inav)
        {
            EmployeesList = new EmployeesServices().GetEmployees();
            Navigation = inav;
            BackCommand = new Command(Back);
            AddCommand = new Command(Add);
        }

        private async void Back()
        {
            await Navigation.PopAsync();
        }

        private void Add()
        {
            EmployeesList.Add(new Employee{ Name = NameEntry, Department = DepartmentEntry });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
