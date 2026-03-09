using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    public class Settings
{
    public int scale = 4;

    public static Settings Instance { get; private set; } = new Settings();
}
