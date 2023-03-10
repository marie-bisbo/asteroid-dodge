using UnityEngine;

public class LandingCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lander"))
        {
            Debug.Log("Landing...");
            FindObjectOfType<GameManager>().OnLevelComplete();
        }
    }
}
