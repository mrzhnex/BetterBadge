using EXILED;
using EXILED.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BetterBadge
{
    public class SetEvent
    {
        public void OnSetGroup(SetGroupEvent ev)
        {
            if (Global.PluginEnable && !Global.PlayersWithCustomBadge.Contains(ev.Player.GetPlayerId()))
            {
                foreach (string cb in Global.CustomBadges)
                {
                    string[] args = cb.Split(Global.SplitSymbol);
                    if (args.Length != 3)
                        continue;
                    if (ev.Player.GetUserId().Replace("@steam", string.Empty) == args[0])
                    {
                        Global.PlayersWithCustomBadge.Add(ev.Player.GetPlayerId());
                        ev.Player.gameObject.AddComponent<CustomBadgeComponent>();
                        ev.Player.gameObject.GetComponent<CustomBadgeComponent>().Text = args[1];
                        ev.Player.gameObject.GetComponent<CustomBadgeComponent>().Color = args[2];
                    }
                }
            }
        }

        internal void OnPlayerJoin(PlayerJoinEvent ev)
        {
            if (Global.PluginEnable && !Global.PlayersWithCustomBadge.Contains(ev.Player.GetPlayerId()))
            {
                foreach (string cb in Global.CustomBadges)
                {
                    string[] args = cb.Split(Global.SplitSymbol);
                    if (args.Length != 3)
                        continue;
                    if (ev.Player.GetUserId().Replace("@steam", string.Empty) == args[0])
                    {
                        Global.PlayersWithCustomBadge.Add(ev.Player.GetPlayerId());
                        ev.Player.gameObject.AddComponent<CustomBadgeComponent>();
                        ev.Player.gameObject.GetComponent<CustomBadgeComponent>().Text = args[1];
                        ev.Player.gameObject.GetComponent<CustomBadgeComponent>().Color = args[2];
                        ev.Player.gameObject.GetComponent<CustomBadgeComponent>().Timer = -1;
                    }
                }
            }
        }

        public void OnWaitingForPlayers()
        {
            try
            {
                Global.PlayersWithCustomBadge = new System.Collections.Generic.List<int>();
                Global.CustomBadges = File.ReadAllLines(Path.Combine(Global.CustomBadgesFilePath, Global.CustomBadgesFileName), Encoding.UTF8).ToList();
                Global.PluginEnable = true;
            }
            catch (Exception)
            {
                Global.PluginEnable = false;
                Log.Info("Error loading badges. Plugin was disabled");
            }
        }
    }
}