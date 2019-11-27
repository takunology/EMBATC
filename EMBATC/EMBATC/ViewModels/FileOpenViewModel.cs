using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMBATC.ViewModels
{
    class FileOpenViewModel : INotifyPropertyChanged
    {
        Models.ConvertModel convertModel = new Models.ConvertModel();

        private string _FilePath = "";
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                _FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public void OpenFile()
        {
            convertModel.FileOpen();
        }

        public event PropertyChangedEventHandler PropertyChanged; //変更通知
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }     
        
    }
}
