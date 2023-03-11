using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject menuUI;

    public void OpenMenu()
    {
        menuUI.SetActive(true);
    }

    /* Don't need this function right now as we open the menu instead
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
}
