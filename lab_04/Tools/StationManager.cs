using lab_04.Models;
using System;
using System.IO;

namespace lab_04.Tools
{
    static class StationManager
    {
        internal static readonly string WorkingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "05Matsiuk");
        public static Person CurrentPerson { get; set; }
    }
}
