using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
public void GotoMainScene()
{
SceneManager.LoadScene("влево");
}

public void GotoMenuScene()
{
SceneManager.LoadScene("вправо");
}
}