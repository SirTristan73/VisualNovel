using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveManager : PersistentSingleton<SaveManager>

{
    private string _savePath;
    private const int _maxSaveSlots = 12;


    protected override void Awake()
    {
        base.Awake();

        _savePath = Path.Combine(Application.persistentDataPath, "Visual-novel_saveFiles");

        if (!Directory.Exists(_savePath))
        {
            Directory.CreateDirectory(_savePath);
        }

        Debug.Log(_savePath);
    }


    private string GetSavePath(int slotIndex)
    {
        return Path.Combine(_savePath, slotIndex + ".json");
    }


    public void SaveGame(SaveFile dataToSave, int slotIndex)
    {
        if (slotIndex < 1 || slotIndex > _maxSaveSlots)
        {
            return;
        }

        string path = GetSavePath(slotIndex);

        try
        {
            string json = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        catch (System.Exception e)
        {
            Debug.LogError($"Error Saving {e.Message}");
        }
    }


    public SaveFile LoadGame(int slotIndex)
    {
        if (slotIndex < 1 || slotIndex > _maxSaveSlots)
        {
            return new SaveFile();
        }

        string path = GetSavePath(slotIndex);

        if (File.Exists(path))
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


    public bool HasSaveGame(int slotIndex)
    {
        return File.Exists(GetSavePath(slotIndex));
    }


    public void DeleteSaveGame(int slotIndex)
    {
        if (slotIndex < 1 || slotIndex > _maxSaveSlots)
        {
            return;
        }

        string path = GetSavePath(slotIndex);

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        else
        {
            Debug.LogWarning("No SaveFile to delete");
        }
    }


    public string[] GetAllSaveSlots()
    {
        string[] slots = new string[_maxSaveSlots];

        for (int i = 0; i < _maxSaveSlots; i++)
        {
            slots[i] = HasSaveGame(i + 1) ? $"Slot{i + 1}" : $"Empty Slot{i + 1}";
        }
        return slots;
    }
}