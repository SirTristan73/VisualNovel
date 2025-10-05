using UnityEngine;



[CreateAssetMenu(menuName = "Character Data")]

public class CharacterData : ScriptableObject
{
    public string _characterName;
    public int _characterProgress;

    public GameObject _baseCharacter;

}
