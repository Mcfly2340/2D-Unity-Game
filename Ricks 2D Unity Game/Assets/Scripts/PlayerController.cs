using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public AudioSource jump;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    public GameObject player;
    public float otherSpeed;
    
    // Use this for initialization
    void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //move left & right
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * 5);
        rb.velocity = Vector3.right * horizontalInput * Time.deltaTime * otherSpeed;
    }
}