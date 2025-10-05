using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{
    public class CharacterManager : PersistentSingleton<CharacterManager>
    {
        public List<CharacterData> _allCharacters;


        private void OnEnable()
        {

            GameObject instanceChar = Instantiate(_allCharacters[0]._baseCharacter, this.transform.position, Quaternion.identity);
            var script = instanceChar.GetComponent<CharacterState>();
            script.Init(_allCharacters[0]._characterName, _allCharacters[0]._characterProgress);

        }

    }
}
