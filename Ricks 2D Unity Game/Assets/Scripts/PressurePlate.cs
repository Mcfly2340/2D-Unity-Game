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

    // Update is called once per frame
    void Start()
    {
        //Check if the isTrigger option on the Collider2D is set to true or false
        /*
        if (coll.isTrigger)
        {
            Debug.Log("This Collider2D can be triggered");
        }
        else if (!coll.isTrigger)
        {
            Debug.Log("This Collider2D cannot be triggered");
        }
        */
        coll = GetComponent<Collider2D>();
        doorObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Pressure Plate down");

        transform.position = new Vector3(3.5f, -4.3f, 0);
        doorIsOpen = true;
        if (doorIsOpen == true)
        {
            doorFunction.gameObject.GetComponent<SpriteRenderer>().sprite = doorFunction.openDoor;
            doorFunction.openSound.Play();
            Debug.Log("door opened");
            coll.isTrigger = true;
            OnTriggerStay2D(other);
            doorObject.GetComponent<BoxCollider2D>().enabled = false;

        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        //click.Stop();
        doorIsOpen = false;
        if (doorIsOpen == false)
        {
            doorFunction.gameObject.GetComponent<SpriteRenderer>().sprite = doorFunction.closeDoor;
            doorFunction.closeSound.Play();
            Debug.Log("door closed");
            OnTriggerStay2D(other);
            doorObject.GetComponent<BoxCollider2D>().enabled = true;

        }
        transform.Translate(Vector3.up * 0.1f);
        transform.position = new Vector3(3.5f, -4.1f, 0);
        Debug.Log("Pressure Plate up");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //
    }
}