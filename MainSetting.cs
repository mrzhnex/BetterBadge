﻿using EXILED;

namespace BetterBadge
{
    public class MainSetting : Plugin
    {
        public override string getName => "BetterBadge";
        private SetEvent SetEvent;
        public override void OnEnable()
        {
            SetEvent = new SetEvent();
            Events.SetGroupEvent += SetEvent.OnSetGroup;
            Events.WaitingForPlayersEvent += SetEvent.OnWaitingForPlayers;
            Events.PlayerJoinEvent += SetEvent.OnPlayerJoin;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.SetGroupEvent -= SetEvent.OnSetGroup;
            Events.WaitingForPlayersEvent -= SetEvent.OnWaitingForPlayers;
            Events.PlayerJoinEvent -= SetEvent.OnPlayerJoin;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
    }
}