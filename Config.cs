using Exiled.API.Interfaces;

namespace BetterBadge
{
    public class Config : IConfig
    {
        bool IConfig.IsEnabled { get; set; } = true;
    }
}