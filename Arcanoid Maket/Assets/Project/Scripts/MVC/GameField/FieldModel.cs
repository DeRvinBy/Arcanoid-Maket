using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.MVC.GameField.Data;

namespace Project.Scripts.MVC.GameField
{
    public class FieldModel
    {
        public FieldGrid Grid { get; private set; }

        public void Initialize(FieldSettings fieldSettings)
        {
            Grid = new FieldGrid(fieldSettings);
        }

        public void StartModel()
        {
            Grid.CreateGameField(5,4);
        }

        
    }
}