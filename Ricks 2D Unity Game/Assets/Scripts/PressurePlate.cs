using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public AudioSource click;
    bool doorIsOpen = false;
    public GameObject doorObject;
    public OpenDoor doorFunction;
    public Collider2D coll;
    public Animator anim;

    // Update is called once per frame
    void Start()
    {
        //coll = GetComponent<Collider2D>();
        doorObject.GetComponent<BoxCollider2D>().enabled = true;
        //anim.enabled = false;
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (coll.gameObject.CompareTag("Boxes")){
            Debug.Log("Boxes");
        }
        anim.Play("PressurePlateDown");
        doorIsOpen = true;
        if (doorIsOpen == true)
        {
            doorFunction.gameObject.GetComponent<SpriteRenderer>().sprite = doorFunction.openDoor;
            doorFunction.openSound.Play();
            doorObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        anim.Play("PressurePlateUp");

        doorIsOpen = false;
        if (doorIsOpen == false)
        {
            doorFunction.gameObject.GetComponent<SpriteRenderer>().sprite = doorFunction.closeDoor;
            doorFunction.closeSound.Play();
            doorObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        //transform.Translate(Vector3.up * 0.1f);
        //transform.Translate(0, 0.1f, 0, Space.Self);
    }
}