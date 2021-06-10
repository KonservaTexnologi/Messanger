using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Messanger
{
    class ModelVk : INotifyPropertyChanged
    {
        private string token;
        private string status;

        public ModelVk()
        {
        }

        // value - значение, которое передаст нам пользователь && get - получает, set - устонавливает
        public string Token
        {
            get => token;
            set
            {
                if (token != value)
                {
                    token = value;
                    OnPropertyChanged("Token");
                }
            }
        }

        public string Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }


        // Главное не удалять
        public event PropertyChangedEventHandler PropertyChanged; //Событие, которое будет вызвано при изменении модели 
        public void OnPropertyChanged([CallerMemberName]string prop = "") //Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}