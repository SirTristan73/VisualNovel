using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace EventBus
{
    public class ButtonBehavior : MonoBehaviour
    {
        [SerializeField] private string _eventIndex;
        public Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }


        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }


        private void OnButtonClicked()
        {
            ButtonOnCLickEvent data = new ButtonOnCLickEvent(_eventIndex, 100f);
            EventBus.Trigger(data);
        }

    }
}
