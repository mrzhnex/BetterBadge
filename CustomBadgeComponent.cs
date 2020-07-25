using Exiled.API.Features;
using UnityEngine;

namespace BetterBadge
{
    public class CustomBadgeComponent : MonoBehaviour
    {
        public string Text = string.Empty;
        public string Color = string.Empty;
        public float Timer = 0.0f;
        public void Start()
        {
            gameObject.GetComponent<ServerRoles>().NetworkMyText = Text;
            gameObject.GetComponent<ServerRoles>().NetworkMyColor = Color;
            Log.Info("Set custom badge: " + Text + " with color: " + Color + " to: " + gameObject.GetComponent<NicknameSync>().Network_myNickSync);
        }

        public void Update()
        {
            Timer += Time.deltaTime;
            if (Timer > 0.0f)
                Destroy(gameObject.GetComponent<CustomBadgeComponent>());
        }
    }
}