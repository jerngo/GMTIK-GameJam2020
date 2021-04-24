using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Cont : MonoBehaviour
{
    public int sceneIndex;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //this.GetComponent<AudioManager>().Play("Teleport");
            collision.gameObject.GetComponent<Player_Cont>().Dead(sceneIndex);
            //collision.gameObject.GetComponent<Player_Cont>().ResetPosition();
        }
    }
}
