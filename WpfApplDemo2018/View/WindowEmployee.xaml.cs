using System.Windows;
using WpfApplDemo2018.ViewModel;

namespace WpfApplDemo2018.View
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        public WindowEmployee()
        {
            InitializeComponent();
            DataContext = new PersonViewModel(); 
        }
    }
}
