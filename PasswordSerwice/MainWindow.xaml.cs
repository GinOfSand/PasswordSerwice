using System;
using System.Collections.Generic;
using System.Data.Entity;
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

//Задание
//Необходимо разработать приложение, которое позволяет хранить логины и пароли, на случай забывания пользователем.
//Приложение должно позволять:
//Хранить логины и пароли пользователя от разных сервисов
//Сервисы могут иметь несколько пар логинов/паролей
//Регистрировать новых пользователей. У каждого пользователя свои данные для входа и набор данных в базе. Пользователь должен иметь возможность менять свой пароль
//CRUD для логинов/паролей пользователя
//superuser, способный удалять и редактировать пользователей (запретить удаление superuser-а)
//Так же необходимо сделать встроенную утилиту для генерации паролей по параметрам, хранящимся в базе. Изменение этих параметров.
//Схема БД:
//User: id, login, password(в захэшированном виде)
//пользователь с логином superuser автоматически считается суперпользователем
//допустимо наличие не более чем одного superuser-а
//для superuser-а добавляется возможность удалять других пользователей, кроме себе
//superuser-а нельзя удалить
//Service: id, name(string), description(string)
//Credential: id, login, password(незахэшированный, это хранимый пользователем пароль), user_id, service_id
//Этапы разработки:
//Создать проект WPF, настроить для него EntityFramework + MS SQL Server (https://metanit.com/sharp/wpf/19.3.php)
//Создать уровень модели, содержащий сущности таблиц и класс ApplicationDbContext : DbContext
//Создать логику регистрации, аутентификации пользователей. Учесть ограничения superuser, а так же добавить фичу смены пароля пользователем
//Реализовать CRUD-операции для сервисов и паролей для пользователя. Использовать списочные элементы либо DataGrid.
//Реализовать CRUD-операции по администрированию пользователей superuser-ом, но включать этот функционал только если пользователь зашел под суперюзером. 
//Протестировать программу, сдать.

//Примечание:
//Можно использовать либо EF (рекомендуется) либо нативную релаизацию ADO.NET (присоединенный или отсоединенный режим).

namespace PasswordSerwice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
