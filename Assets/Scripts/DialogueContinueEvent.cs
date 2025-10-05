using UnityEngine;

namespace EventBus
{
    public class DialogueContinueEvent : EventType
    {
        public string _eventText { get; private set; }
        public string _characterName { get; private set; }

        public DialogueContinueEvent(string key)
        {
            if (TextContainer.Instance != null)
            {
                Debug.Log(key);
                _characterName = TextContainer.Instance.CurrentDialogueTexts[key].characterName;
                _eventText = TextContainer.Instance.CurrentDialogueTexts[key].text;
            }
        }
    }
}