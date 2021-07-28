using MyLibrary.EventSystem;

namespace MyLibrary.EnergySystem.Interfaces
{
    public interface IEnergyUpdatedHandler : IGlobalSubscriber
    {
        void OnEnergyUpdated();
    }
}