using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody.velocity = new Vector2(0.5f, 0.5f);
    }
}
