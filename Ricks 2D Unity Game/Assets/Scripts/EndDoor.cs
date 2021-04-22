using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDoor : MonoBehaviour
{
    public GameObject DoorWay;
    public GameObject Player;
    public Collider2D coll;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(3);
            Debug.Log("enter");
        }
    }
}
