using UnityEngine;


[System.Serializable]
public class SaveFile
{



    public GameSettings GameSettings = new GameSettings();


    public SaveFile()
    {


    }
}



[System.Serializable]
public class GameSettings
{
    public float _masterVolume;
    public float _musicVolume;
    public float _sfxVolume;
    public int _resolutionIND;
    public bool _fullscreenIS;
    public int _refreshRateIND;




    public GameSettings()
    {
        _masterVolume = 1f;
        _musicVolume = 1f;
        _sfxVolume = 1f;
        _fullscreenIS = true;
        _resolutionIND = 1;
        _refreshRateIND = 1;

    }

}