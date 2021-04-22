using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public AudioSource click;
    bool doorIsOpen = false;
    public GameObject doorObject;
    public OpenDoor doorFunction;
    public float startPosition;

    // Update is called once per frame
    void Start()
    {
        doorObject.GetComponent<BoxCollider2D>().enabled = true;
        startPosition = transform.position.y;
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x,0.25f,0);
        this.transform.position = new Vector3(this.transform.position.x, startPosition - 0.125f, 0);

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
        this.transform.localScale = new Vector3(this.transform.localScale.x, 0.5f, 0);
        this.transform.position = new Vector3(this.transform.position.x, startPosition, 0);

        doorIsOpen = false;
        if (doorIsOpen == false)
        {
            doorFunction.gameObject.GetComponent<SpriteRenderer>().sprite = doorFunction.closeDoor;
            doorFunction.closeSound.Play();
            doorObject.GetComponent<BoxCollider2D>().enabled = true;

        }
    }
}