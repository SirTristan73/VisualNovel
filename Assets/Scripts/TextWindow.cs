using System.Collections;
using TMPro;
using UnityEngine;

namespace EventBus
{
    public class TextWindow : MonoBehaviour
    {
        public TMP_Text _textShown;
        private string _textRecieved;
        private float _charDelay = 0.03f;
        private bool _allowNextLine = true;



        private void OnEnable()
        {
            EventBus.SubscribeToEvenet<DialogueContinueEvent>(TextDialogueDisplay);
        }


        private void OnDisable()
        {
            EventBus.UnsubscribeFromEvent<DialogueContinueEvent>(TextDialogueDisplay); 
        }


        private void TextDialogueDisplay(DialogueContinueEvent eventData)
        {
            
            if (_allowNextLine)
            {
                _textShown.text = null;
                _textRecieved = eventData._eventText;
                StartCoroutine(RollText());
            }

        }


        IEnumerator RollText()
        {
            _allowNextLine = false;
            foreach (char c in _textRecieved)
            {
                _textShown.text += c;
                yield return new WaitForSeconds(_charDelay);
            }
            
            _allowNextLine = true;
        }
    }
}