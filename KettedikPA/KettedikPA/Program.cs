using System;

namespace KettedikPA
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fm = new FileManager();
            UI ui = new UI();
            ui.StartModule();
            //fm.LoadFromXML();
            //fm.Save();                    
        }
    }
}
