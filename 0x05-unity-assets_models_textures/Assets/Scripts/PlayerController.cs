using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        jumpForce = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     SceneManager.LoadScene("menu");
        // }
        transform.Translate(movement * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpForce * Time.deltaTime, 0);
        }
    }
}
