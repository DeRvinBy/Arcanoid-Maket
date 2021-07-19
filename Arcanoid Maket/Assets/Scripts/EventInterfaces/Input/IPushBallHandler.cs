using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.Input
{
    public interface IPushBallHandler : IGlobalSubscriber
    {
        void OnPush();
    }
}