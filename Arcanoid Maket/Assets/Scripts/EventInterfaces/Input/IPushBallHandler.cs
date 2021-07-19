using Scripts.Utils.EventSystem;

namespace EventInterfaces.Input
{
    public interface IPushBallHandler : IGlobalSubscriber
    {
        void OnPush();
    }
}