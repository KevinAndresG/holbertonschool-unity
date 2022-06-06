using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Vector3 movement;
    private Vector3 playerMove;
    private CharacterController player;
    public Camera mainCam;
    private Vector3 forwardCam;
    private Vector3 rightCam;
    private Vector3[] cam;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jumpForce = 10f;
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1);
        cam = CameraController.CamDirection(mainCam, forwardCam, rightCam);
        playerMove = movement.x * cam[0] + movement.z * cam[1];
        player.transform.LookAt(player.transform.position + playerMove);

        player.Move(playerMove * speed * Time.deltaTime);
    }
}
