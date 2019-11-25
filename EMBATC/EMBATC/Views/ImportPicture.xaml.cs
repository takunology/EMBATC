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
        string Filepath;
        public ImportPicture()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog(); //ファイルオープンのインスタンス化

            dialog.Filter = "pngファイル (*.png)|*.png|jpegファイル (*.jpg)|*.jpg|bmpファイル (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == true)
            {
                Filepath = (dialog.FileName);
            }
            else
            {
                return;
            }

            content_path.Content = Filepath;
            picture.Source = new BitmapImage(new Uri(Filepath)); //UIに画像を表示
        }
    }
}
