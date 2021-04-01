 /*using UnityEngine;
using System.Collections;
public class 1PlayerController : MonoBehaviour
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
    

    private float horizontalInput;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public float groundCheckRadius = 2;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public bool jumpable = false;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, groundLayer);
        if (hit.collider != null)
        {
            jumpable = true;
            Debug.Log(hit.point);
        }

        if (jumpable && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpSpeed * 3;
            jumpable = false;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * 5);

        //input left & right
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector2.right * speed * horizontalInput;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector2.right * -1;
        }
        //
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector2.right * speed * horizontalInput;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.right * -1;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(90, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(-90, 0, 0);
        }
    }
    
}}*/