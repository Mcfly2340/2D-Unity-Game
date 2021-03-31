using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject Door;
    public AudioSource openSound;
    public AudioSource closeSound;
    public Sprite closeDoor;
    public Sprite openDoor;

    void Start()
    {
        //anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    public void OpenDoorWithPressurePlate()
    {
        Debug.Log("this works");
    }
}