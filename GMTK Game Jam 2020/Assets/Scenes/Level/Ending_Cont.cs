using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Rocket;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Text1;



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Camera1.SetActive(false);
            Player1.SetActive(false);
            Player2.SetActive(true);
            Camera2.SetActive(true);
            Rocket.GetComponent<Animator>().SetBool("Fly", true);
            Door1.GetComponent<Animator>().SetTrigger("Open 0");
            Door2.GetComponent<Animator>().SetTrigger("Open 0");
            Text1.SetActive(true);
        }
    }
}
