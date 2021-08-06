using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Properties")]
    public float CameraSpeed = 30f;

    [Header("Borders")]
    public float BorderThickness = 10f;

    public float MaxZ = 25f;
    public float MinZ = -50f;

    public float MaxX = 30f;
    public float MinX = -30f;

    [Header("Scroll")]
    public float ScrollSpeed = 5000f;
    public float MaxY = 100f;
    public float MinY = 30f;

    private bool _isMooving = false;

    void Update()
    {
        if (GameMaster.GameIsOver)
        {
            enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isMooving = !_isMooving;
        }

        if (!_isMooving)
        {
            return;
        }

        // Handle key press 
        var areaHeight = Screen.height - BorderThickness;
        var areaWidth = Screen.width - BorderThickness;
        if (Input.GetKey("w") || Input.mousePosition.y >= areaHeight)
        {
            var translateVector = Vector3.forward * CameraSpeed * Time.deltaTime;
            var newZ = transform.position.z + translateVector.z;
            if (newZ >= MinZ && newZ <= MaxZ)
            {
                transform.Translate(translateVector, Space.World);
            }
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= BorderThickness)
        {
            var translateVector = Vector3.back * CameraSpeed * Time.deltaTime;
            var newZ = transform.position.z + translateVector.z;
            if (newZ >= MinZ && newZ <= MaxZ)
            {
                transform.Translate(translateVector, Space.World);
            }
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= areaWidth)
        {
            var translateVector = Vector3.right * CameraSpeed * Time.deltaTime;
            var newX = transform.position.x + translateVector.x;
            if (newX >= MinX && newX <= MaxX)
            {
                transform.Translate(translateVector, Space.World);
            }
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= BorderThickness)
        {
            var translateVector = Vector3.left * CameraSpeed * Time.deltaTime;
            var newX = transform.position.x + translateVector.x;
            if (newX >= MinX && newX <= MaxX)
            {
                transform.Translate(translateVector, Space.World);
            }
        }

        // Handle scroll
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        var position = transform.position;

        position.y -= scroll * ScrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, MinY, MaxY);

        transform.position = position;
    }
}
