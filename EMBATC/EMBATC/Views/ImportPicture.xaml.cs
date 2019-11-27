using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EMBATC
{
    /// <summary>
    /// ImportPicture.xaml の相互作用ロジック
    /// </summary>
    public partial class ImportPicture : UserControl
    {
        public ImportPicture()
        {
            InitializeComponent();
            FileOpenViewModel = new ViewModels.FileOpenViewModel { FilePath = "" };
            this.DataContext = FileOpenViewModel;
        }

        private ViewModels.FileOpenViewModel FileOpenViewModel;

        private void Button_FileOpen(object sender, RoutedEventArgs e)
        {
            //FileOpenViewModel.FilePath = "こんな風に変わる";
            FileOpenViewModel.OpenFile();
        }
    }
}
