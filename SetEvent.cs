using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BetterBadge
{
    public class SetEvent
    {
        internal void OnChangingGroup(ChangingGroupEventArgs ev)
        {
            if (Global.PluginEnable && !Global.PlayersWithCustomBadge.Contains(ev.Player.Id))
            {
                foreach (string cb in Global.CustomBadges)
                {
                    string[] args = cb.Split(Global.SplitSymbol);
                    if (args.Length != 3)
                        continue;
                    if (ev.Player.UserId.Replace("@steam", string.Empty) == args[0])
                    {
                        Global.PlayersWithCustomBadge.Add(ev.Player.Id);
                        ev.Player.GameObject.AddComponent<CustomBadgeComponent>();
                        ev.Player.GameObject.GetComponent<CustomBadgeComponent>().Text = args[1];
                        ev.Player.GameObject.GetComponent<CustomBadgeComponent>().Color = args[2];
                    }
                }
            }
        }

        internal void OnJoined(JoinedEventArgs ev)
        {
            if (Global.PluginEnable && !Global.PlayersWithCustomBadge.Contains(ev.Player.Id))
            {
                foreach (string cb in Global.CustomBadges)
                {
                    string[] args = cb.Split(Global.SplitSymbol);
                    if (args.Length != 3)
                        continue;
                    if (ev.Player.UserId.Replace("@steam", string.Empty) == args[0])
                    {
                        Global.PlayersWithCustomBadge.Add(ev.Player.Id);
                        ev.Player.GameObject.AddComponent<CustomBadgeComponent>();
                        ev.Player.GameObject.GetComponent<CustomBadgeComponent>().Text = args[1];
                        ev.Player.GameObject.GetComponent<CustomBadgeComponent>().Color = args[2];
                        ev.Player.GameObject.GetComponent<CustomBadgeComponent>().Timer = -1;
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