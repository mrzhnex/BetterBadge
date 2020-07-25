using Exiled.API.Features;

namespace BetterBadge
{
    public class MainSetting : Plugin<Config>
    {
        public override string Name => nameof(BetterBadge);
        public SetEvent SetEvent { get; set; }
        public override void OnEnabled()
        {
            SetEvent = new SetEvent();
            Exiled.Events.Handlers.Player.ChangingGroup += SetEvent.OnChangingGroup;
            Exiled.Events.Handlers.Server.WaitingForPlayers += SetEvent.OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Joined += SetEvent.OnJoined;
            Log.Info(Name + " on");
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingGroup -= SetEvent.OnChangingGroup;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= SetEvent.OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Joined -= SetEvent.OnJoined;
            Log.Info(Name + " off");
        }
    }
}