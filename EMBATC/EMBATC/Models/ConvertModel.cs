using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMBATC.Models
{
    public class ConvertModel
    {
        //ViewModels.FileOpenViewModel FileOpenViewModel;

        private string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged("PathChange");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void FileOpen()
        {
            var Dialog = new OpenFileDialog(); //ファイルオープンのインスタンス化
            Dialog.Filter = "pngファイル (*.png)|*.png|jpegファイル (*.jpg)|*.jpg|bmpファイル (*.bmp)|*.bmp";
            
            if (Dialog.ShowDialog() == true) 
            {
                _FilePath = (Dialog.FileName); 
            }
            else { return; }
        }
    }
}
