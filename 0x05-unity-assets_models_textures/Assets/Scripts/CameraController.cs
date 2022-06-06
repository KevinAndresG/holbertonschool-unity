using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Update is called once per frame
    public GameObject player;
    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0f, 3f, -3f);
    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
