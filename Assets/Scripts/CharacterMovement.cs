using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Joystick playerJoystick;
    public float movementSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Vector3 cameraDirection = new Vector3(playerJoystick.Horizontal, 0f, playerJoystick.Vertical);
        cameraDirection = Camera.main.transform.TransformDirection(cameraDirection);
        cameraDirection.y = 0.0f;

        rb.AddForce(cameraDirection * movementSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
