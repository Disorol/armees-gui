using Avalonia.Controls.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plc_soldier_avalonia.Models
{
    public class ApplicationLocalozation
    {
        /*
            0 - russian
            1 - english
        */
        public Dictionary<string, List<string>> TopMenu = new Dictionary<string, List<string>> 
        {
            {"File", new List<string>() { "Файл", "File" } },
            {"New Project", new List<string>() { "Новый проект", "New Project" } },
            {"Open Project", new List<string>() { "Открыть проект", "Open Project" } },
            {"Exit", new List<string>() { "Выход", "Exit" } },
            {"Edit", new List<string>() { "Редактировать", "Edit" } },
            {"View", new List<string>() { "Вид", "View" } },
            {"Logical Organizer", new List<string>() { "Логический органайзер", "Logical Organizer" } },
            {"Controller organizer", new List<string>() { "Контроллер-органайзер", "Controller organizer" } },
            {"Errors", new List<string>() { "Ошибки", "Errors" } },

            {"Search Results", new List<string>() { "Результаты поиска", "Search Results" } },
            {"Watch", new List<string>() { "Просмотр", "Watch" } },
            {"Central space", new List<string>() { "Центральная область", "Central space" } },
            {"Left bottom space", new List<string>() { "Левая нижняя область", "Left bottom space" } },
            {"Far Right space", new List<string>() { "Крайняя правая область", "Far Right space" } },
            {"Search", new List<string>() { "Вид", "Search" } },
        };
    }
}
