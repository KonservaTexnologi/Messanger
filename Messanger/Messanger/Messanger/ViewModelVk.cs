using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using VkNet.Model.RequestParams;
using System.Collections.ObjectModel;
using System.Linq;
using VkNet.Enums.Filters;

namespace Messanger
{
    class ViewModelVk : INotifyPropertyChanged
    {
        private string accauntName { get; set; }
        public ICommand auth { get; }
        public ModelVk ModelVk { get; set; }
        VkApi api = new VkApi();

        public ViewModelVk()
        {
            ModelVk = new ModelVk();
            auth = new Command(Auth);
        }


        // Авторизация ВКонтакте
        public void Auth()
        {
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 7801128,
                Login = Login,
                Password = Password,
                Settings = Settings.All
            });

        }

        // получение Логина
        public string Login
        {
            get { return ModelVk.Login; }
            set
            {
                if (ModelVk.Login != value)
                {
                    ModelVk.Login = value;
                    OnPropertyChanged("Login");
                }
            }
        }

        // получения Пароля
        public string Password
        {
            get { return ModelVk.Password; }
            set
            {
                if (ModelVk.Password != value)
                {
                    ModelVk.Password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        // Получение имени аккаунта ВКонтакте
        public string AccauntName
        {
            get { return accauntName; }
            set
            {
                var p = api.Users.Get(new long[] { 1 }).FirstOrDefault();
                accauntName = p.FirstName;
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
