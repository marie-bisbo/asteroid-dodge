using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody.velocity = new Vector2(3f, 0f);
    }
}
