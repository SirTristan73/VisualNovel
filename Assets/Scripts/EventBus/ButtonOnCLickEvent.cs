using UnityEngine;

namespace EventBus
{
    public class ButtonOnCLickEvent : EventType
    {
        // public string _buttonAction { get; private set; }


        public ButtonOnCLickEvent(string action, float _cooldown = 0) : base(_cooldown)
        {
            // _buttonAction = action;
            // GameManager.Instance.OnPressed(action);
        }
    }
}
