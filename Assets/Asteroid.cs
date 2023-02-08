using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    private void Start()
    {
        float velocityX = Random.Range(0f, 3f);
        float velocityY = Random.Range(0f, 3f);
        rigidBody.velocity = new Vector2(velocityX, velocityY);
    }
}
