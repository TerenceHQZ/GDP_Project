using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera cam;
    public Vector3 camTranslate;

    private Vector3 previousPosition;
    private Vector3 direction;

    protected Plane Plane;
    public float perspectiveZoomSpeed = 0.1f;
    public int minDistance = 60;
    public int maxDistance = 20;
    private void Awake()
    {
        if (cam == null)
            cam = Camera.main;
    }
    void Update()
    {
        if (Input.touchCount >= 1)
            Plane.SetNormalAndPosition(transform.up, transform.position);
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

        if (Input.touchCount >= 2)
        {
            var pos1 = PlanePosition(Input.GetTouch(0).position);
            var pos2 = PlanePosition(Input.GetTouch(1).position);
            var pos1b = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2b = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);


            var zoom = Vector3.Distance(pos1, pos2) /
                       Vector3.Distance(pos1b, pos2b);

            if (zoom == 0 || zoom > 10)
                return;



            cam.transform.position = Vector3.LerpUnclamped(pos1, cam.transform.position, 1 / zoom);
        }
        if (cam.fieldOfView < minDistance)
        {
            cam.fieldOfView = minDistance;
        }
        else
         if (cam.fieldOfView > maxDistance)
        {
            cam.fieldOfView = maxDistance;
        }
    }
    protected Vector3 PlanePositionDelta(Touch touch)
    {
 
        if (touch.phase != TouchPhase.Moved)
            return Vector3.zero;

        var rayBefore = cam.ScreenPointToRay(touch.position - touch.deltaPosition);
        var rayNow = cam.ScreenPointToRay(touch.position);
        if (Plane.Raycast(rayBefore, out var enterBefore) && Plane.Raycast(rayNow, out var enterNow))
            return rayBefore.GetPoint(enterBefore) - rayNow.GetPoint(enterNow);

  
        return Vector3.zero;
    }

    protected Vector3 PlanePosition(Vector2 screenPos)
    {
      
        var rayNow = cam.ScreenPointToRay(screenPos);
        if (Plane.Raycast(rayNow, out var enterNow))
            return rayNow.GetPoint(enterNow);

        return Vector3.zero;
    }
}