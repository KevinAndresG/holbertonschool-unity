using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float GRAVITY;
    private float temporaryGravity;
    public float speed;
    public float jumpForce;
    public int doubleJump;
    private Vector3 movement;
    private CharacterController player;
    private float playerRotationSpeed;
    public Camera cameraFollow;
    public GameObject playerPosition;
    public Transform respawn;
    public float respawnValue;
    public Toggle doubleJumpCheck;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        GRAVITY = 7f;
        speed = 7f;
        jumpForce = 3f;
        playerRotationSpeed = 10f;
        respawnValue = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Quaternion.Euler(0, cameraFollow.transform.eulerAngles.y, 0) * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerRotationSpeed * Time.deltaTime);
        }
        if (player.isGrounded)
        {
            doubleJump = 2;

            temporaryGravity = -GRAVITY * Time.deltaTime;
            movement.y = temporaryGravity;
            if (Input.GetButtonDown("Jump"))
            {
                temporaryGravity = jumpForce;
                movement.y = temporaryGravity;
                doubleJump--;
            }

            if (doubleJump > 1)
                doubleJumpCheck.isOn = true;
        }
        else
        {
            if (Input.GetButtonDown("Jump") && doubleJump > 0)
            {
                temporaryGravity = jumpForce;
                doubleJump--;
                if (doubleJump == 0)
                    doubleJumpCheck.isOn = false;
            }
            movement.y = temporaryGravity;
            temporaryGravity -= GRAVITY * Time.deltaTime;
        }
        player.Move(movement * speed * Time.deltaTime);
        if (playerPosition.transform.position.y < -respawnValue)
        {
            FallFromSky();
        }
    }
    public void FallFromSky()
    {
        playerPosition.transform.position = respawn.transform.position;
    }
}
