using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;
using App7.DB;
using App7.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpDbPath))]
namespace App7.UWP
{
    class UwpDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
        }
    }
}
