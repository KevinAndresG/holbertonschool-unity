using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        sens = 4f;
        playerDistance = 6.25f;
        smoothVelocity = Vector3.zero;
        smoothTime = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sens;
        mouseY = Input.GetAxis("Mouse Y") * sens;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -5, 60);

        Vector3 nextRotation = new Vector3(xRotation, yRotation);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotation;
        transform.position = cameraTarget.position - transform.forward * playerDistance;
    }
}
