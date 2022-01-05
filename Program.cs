using System;
using System.IO;
using homework07.collection;
using homework07.tools;

using System.Collections.Generic;

namespace homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWorker fileWorker = new FileWorker("Notes.cvs");
            List<Note> newCollection = new List<Note>();
            newCollection = fileWorker.ReadFile();
            Command command = new Command(newCollection);
            CommandHandler commandHandler = new CommandHandler(command);
            commandHandler.Work();
        }
    }
}
