using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour 
{
    public Button turnOnButton; 
    public Button turnOffButton; 
    public Animator animator; 

    private void Start()
    {
        // Отключаем аниматор при старте
        animator.enabled = false;

        // Добавляем обработчики нажатия на кнопки
        turnOnButton.onClick.AddListener(PlayTurnOnAnimation);
        turnOffButton.onClick.AddListener(PlayTurnOffAnimation);
    }

    private void PlayTurnOnAnimation()
    {
        // Включаем аниматор и воспроизводим анимацию
        animator.enabled = true;
        animator.Play("TurnOn", -1, 0f);
    }

    private void PlayTurnOffAnimation()
    {
        // Включаем аниматор и воспроизводим анимацию
        animator.enabled = true;
        animator.Play("TurnOff", -1, 0f);
    }
}