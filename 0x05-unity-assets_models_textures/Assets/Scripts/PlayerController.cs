using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float GRAVITY;
    private float temporaryGravity;
    public float speed;
    public float jumpForce;
    public bool doubleJump;
    private Vector3 movement;
    private CharacterController player;
    private float playerRotationSpeed;
    public Camera cameraFollow;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        GRAVITY = 6f;
        speed = 10f;
        jumpForce = 2f;
        playerRotationSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Quaternion.Euler(0, cameraFollow.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        // Alternative to previos line
        // movement = Vector3.ClampMagnitude(movement, 1);
        if (movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerRotationSpeed * Time.deltaTime);
        }
        if (player.isGrounded)
        {
            doubleJump = true;

            temporaryGravity = -GRAVITY * Time.deltaTime;
            movement.y = temporaryGravity;
            if (Input.GetButtonDown("Jump"))
            {
                temporaryGravity = jumpForce;
                movement.y = temporaryGravity;
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && doubleJump)
            {
                temporaryGravity = jumpForce;
                doubleJump = false;
            }
            movement.y = temporaryGravity;
            temporaryGravity -= GRAVITY * Time.deltaTime;
        }
        player.Move(movement * speed * Time.deltaTime);
    }
}
