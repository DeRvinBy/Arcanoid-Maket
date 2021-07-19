using Scripts.Utils.EventSystem;

namespace EventInterfaces.FieldEvents
{
    public interface IFieldPropertiesHandler : IGlobalSubscriber
    {
        void OnFieldScreenHeightSetup(float height);
    }
}