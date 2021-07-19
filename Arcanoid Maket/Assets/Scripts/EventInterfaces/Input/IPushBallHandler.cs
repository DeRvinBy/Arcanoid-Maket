using Library.EventSystem;

namespace EventInterfaces.Input
{
    public interface IPushBallHandler : IGlobalSubscriber
    {
        void OnPush();
    }
}