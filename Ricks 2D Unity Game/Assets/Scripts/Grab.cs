using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool hold;
    public KeyCode mouseButton;
    //public Rigidbody2D blnrb;
    public bool holdingBalloon = false;
    public GameObject holdingObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(mouseButton))
        {
            hold = true;
        }
        else
        {
            hold = false;
            holdingBalloon = false;
            holdingObject = null;
            Destroy(GetComponent<FixedJoint2D>());
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (hold && holdingObject == null)
        {
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                fj.connectedBody = rb;
                holdingObject = transform.gameObject;
            }
        }
        if (col.transform.tag == "Balloon" && hold)
        {
            holdingBalloon = true;
        }
    }
}
