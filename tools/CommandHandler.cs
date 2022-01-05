using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework07.tools
{
    class CommandHandler
    {
        private Command _command;
        private bool _flag = true;

        public CommandHandler(Command command)
        {
            _command = command;
        }

        public void Work()
        {
            Console.WriteLine("Введите команду. Для получения списка всех возможных команд введите help");
            while (_flag)
            {
                string command = Console.ReadLine().ToLower().Trim();
                switch (command)
                {
                    case "help":
                        _command.Help();
                        break;
                    case "show":
                        _command.Show();
                        break;
                    case "add":
                        _command.Add();
                        break;
                    case "edit":
                        _command.Edit();
                        break;
                    case "delete":
                        _command.Delete();
                        break;
                    case "load":
                        _command.LoadFromFile();
                        break;
                    case "save_to_file":
                        _command.SaveToFile();
                        break;
                    case "add_from_file":
                        _command.AddFromFile();
                        break;
                    case "save":
                        _command.Save();
                        break;
                    case "swow_by_date":
                        _command.ShowByDate();
                        break;
                    case "sort":
                        _command.Sort();
                        break;
                    case "exit":
                        _flag = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует, для вывода всех возможных команд введите help");
                        break;

                }
            }

        }
    }
}
