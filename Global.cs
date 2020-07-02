using System.Collections.Generic;
using System.IO;

namespace BetterBadge
{
    public static class Global
    {
        public static List<string> CustomBadges = new List<string>();
        public static List<int> PlayersWithCustomBadge = new List<int>();

        public static string CustomBadgesFilePath = Path.Combine("/etc/PluginData/");

        public static string CustomBadgesFileName = "CustomBadges.txt";

        public static char SplitSymbol = ';';

        public static bool PluginEnable = true;
    }
}
