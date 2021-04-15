using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool hold;
    public KeyCode mouseButton;
    public Rigidbody2D blnrb;

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
            Destroy(GetComponent<FixedJoint2D>());

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag != "Ground" && hold)
        {
            Rigidbody2D rb = col.transform.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
                fj.connectedBody = rb;
            }
            else 
            {
                FixedJoint2D fj = transform.gameObject.AddComponent(typeof(FixedJoint2D)) as FixedJoint2D;
            }
        }
        /*if (hold)
        {
            blnrb.AddForce(Physics.gravity * blnrb.mass);
        }*/
    }
}
