using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    public GameObject DoorWay;
    public GameObject Player;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player.transform.Translate(0, 0, 0);
        DoorWay.GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("yes");
    }
}
