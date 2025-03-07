using UnityEngine;
using UnityEngine.UI;

public class CustomButtonAnimationController : MonoBehaviour 
{
    public Button turnOnButton; 
    public Button turnOffButton; 
    public Animator animator; 

    private void Start()
    {
        // Отключаем аниматор при старте
        animator.enabled = false;
        if (turnOnButton == null || turnOffButton == null || animator == null)
        {
            Debug.LogError("Кнопки или аниматор не назначены в инспекторе!");
            return;
        }

        turnOnButton.onClick.AddListener(PlayTurnOnAnimation);
        turnOffButton.onClick.AddListener(PlayTurnOffAnimation);
    }

    private void PlayTurnOnAnimation()
    {
      animator.enabled = true;
        if (AnimationExists("ton1"))
        {
            
            animator.Play("ton1", -1, 0f);
            Debug.Log("Анимация 'ton1' воспроизведена.");
        }
        else
        {
            Debug.LogError("Анимация 'ton1' не найдена в Animator Controller!");
        }
    }

    private void PlayTurnOffAnimation()
    {
        animator.enabled = true;
        if (AnimationExists("toff1"))
        {
            
            animator.Play("toff1", -1, 0f);
            Debug.Log("Анимация 'toff1' воспроизведена.");
        }
        else
        {
            Debug.LogError("Анимация 'toff1' не найдена в Animator Controller!");
        }
    }


    private bool AnimationExists(string animationName)
    {
        if (animator == null)
        {
            Debug.LogError("Animator не назначен!");
            return false;
        }

      
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;
        if (ac == null)
        {
            Debug.LogError("Animator Controller не назначен!");
            return false;
        }

        foreach (AnimationClip clip in ac.animationClips)
        {
            if (clip.name == animationName)
            {
                return true;
            }
        }

        return false;
    }
}