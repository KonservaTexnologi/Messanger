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
        private string login;
        private string password;

        public ModelVk()
        {
        }

        // value - значение, которое передаст нам пользователь && get - получает, set - устонавливает
        public string Login { get => login;
            set {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged("Login");
                }
            }
        }
        public string Password { get => password; set {
                if (password != value) 
                {
                    password = value;
                    OnPropertyChanged("Login");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged; //Событие, которое будет вызвано при изменении модели 
        public void OnPropertyChanged([CallerMemberName]string prop = "") //Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
