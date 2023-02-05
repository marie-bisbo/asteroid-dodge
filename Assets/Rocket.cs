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
        // Not working at around 0.1 because of float weirdness. Fix is a bit weird, find something better maybe
        if (Mathf.Abs(transform.rotation.z) - 0.1 < 0 || rotationAmount < transform.rotation.z)
        {
            transform.Rotate(0, 0, -rotationAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Oh no!");
        }
    }
}
