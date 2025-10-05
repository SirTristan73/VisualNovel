using EventBus;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public static RootController SharedInstance { get; private set; }

    [SerializeField] private ChapterData[] _chapters;
    private int _currentChapterIndex = 0;



    private void OnEnable()
    {
        SharedInstance = this;
    }


    private void OnDisable()
    {
        SharedInstance = null;
    }


    public void StartChapter()
    {
        if (_currentChapterIndex >= _chapters.Length)
        {
            return;
        }

        var chapter = _chapters[_currentChapterIndex];
        DialogueController.SharedInstance.Init(chapter, 0);
    }


    public void OnChapterFinished()
    {

    }
}
