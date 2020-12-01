using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera cam;
    public Vector3 camTranslate;

    private Vector3 previousPosition;
    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
            }

            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                direction = previousPosition - cam.ScreenToViewportPoint(Input.GetTouch(0).position);

                cam.transform.position = new Vector3();

                //cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
                cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
                cam.transform.Translate(camTranslate);

                previousPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
            }
        }
    }
}