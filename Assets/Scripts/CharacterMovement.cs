using UnityEngine;
public class CharacterMovement : MonoBehaviour
{
    public Joystick playerJoystick;
    public float movementSpeed;
    private Rigidbody rb;
    public Vector3 clampPos;
    Transform playerPivot;

    void Start()
    {
        playerPivot = transform.Find("PlayerPivot");
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Vector3 cameraDirection = new Vector3(playerJoystick.Horizontal, 0f, playerJoystick.Vertical);
        cameraDirection = Camera.main.transform.TransformDirection(cameraDirection);
        cameraDirection.y = 0.0f;

        Vector3 direction = cameraDirection * movementSpeed;
        rb.AddForce(direction * Time.fixedDeltaTime, ForceMode.VelocityChange);

        ClampPosition();
    }

    void ClampPosition()
    {
        clampPos = transform.position;
        if (ArcadeManager.arcadeManager)
        {
            if (ArcadeManager.arcadeManager.atArcade)
            {
                clampPos.x = Mathf.Clamp(transform.position.x, -1.549f, 1.4f);
                clampPos.z = Mathf.Clamp(transform.position.z, -1.54f, 1.4f);
                transform.position = clampPos;
                return;
            }
        }
        else if (!GoToHome.atHome)
        {
            clampPos.x = Mathf.Clamp(transform.position.x, -12, 12);
            clampPos.z = Mathf.Clamp(transform.position.z, -12, 12);
            transform.position = clampPos;
            return;
        }
        else if (GoToHome.atHome)
        {
            clampPos.x = Mathf.Clamp(transform.position.x, 102.3f, 105.5f);
            clampPos.z = Mathf.Clamp(transform.position.z, 10, 13.6f);
            transform.position = clampPos;
            return;
        }
    }
}
