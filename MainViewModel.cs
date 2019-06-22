using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;

namespace emoteTester
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<LineColor> Colors => new List<LineColor>
        {
            new LineColor() {
                Foreground = new SolidColorBrush(Color.FromRgb(255,255,255)),
                Background = new SolidColorBrush(Color.FromRgb(14,12,19))
            },
            new LineColor() {
                Foreground = new SolidColorBrush(Color.FromRgb(255,255,255)),
                Background = new SolidColorBrush(Color.FromRgb(32,28,43))
            },
            new LineColor() {
                Foreground = new SolidColorBrush(Color.FromRgb(0,0,0)),
                Background = new SolidColorBrush(Color.FromRgb(250,249,250))
            },
            new LineColor() {
                Foreground = new SolidColorBrush(Color.FromRgb(0,0,0)),
                Background = new SolidColorBrush(Color.FromRgb(239,238,241))
            },
        };

        // The private variable is needed to be able to set and check separatly
        private string _filePath;
        public string FilePath
        {
            // Shorthand to return _filePath
            get => _filePath;
            set
            {
                // We don't want to update the value if it is null
                if (!(value is null))
                {
                    // Update the value
                    _filePath = value;

                    /*
                    This tells the view that the property has updated and to look at the property

                    The ?. is the null coalescing operator. If the PropertyChanged handler is not set by
                    the view, it will be null. The coalescing will exit out early if it is null. It is the
                    equivalent of
                    if (PropertyChanged != null) {
                        PropertyChanged.Invoke()
                    }
                    https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
                    
                    nameof(FilePath) returns the variable name as a string "FilePath". nameof is to make refactoring easier, so
                    when you F2 and edit FilePath it will change all the code locations
                    */
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilePath)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileName)));
                }
            }
        }

        public string FileName => Path.GetFileName(_filePath);

        // Setting default value of property
        private string _name = "Meowth";
        public string Name
        {
            get => _name;
            set
            {
                if (!(value is null))
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        private string _message = "prepare for trouble!";
        public string Message
        {
            get => _message;
            set
            {
                if (!(value is null))
                {
                    _message = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
                }
            }
        }
    }
}
