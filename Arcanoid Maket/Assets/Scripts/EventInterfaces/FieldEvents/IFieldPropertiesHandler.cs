using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.FieldEvents
{
    public interface IFieldPropertiesHandler : IGlobalSubscriber
    {
        void OnFieldScreenHeightSetup(float height);
    }
}