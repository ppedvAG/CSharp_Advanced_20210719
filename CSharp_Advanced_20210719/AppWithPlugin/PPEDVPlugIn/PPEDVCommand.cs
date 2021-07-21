using System;
using PluginBase;

namespace PPEDVPlugIn
{
    public class PPEDVCommand : ICommand
    {
        public string Name => "PPEDV Command";

        public string Description => "Mit einem Befehl alle Powershell Probleme lösen";

        public int Execute()
        {
            Console.WriteLine("schon fertig :-) ");

            return 0;
        }
    }
}
