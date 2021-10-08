using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrinusTest.ViewModels
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isNewEntry;
        public bool IsNewEntry
        {
            get => _isNewEntry;
            set => Set(ref _isNewEntry, value);
        }
        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set => Set(ref _isEditing, value);
        }

        public Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();

        protected virtual void OnValidation() { }

        /// <summary>
        /// Validates properties and checks for errors.
        /// </summary>
        /// <returns>True if errors are found.</returns>
        public bool HasErrors
        {
            get
            {
                ValidationErrors.Clear();
                OnValidation();
                //updates all properties on front-end.
                if (ValidationErrors.Count > 0)
                {
                    OnPropertyChanged(string.Empty);
                }
                return ValidationErrors.Count > 0;
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Set<T>(ref T storage, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
