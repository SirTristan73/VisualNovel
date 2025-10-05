using UnityEngine;
using UnityEngine.UI;

public class SaveWindow : MonoBehaviour
{
    // public GameObject slotButtonPrefab; // Префаб кнопки с Image + Text
    // public Transform slotsParent;       // Контейнер для кнопок
    // private int maxSlots = 10;

    // private void Start()
    // {
    //     CreateSlotButtons();
    // }

    // private void CreateSlotButtons()
    // {
    //     for (int i = 1; i <= maxSlots; i++)
    //     {
    //         GameObject buttonObj = Instantiate(slotButtonPrefab, slotsParent);
    //         Button button = buttonObj.GetComponent<Button>();

    //         Image thumbnail = buttonObj.transform.Find("Thumbnail").GetComponent<Image>();
    //         Text buttonText = buttonObj.transform.Find("SlotText").GetComponent<Text>();

    //         UpdateSlotVisual(i, buttonText, thumbnail);

    //         int slotIndex = i; // локальная копия для замыкания

    //         button.onClick.AddListener(() =>
    //         {
    //             OnSlotClicked(slotIndex);
    //         });
    //     }
    // }

    // private void UpdateSlotVisual(int slotIndex, Text buttonText, Image thumbnail)
    // {
    //     if (SaveManager.Instance.HasSaveGame(slotIndex))
    //     {
    //         SaveFile data = SaveManager.Instance.LoadGame(slotIndex);

    //         buttonText.text = $"Slot {slotIndex}: {data.chapterName}";

    //         if (data.thumbnail != null)
    //             thumbnail.sprite = data.thumbnail; // спрайт из SaveFile
    //         else
    //             thumbnail.color = Color.gray; // если нет изображения
    //     }
    //     else
    //     {
    //         buttonText.text = $"Slot {slotIndex} (Empty)";
    //         thumbnail.color = Color.black; // пустой слот
    //     }
    // }

    // private void OnSlotClicked(int slotIndex)
    // {
    //     if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
    //     {
    //         // Сохраняем
    //         SaveFile currentData = GetCurrentGameData();
    //         SaveManager.Instance.SaveGame(currentData, slotIndex);
    //     }
    //     else
    //     {
    //         // Загружаем
    //         SaveFile loaded = SaveManager.Instance.LoadGame(slotIndex);
    //         LoadGameData(loaded);
    //     }

    //     // Обновляем визуал
    //     RefreshAllSlots();
    // }

    // private void RefreshAllSlots()
    // {
    //     for (int i = 0; i < slotsParent.childCount; i++)
    //     {
    //         Transform slotObj = slotsParent.GetChild(i);
    //         Text buttonText = slotObj.Find("SlotText").GetComponent<Text>();
    //         Image thumbnail = slotObj.Find("Thumbnail").GetComponent<Image>();
    //         int slotIndex = i + 1;
    //         UpdateSlotVisual(slotIndex, buttonText, thumbnail);
    //     }
    // }

    // // Возвращаем текущие данные игры
    // private SaveFile GetCurrentGameData()
    // {
    //     SaveFile data = new SaveFile();
    //     data.chapterName = "Глава 1"; // пример
    //     data.thumbnail = TakeThumbnail(); // мини-скриншот текущей сцены
    //     return data;
    // }

    // // Загружаем данные обратно
    // private void LoadGameData(SaveFile data)
    // {
    //     // применяем прогресс, сцену, персонажей и т.д.
    // }

    // // Пример мини-скриншота: рендерим текущий экран в спрайт
    // private Sprite TakeThumbnail()
    // {
    //     Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
    //     return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
    // }
}