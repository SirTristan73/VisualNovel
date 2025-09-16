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



    private Dictionary<string, string> _dialogueTexts = new Dictionary<string, string>()
    {
        {"first_", "Дарова братишка, сасать пришёл, давай к нам мы тут уже по третему кругу пошли"},
        {"second_", "Ты поторопись, у нас тут котлетки" },
    };

    public override Dictionary<string, string> DialogueTexts => _dialogueTexts;
}
