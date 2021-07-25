using UnityEngine;

namespace MyLibrary.UI.Popup.Components
{
    public class PopupsLocker : MonoBehaviour
    {
        [SerializeField]
        private Transform _lockerTransform;

        public void EnableLocker()
        {
            gameObject.SetActive(true);
        }

        public void MoveOnAllPopups()
        {
            _lockerTransform.SetAsLastSibling();
        }
        
        public void MoveUpLocker(Transform popup)
        {
            var index = popup.transform.GetSiblingIndex();
            _lockerTransform.SetSiblingIndex(++index);
        }
        
        public void MoveDownLocker(Transform popup)
        {
            var index = popup.transform.GetSiblingIndex();
            if (index <= 0)
            {
                index = 1;
            }
            _lockerTransform.SetSiblingIndex(--index);
        }

        public void DisableLocker()
        {
            gameObject.SetActive(false);
        }
    }
}