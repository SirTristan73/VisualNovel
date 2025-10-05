using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EventBus
{
    public class TextWindow : MonoBehaviour
    {
        public TMP_Text _textShown;
        public TMP_Text _characterName;
        public AudioSource _audio;
        public Button _nextButton;


        private string _textRecieved;
        private float _charDelay = 0.05f;
        private bool _allowNextLine = true;



        private void OnEnable()
        {
            EventBus.SubscribeToEvent<DialogueContinueEvent>(TextDialogueDisplay);
            _nextButton.onClick.AddListener(NextLineButton);
        }


        private void OnDisable()
        {
            EventBus.UnsubscribeFromEvent<DialogueContinueEvent>(TextDialogueDisplay);
            _nextButton.onClick.RemoveAllListeners(); 
        }


        private void TextDialogueDisplay(DialogueContinueEvent eventData)
        {
            _characterName.text = eventData._characterName;

            if (_allowNextLine)
            {
                _textShown.text = null;
                _textRecieved = eventData._eventText;
                StartCoroutine(RollText());
            }

        }


        private void NextLineButton()
        {
            DialogueController.SharedInstance.ShowNextLine();
        }


        IEnumerator RollText()
        {
            _allowNextLine = false;
            _nextButton.interactable = _allowNextLine;

            foreach (char c in _textRecieved)
            {
                _textShown.text += c;
                if (_audio != null) _audio.Play();
                yield return new WaitForSeconds(_charDelay);
            }

            _allowNextLine = true;
            _nextButton.interactable = _allowNextLine;
        }
    }
}