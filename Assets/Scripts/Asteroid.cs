using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    public Rigidbody2D rigidBody;

    private void Start()
    {
        /*
        float velocityX = Random.Range(0.5f, 3f);
        float velocityY = Random.Range(0.5f, 3f);
        rigidBody.velocity = new Vector2(velocityX, velocityY);
        */
    }

    // Do a compare tag to see if a wall was hit and add some force, otherwise the asteroids slow down too much
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OuterWall"))
        {
            float forceX = Random.Range(-75f, 75f);
            float forceY = Random.Range(-75f, 75f);
            rigidBody.AddForce(new Vector2(forceX, forceY));
        }
    }
}
