using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TrinusTest.Views;

namespace TrinusTest.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ObservableCollection<PersonViewModel> Users { get; set; } = new ObservableCollection<PersonViewModel>();
        public ICommand RegisterCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private PersonViewModel _currentUser;
        public PersonViewModel CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }

        public void Register()
        {
            if (CurrentUser.HasErrors)
            {
                foreach(string message in CurrentUser.ValidationErrors.Values)
                {
                    MessageBox.Show(message);
                }
                return;
            }
            if (CurrentUser.IsNewEntry)
            {
                Users.Add(CurrentUser);
                CurrentUser.IsNewEntry = false;
                CurrentUser = new PersonViewModel();
            }
            else if (CurrentUser.IsEditing)
            {
                CurrentUser.IsEditing = false;
                CurrentUser = new PersonViewModel();
            }
            
        }

        public void Edit(PersonViewModel person)
        {
            CurrentUser = person;
            CurrentUser.IsEditing = true;
        }

        public void Delete(PersonViewModel person)
        {
            Users.Remove(person);
        }

        public MainViewModel()
        {
            CurrentUser = new PersonViewModel();
            RegisterCommand = new RelayCommand(Register);
            EditCommand = new RelayCommand<PersonViewModel>(Edit);
            DeleteCommand = new RelayCommand<PersonViewModel>(Delete);
            Users.Add(new PersonViewModel { Name = "Kelvin", Age = 18, Ssn = "10", IsNewEntry = false });
        }

    }
}
