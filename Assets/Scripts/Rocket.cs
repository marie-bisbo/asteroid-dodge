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
        float moveAmountVertical = Input.GetAxis("Vertical") * movementSpeedVertical * Time.deltaTime;
        rigidBody.AddForce(new Vector2(0, moveAmountVertical));

        float moveAmountHorizontal = Input.GetAxis("Horizontal") * movementSpeedHorizontal * Time.deltaTime;
        rigidBody.AddForce(new Vector2(moveAmountHorizontal, 0));

        float rotationAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        // Not working at around 0.1 because of float weirdness. Fix is a bit weird, find something better maybe. Not working
        // if (Mathf.Abs(transform.rotation.z) - 0.1 < 0 || rotationAmount < transform.rotation.z)
        if (Mathf.Abs(transform.rotation.z) - 0.1 < 0)
        {
            // Debug.Log($"rotation amount: {rotationAmount}, rotation: {transform.rotation.z}");
            transform.Rotate(0, 0, -rotationAmount);
        }

        // Attempt to correct rotation of rocket. This kind of works but the rocket seems to jitter a bit. 
        if (!Mathf.Approximately(transform.rotation.z, 0f))
        {
            if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f))
            {
                if (transform.rotation.z > 0)
                {
                    transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Asteroid hit");
            FindObjectOfType<GameManager>().OnGameOver();
        }
    }
}
