using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float movementSpeedVertical = 100f;

    [SerializeField]
    private float movementSpeedHorizontal = 100f;

    [SerializeField]
    private float rotationSpeed = 10f;

    void FixedUpdate()
    {
        if (Input.GetAxis("Vertical") >= 0f) // Cannot apply rocket thrust downwards
        {
            float moveAmountVertical = Input.GetAxis("Vertical") * movementSpeedVertical * Time.deltaTime;
            rigidBody.AddForce(new Vector2(0, moveAmountVertical));
        }

        float moveAmountHorizontal = Input.GetAxis("Horizontal") * movementSpeedHorizontal * Time.deltaTime;
        rigidBody.AddForce(new Vector2(moveAmountHorizontal, 0));

        float rotationAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        if (Mathf.Abs(transform.rotation.z) - 0.1 < 0)
        {
            transform.Rotate(0, 0, -rotationAmount);
        }

        // Attempt to correct rotation of rocket. This kind of works but the rocket seems to jitter a bit. 
        if (!Mathf.Approximately(transform.rotation.z, 0f)) // If rotation is not already zero
        {
            if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f)) // If there is no input to change rotation
            {
                float direction = transform.rotation.z > 0 ? -1 : 1;
                transform.Rotate(0, 0, direction * rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("OuterWall"))
        {
            FindObjectOfType<GameManager>().OnGameOver();
        }
    }
}
