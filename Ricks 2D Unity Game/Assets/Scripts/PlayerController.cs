using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpForce;
    public Vector2 jumpHeight;
    private bool isOnGround;

    public float playerSpeed;
    public float FlyingSpeed;

    public float positionRadius;
    public LayerMask ground;
    public Transform playerPos;

    public bool gravityToggle;
    private bool noClipToggle;

    public GameObject rightHand;
    public GameObject leftHand;

    public GameObject[] bodyParts = new GameObject[9];

    public GameObject[] balanceScript = new GameObject[2];

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
        gravityToggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SpecialKeys();
        CheckNoClip();
        CheckGravity();
        Jump();
        BalloonFloat();

    }
    private void Movement()
    {
        int vertical = (int)Input.GetAxis("Vertical");
        int horizontal = (int)Input.GetAxis("Horizontal");
        if (gravityToggle)//if flying off (standard = off)
        {
            if (Input.GetKey(KeyCode.LeftShift) && horizontal > 0)//if right
            {
                Debug.Log("right");
                rb.AddForce(Vector2.right * playerSpeed / 3 * Time.deltaTime * horizontal);

                for (int i = 0; i < balanceScript.Length; i++)//crawling movements to left
                {
                    balanceScript[i].GetComponent<Balance>().targetRotation = 60;
                }
            }else
            if (Input.GetKey(KeyCode.LeftShift) && horizontal < 0)//if left
            {
                Debug.Log("left");
                rb.AddForce(Vector2.right * playerSpeed / 3 * Time.deltaTime * horizontal);

                for (int i = 0; i < balanceScript.Length; i++)//crawling movements to left
                {
                    balanceScript[i].GetComponent<Balance>().targetRotation = -60;
                }
            }
            else if(Input.GetKey(KeyCode.LeftShift))
            {
                for (int i = 0; i < balanceScript.Length; i++)//crawling movements normal
                {
                    balanceScript[1].GetComponent<Balance>().targetRotation = 90;
                    balanceScript[2].GetComponent<Balance>().targetRotation = -90;
                }
            }
            else
            {
                for (int i = 0; i < balanceScript.Length; i++)//crawling movements normal
                {
                    rb.AddForce(Vector2.right * playerSpeed * Time.deltaTime * horizontal);
                    balanceScript[i].GetComponent<Balance>().targetRotation = 0;
                }
            }
        }
        else //if flying on
        {
            rb.AddForce(Vector2.right * FlyingSpeed * 100 * Time.deltaTime * horizontal);
            rb.AddForce(Vector2.up * FlyingSpeed * 100 * Time.deltaTime * vertical);
        }
    }
    private void SpecialKeys()
    {
        if (Input.GetKeyUp(KeyCode.F4))
        {
            gravityToggle = !gravityToggle;
        }
        if (Input.GetKeyUp(KeyCode.F10))
        {
            noClipToggle = !noClipToggle;
            gravityToggle = !gravityToggle;
        }
    }
    private void CheckNoClip()
    {
        if (noClipToggle)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<BoxCollider2D>().enabled = false;
                bodyParts[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.2f);
            }
            rightHand.GetComponent<CircleCollider2D>().enabled = false;
            leftHand.GetComponent<CircleCollider2D>().enabled = false;
        }
        else
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<BoxCollider2D>().enabled = true;
                bodyParts[i].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
            }
            rightHand.GetComponent<CircleCollider2D>().enabled = true;
            leftHand.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    private void CheckGravity()
    {
        if (gravityToggle)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {
                bodyParts[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            rightHand.GetComponent<Rigidbody2D>().gravityScale = 1;
            leftHand.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else
        {
            DisableGravity();
            rightHand.GetComponent<Rigidbody2D>().gravityScale = 0;
            leftHand.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void Jump()
    {
        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if (isOnGround && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void BalloonFloat()
    {
        if (leftHand.GetComponent<Grab>().holdingBalloon)
        {
            leftHand.GetComponent<Rigidbody2D>().gravityScale = -1;
            rightHand.GetComponent<Rigidbody2D>().gravityScale = 0;
            DisableGravity();
        }
        else
        if (rightHand.GetComponent<Grab>().holdingBalloon)
        {
            rightHand.GetComponent<Rigidbody2D>().gravityScale = -1;
            leftHand.GetComponent<Rigidbody2D>().gravityScale = 0;
            DisableGravity();
        }
        else if(rightHand.GetComponent<Grab>().holdingBalloon && leftHand.GetComponent<Grab>().holdingBalloon)
        {
            rightHand.GetComponent<Rigidbody2D>().gravityScale = -0.5f;
            leftHand.GetComponent<Rigidbody2D>().gravityScale = -0.5f;
            DisableGravity();
        }
    }
    private void DisableGravity()
    {
        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}