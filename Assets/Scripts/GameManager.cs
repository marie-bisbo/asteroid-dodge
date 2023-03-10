using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelCompleteUI;

    public void OnLevelComplete()
    {
        levelCompleteUI.SetActive(true);
    }

    public void OnGameOver()
    {
        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
