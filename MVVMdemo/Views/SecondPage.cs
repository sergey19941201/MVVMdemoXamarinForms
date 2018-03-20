using System;

using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using MVVMdemo.ViewModels;
namespace MVVMdemo.Views
{
    public class SecondPage : ContentPage
    {
        SecondPageViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = new SecondPageViewModel(Navigation)); }
        }
        SecondPageViewModel _viewModel;
        public SecondPage()
        {
            //setting bindingContext
            BindingContext = ViewModel;

            var backButton = new Button(){Text = "Back", TextColor = Color.GreenYellow, BackgroundColor = Color.Goldenrod};
            var nameEntry = new Entry() { Placeholder = "name", PlaceholderColor = Color.Gold };
            var departmentEntry = new Entry() { Placeholder = "department", PlaceholderColor=Color.ForestGreen };
            var addButton = new Button() { Text = "Добавить"};

            var employeesListView = new ListView()
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(() =>
                {
                    //binding to Name property (MVVMdemo.Models.Employee.Name)
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.Margin=new Thickness(10, 0, 0, 0);
                    nameLabel.TextColor = Color.Silver;
                    nameLabel.BackgroundColor = Color.Sienna;

                    //binding to Department property (MVVMdemo.Models.Employee.Department)
                    Label departmentLabel = new Label();
                    departmentLabel.SetBinding(Label.TextProperty, "Department");

                    //we need custom viewCell to have a list with two labels in each item 
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children = { nameLabel, departmentLabel }
                        }
                    };
                })
            };
            var myStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
            };

            //adding children to stacklayout
            myStack.Children.Add(nameEntry);
            myStack.Children.Add(departmentEntry);
            myStack.Children.Add(addButton);
            myStack.Children.Add(backButton);
            myStack.Children.Add(employeesListView);
            //adding children to stacklayout ENDED

            //setting bindings (when text in entry changes, it cause automatic change property in viewModel)
            nameEntry.SetBinding(Entry.TextProperty, "NameEntry");
            departmentEntry.SetBinding(Entry.TextProperty, "DepartmentEntry");
            employeesListView.SetBinding(ListView.ItemsSourceProperty, "EmployeesList");
            //setting bindings (when text in entry changes, it cause automatic change property in viewModel) ENDED

            //assigning viewModel commands to buttons
            backButton.Command = ViewModel.BackCommand;
            addButton.Command = ViewModel.AddCommand;
            //assigning viewModel commands to buttons ENDED

            Content = myStack;
        }
    }
}
