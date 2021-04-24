using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint_Cont : MonoBehaviour
{

    public bool CloseDoor;
    public GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<Player_Cont>().updateAxis();
            collision.gameObject.GetComponent<Player_Cont>().checkPoint = this.gameObject;

            Debug.Log("Catch");
            if (CloseDoor == true)
            {
                Door.GetComponent<Animator>().SetTrigger("Close 0");
            }
        }
    }
}
