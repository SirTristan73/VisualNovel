using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LanguageData")]
public class EnglishData : LanguageData
{
    private Dictionary<string, string> _menuTexts = new Dictionary<string, string>()
    {
        {"title_mainMenu", "xer"},
    };

    public override Dictionary<string, string> MenuTexts => _menuTexts;



    private Dictionary<string, (string characterName, string text)> _dialogueTexts = new Dictionary<string, (string characterName, string text)>()
    {
        {"Queen0", ("Королева", "Дарова братишка, сасать пришёл, давай к нам мы тут уже по третему кругу пошли")},
        {"Queen1", ("Королева", "Ты поторопись, у нас тут котлетки")},
    };

    public override Dictionary<string, (string characterName, string text)> DialogueTexts => _dialogueTexts;
}
