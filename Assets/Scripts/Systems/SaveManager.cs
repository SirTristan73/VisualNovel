using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveManager : PersistentSingleton<SaveManager>

{
    private string _savePath;
    public string _pathToLoad;

    protected override void Awake()
    {
        base.Awake();
        _savePath = Path.Combine(Application.persistentDataPath, "game_save.json");
        Debug.Log(_savePath);
    }


    public void SaveGame(SaveFile dataToSave)
    {
        try
        {
            string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
            File.WriteAllText(_savePath, json);
        }

        catch (System.Exception e)
        {
            Debug.LogError($"Error Saving {e.Message}");
        }
    }


    public SaveFile LoadGame()
    {
        if (File.Exists(_savePath))
        {
            try
            {
                string json = File.ReadAllText(_savePath);
                SaveFile loadedData = JsonConvert.DeserializeObject<SaveFile>(json);
                return loadedData;
            }

            catch (System.Exception e)
            {
                Debug.LogError($"Error Loading {e.Message}");
                return new SaveFile();
            }
        }

        else
        {
            Debug.LogWarning("SaveFile not found");
            return new SaveFile();
        }
    }


    public bool HasSaveGame()
    {
        return File.Exists(_savePath);
    }


    public void DeleteSaveGame()
    {
        if (File.Exists(_savePath))
        {
            File.Delete(_savePath);
        }

        else
        {
            Debug.LogWarning("No SaveFile to delete");
        }
    }
}