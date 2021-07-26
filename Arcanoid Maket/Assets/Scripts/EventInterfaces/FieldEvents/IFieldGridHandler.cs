using GameComponents.Field;
using MyLibrary.EventSystem;

namespace EventInterfaces.FieldEvents
{
    public interface IFieldGridHandler : IGlobalSubscriber
    {
        void OnFieldGridCreated(FieldGrid fieldGrid);
    }
}