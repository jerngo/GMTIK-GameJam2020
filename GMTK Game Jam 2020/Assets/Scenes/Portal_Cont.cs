﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            //this.GetComponent<AudioManager>().Play("Teleport");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
