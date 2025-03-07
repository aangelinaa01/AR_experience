using UnityEngine;
using UnityEngine.UI;

public class lever : MonoBehaviour
{
    public Button turnOnButton; 
    public Button turnOffButton; 
    public Animator animator; 

    private void Start()
    {
        // Отключаем аниматор при старте
        animator.enabled = false;
        turnOnButton.onClick.AddListener(PlayTurnOnAnimation);
        turnOffButton.onClick.AddListener(PlayTurnOffAnimation);
    }

    private void PlayTurnOnAnimation()
    {
       animator.enabled = true;
        animator.Play("leverTurnOn", -1, 0f);
    }

    private void PlayTurnOffAnimation()
    {
        animator.enabled = true;
        animator.Play("leverTurnOff", -1, 0f);
    }
}