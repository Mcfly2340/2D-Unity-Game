using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public float jumpForce;
    public float playerSpeed;
    public Vector2 jumpHeight;
    private bool isOnGround;
    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;
    public GameObject DoorWay;
    private bool gravityToggle;
    private bool noClipToggle;
        public GameObject playerHead;
        public GameObject playerChest;
        public GameObject playerHips;
        public GameObject playerLeftLeg;
        public GameObject playerRightLeg;
        public GameObject playerLeftUpArm;
        public GameObject playerRightUpArm;
        public GameObject playerLeftLowArm;
        public GameObject playerRightLowArm;
        public GameObject playerLeftHand;
        public GameObject playerRightHand;

    // Start is called before the first frame update
    void Start()
    {
        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && !gravityToggle)
            {
                anim.Play("Walk");
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
            else if(!gravityToggle)
            {
                anim.Play("WalkBack");
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
            if (Input.GetAxisRaw("Horizontal") > 0 && gravityToggle)
            {
                rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime);
            }
            else if (gravityToggle)
            {
                rb.AddForce(Vector2.left * playerSpeed * Time.deltaTime);
            }
            if (Input.GetAxisRaw("Vertical") > 0 && gravityToggle)
            {
                rb.AddForce(Vector2.up * playerSpeed * Time.deltaTime);
            }
            else if (gravityToggle)
            {
                rb.AddForce(Vector2.down * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.F4))
            {
                gravityToggle = !gravityToggle;
            }
            if (Input.GetKeyUp(KeyCode.F10))
            {
                gravityToggle = !gravityToggle;
                noClipToggle = !noClipToggle;
            }

            if (gravityToggle)
            {
                anim.Play("Crawling");
            }
            else
            {
                anim.Play("Idle");
            }

            if (noClipToggle)
            {
                playerHead.GetComponent<CircleCollider2D>().enabled = false;
                playerLeftHand.GetComponent<CircleCollider2D>().enabled = false;
                playerRightHand.GetComponent<CircleCollider2D>().enabled = false;
                playerChest.GetComponent<BoxCollider2D>().enabled = false;
                playerLeftLeg.GetComponent<BoxCollider2D>().enabled = false;
                playerRightLeg.GetComponent<BoxCollider2D>().enabled = false;
                playerLeftLowArm.GetComponent<BoxCollider2D>().enabled = false;
                playerRightLowArm.GetComponent<BoxCollider2D>().enabled = false;
                playerLeftUpArm.GetComponent<BoxCollider2D>().enabled = false;
                playerRightUpArm.GetComponent<BoxCollider2D>().enabled = false;
                playerHips.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Disabled");
            }
            else
            {
                playerHead.GetComponent<CircleCollider2D>().enabled = true;
                playerLeftHand.GetComponent<CircleCollider2D>().enabled = true;
                playerRightHand.GetComponent<CircleCollider2D>().enabled = true;
                playerChest.GetComponent<BoxCollider2D>().enabled = true;
                playerLeftLeg.GetComponent<BoxCollider2D>().enabled = true;
                playerRightLeg.GetComponent<BoxCollider2D>().enabled = true;
                playerLeftLowArm.GetComponent<BoxCollider2D>().enabled = true;
                playerRightLowArm.GetComponent<BoxCollider2D>().enabled = true;
                playerLeftUpArm.GetComponent<BoxCollider2D>().enabled = true;
                playerRightUpArm.GetComponent<BoxCollider2D>().enabled = true;
                playerHips.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if(isOnGround && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
