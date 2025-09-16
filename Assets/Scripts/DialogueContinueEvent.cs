using UnityEngine;

namespace EventBus
{
    public class DialogueContinueEvent : EventType
    {
        public string _eventText { get; private set; }

        public DialogueContinueEvent(string key)
        {
            _eventText = TextContainer.Instance.CurrentDialogueTexts[key];
        }
    }
}