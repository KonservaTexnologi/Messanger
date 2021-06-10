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
using VkNet.Enums.SafetyEnums;

namespace Messanger
{
    class ViewModelVk
    {
        // Создание модели
        public ModelVk ModelVk { get; set; }

        public ICommand auth { get; }
        public ICommand viewstatus { get; }
        VkApi api = new VkApi();

        public ViewModelVk()
        {
            // Создание экземпляра класса модели и команд
            ModelVk = new ModelVk();
            auth = new Command(Auth);
            viewstatus = new Command(ViewStatus);
        }

        // Токен - 761c422f5b5cfd9cb9b3fddc06a93271a6ff064eb342057659c6ede6fa4184f021ab773ada027eaa4f02e
        // Мой Id - 261009498


        // Получение токена для авторизации
        public void Auth()
        {
            // Получение токена для авторизации
            Device.OpenUri(new Uri("https://oauth.vk.com/authorize?client_id=7864647&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=status&response_type=token&v=5.131&state=123456"));
            // TODO: взять ссылку по которой вк перенапрвляет пользователя и изъять из неё токен и id пользователя и провести авторизацию

        }

        public void ViewStatus()
        {
            // пока авторизация проходит здесь. Токен вставялет пользователь в определённое поле
            api.Authorize(new ApiAuthParams {
                AccessToken = Token
            });

            // Получения стасуса пользователь по ID
            ModelVk.Status = api.Status.Get(261009498).Text;
            OnPropertyChanged("Status");
        }

        // Обработка токена
        public string Token
        {
            get { return ModelVk.Token; }
            set
            {
                if (ModelVk.Token != value)
                {
                    ModelVk.Token = value;
                    OnPropertyChanged("Token");
                }
            }
        }

        // Хз что тут должно быть
        public string Status
        {
            get { return ModelVk.Status; }
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
