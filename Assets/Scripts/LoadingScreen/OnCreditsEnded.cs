using EventBus;
using UnityEngine;

public class OnCreditsEnded : MonoBehaviour
{
    public void EnterSystemsLoadedState()
    {
        GameManager.Instance.ChangeGameState(GameState.SystemsLoaded);
    }
}
