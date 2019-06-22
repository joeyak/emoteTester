using System.Windows;
using Forms = System.Windows.Forms;

namespace emoteTester
{
    public partial class MainWindow : Window
    {
        private MainViewModel _model;

        public MainWindow()
        {
            _model = new MainViewModel();

            InitializeComponent();

            // Set the DataContext to the _model so updates are caught
            DataContext = _model;

            // Event Handler being set to a function
            // I like to use this instead of in the XAML because I don't need
            // to handle the parameters in the called method when it doesn't use them
            LoadFromFileButton.Click += (o, e) => LoadButton();
        }

        private void LoadButton()
        {
            var fileDialog = new Forms.OpenFileDialog();

            if (fileDialog.ShowDialog() == Forms.DialogResult.OK)
            {
                _model.FilePath = fileDialog.FileName;
            }
        }
    }
}
