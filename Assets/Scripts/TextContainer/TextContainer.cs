using UnityEngine;
using System;
using System.Collections.Generic;


namespace EventBus
{
    public class TextContainer : PersistentSingleton<TextContainer>
    {
        public static event Action<Dictionary<string, string>, Dictionary<string, string>> OnChangeLanguage;
        // public static event Action<Dictionary<string, string>> OnChangeDialogueLanguage;

        public LanguageState CurrentLanguage { get; private set; }

        [SerializeField] private LanguageData[] _languageData;

        private Dictionary<string, string> _currentMenuTexts;
        public Dictionary<string, string> CurrentMenuTexts => _currentMenuTexts;

        private Dictionary<string, string> _currentDialogueTexts;
        public Dictionary<string, string> CurrentDialogueTexts => _currentDialogueTexts;


        private static readonly Dictionary<LanguageState, Type> LanguageMap = new()
        {

                {LanguageState.English, typeof(EnglishData) }

        };


        public void SetTextLanguage(LanguageState language)
        {
            // if (CurrentLanguage == language) return;
            CurrentLanguage = language;

            if (LanguageMap.TryGetValue(language, out var type))
            {
                _currentDialogueTexts = GetDialogueTexts(type) ?? new Dictionary<string, string>();
                _currentMenuTexts = GetMenuTexts(type) ?? new Dictionary<string, string>();
            }
            else
            {
                Debug.LogError($"Language {language} not found");
            }

            Debug.Log("Set");
            Debug.Log(CurrentLanguage);

            OnChangeLanguage?.Invoke(_currentDialogueTexts, _currentMenuTexts);
            
        }


        private Dictionary<string, string> GetMenuTexts(Type type)
        {
            foreach (var data in _languageData)
            {
                if (data.GetType() == type)
                {
                    return data.MenuTexts;
                }
            }
            Debug.LogError("NotFOund");
            return null;
        }


        private Dictionary<string, string> GetDialogueTexts(Type type)
        {
            foreach (var data in _languageData)
            {
                if (data.GetType() == type)
                {
                    return data.DialogueTexts;
                }
            }
            Debug.LogError("NotFOund");
            return null;
        }


        public enum LanguageState
        {
            English = 0,
            Russian = 1,
            Ukrainian = 2,
        }
    }
}