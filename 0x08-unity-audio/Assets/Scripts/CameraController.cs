using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Transform cameraTarget;
    float mouseX, mouseY;
    public float sens, playerDistance;
    private float yRotation, xRotation;
    private Vector3 currentRotation, smoothVelocity;
    public float smoothTime;
    public bool isInverted;
    // Start is called before the first frame update
    void Start()
    {
        sens = 3f;
        playerDistance = 6.25f;
        smoothVelocity = Vector3.zero;
        smoothTime = 0.1f;
        isInverted = false;
    }
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sens;
        mouseY = Input.GetAxis("Mouse Y") * sens;
        yRotation += mouseX;
        if (isInverted)
            xRotation += mouseY;
        else
            xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -5, 70);

        Vector3 nextRotation = new Vector3(xRotation, yRotation);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotation;
        transform.position = cameraTarget.position - transform.forward * playerDistance;
    }
}
