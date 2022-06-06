using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0f, 1.25f, -6.25f);
    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
    public static Vector3[] CamDirection(Camera mainCam, Vector3 forwardCam, Vector3 rightCam)
    {
        Vector3[] values = new Vector3[2];
        forwardCam = mainCam.transform.forward;
        rightCam = mainCam.transform.right;
        forwardCam.y = 0;
        rightCam.y = 0;
        forwardCam = forwardCam.normalized;
        rightCam = rightCam.normalized;
        values[0] = rightCam;
        values[1] = forwardCam;
        return (values);
    }
}
