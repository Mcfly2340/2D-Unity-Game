using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Rigidbody2D rigidbody;
    public bool jumpable = false;
    
    // Use this for initialization
    void Start()
    {
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, groundLayer);
        if (hit.collider != null){
            jumpable = true;
            Debug.Log(hit.point);
        }

        if (jumpable)
        {
            rigidbody.velocity = Vector2.up * jumpSpeed * 20;
            jumpable = false;
        }

        
        
    }
}