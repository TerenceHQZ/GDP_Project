using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Joystick playerJoystick;
    public float movementSpeed;
    private Rigidbody rb;
    public Vector3 clampPos;

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

        clampPos.x = Mathf.Clamp(transform.position.x, -12, 12);
        clampPos.z = Mathf.Clamp(transform.position.z, -12, 12);
        transform.position = clampPos;
    }
}
