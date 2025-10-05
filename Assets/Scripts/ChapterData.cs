using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ChapterData")]

public class ChapterData : ScriptableObject
{
    public int _chapterInd;
    public List<string> _dialogueKeys;
}
