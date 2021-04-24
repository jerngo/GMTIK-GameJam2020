using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            this.GetComponent<Animator>().SetTrigger("Press");
            door.GetComponent<Animator>().SetTrigger("Open 0");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
