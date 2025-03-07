using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Arrows : MonoBehaviour
{
    public Button turnOnButton; // Кнопка "ВКЛ"
    public Button turnOffButton; // Кнопка "ВЫКЛ"
    public GameObject[] arrowsObjects; // Массив объектов стрелок
    private Animator[] animators; // Массив аниматоров стрелок

    private string[] currentAnimationClips; // Массив текущих анимаций для объектов стрелок

    private void Start()
    {
        animators = new Animator[arrowsObjects.Length]; // Инициализируем массив аниматоров
        string currentScene = SceneManager.GetActiveScene().name;

        // Определяем, какие анимации использовать в зависимости от сцены
        if (currentScene == "влево")
        {
            // Анимации для сцены "влево"
            currentAnimationClips = new string[] 
            {
                "arrows6", // Arrow(1) — анимация arrows6
                "arrows7", // Arrow — анимация arrows7
                "arrows4", // Arrow(4) — анимация arrows4
                "arrows5"  // Arrow(2) — анимация arrows5
            };
        }
        else if (currentScene == "вправо")
        {
            // Анимации для сцены "вправо"
            currentAnimationClips = new string[] 
            {
                "arrows2", // Arrows(1) — анимация arrows2
                "arrows1", // Arrows — анимация arrows1
                "arrows",  // Arrows(3) — анимация arrows
                "arrows3"  // Arrows(2) — анимация arrows3
            };
        }
        else
        {
            currentAnimationClips = new string[arrowsObjects.Length]; // Если сцена не совпала, анимации не назначаем
        }

        // Инициализация объектов и аниматоров
        for (int i = 0; i < arrowsObjects.Length; i++)
        {
            if (arrowsObjects[i] != null)
            {
                arrowsObjects[i].SetActive(false); // Скрываем все стрелки при старте
                animators[i] = arrowsObjects[i].GetComponent<Animator>(); // Получаем аниматор для каждой стрелки
            }
        }

        // Добавляем обработчики нажатия на кнопки
        turnOnButton.onClick.AddListener(PlayArrowsAnimation);
        turnOffButton.onClick.AddListener(StopArrowsAnimation);
    }

    private void PlayArrowsAnimation()
{
    for (int i = 0; i < arrowsObjects.Length; i++)
    {
        if (arrowsObjects[i] != null && i < currentAnimationClips.Length)
        {
            arrowsObjects[i].SetActive(true); // Показываем стрелки
            Debug.Log("Playing animation: " + currentAnimationClips[i]); // Debug log to check which animation is being played
            animators[i].Play(currentAnimationClips[i], -1, 0f); // Запускаем анимацию
        }
    }
}


    private void StopArrowsAnimation()
    {
        for (int i = 0; i < arrowsObjects.Length; i++)
        {
            if (arrowsObjects[i] != null && i < currentAnimationClips.Length)
            {
                animators[i].Play(currentAnimationClips[i], -1, 1f); // Останавливаем анимацию (по желанию)
                arrowsObjects[i].SetActive(false); // Скрываем стрелки
            }
        }
    }
}
