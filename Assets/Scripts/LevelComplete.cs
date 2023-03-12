using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject menuUI;

    public void OpenMenu()
    {
        // Make sure to pause the game in the background, otherwise the asteroid can hit the rocket and restart the level
        Time.timeScale = 0f;
        menuUI.SetActive(true);
    }

    /* Don't need this function right now as we open the menu instead
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    */
}
