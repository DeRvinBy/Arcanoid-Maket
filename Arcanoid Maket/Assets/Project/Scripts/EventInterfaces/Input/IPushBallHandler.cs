using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.Input
{
    public interface IPushBallHandler : IGlobalSubscriber
    {
        void OnPush();
    }
}