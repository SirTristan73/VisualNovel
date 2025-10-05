using System;
using UnityEngine;

namespace EventBus
{

    public class DialogueController : MonoBehaviour
    {
        public static DialogueController SharedInstance { get; private set; }

        public static Action OnChapterFinised;

        private ChapterData _chapterData;
        private int _currentLine = 0;



        void Start()
        {
            TextContainer.Instance.SetTextLanguage(TextContainer.LanguageState.English);
            SharedInstance = this;
        }


        private void OnDisable()
        {
            SharedInstance = null;
        }


        public void Init(ChapterData chapter, int line)
        {
            _chapterData = chapter;
            _currentLine = line;
            ShowNextLine();
        }


        public void ShowNextLine()
        {
            if (_chapterData == null || _currentLine >= _chapterData._dialogueKeys.Count)
            {
                Debug.Log("finish");
                OnChapterFinised?.Invoke();
                return;
            }

            string key = _chapterData._dialogueKeys[_currentLine];
            Debug.Log(key);
            Debug.Log(_currentLine);

            EventBus.Trigger(new DialogueContinueEvent(key));
            _currentLine++;

        }


        public void JumpToLine(int lineIndex)
        {
            if (_chapterData != null || lineIndex < 0 || lineIndex >= _chapterData._dialogueKeys.Count)
            {
                return;
            }
            else
            {
                _currentLine = lineIndex;
                ShowNextLine();
            }
        }


        

    }
}