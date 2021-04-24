using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Cont : MonoBehaviour
{

    public GameObject ship_chamber;
    public float zAngle = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(RandomGen(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove > 0)
        {
            ship_chamber.transform.Rotate(0, 0, zAngle, Space.Self);
        }
        else if (horizontalMove < 0) {
            ship_chamber.transform.Rotate(0, 0, -zAngle, Space.Self);
        }
    }

    IEnumerator RandomGen(float time) {
        yield return new WaitForSeconds(time);
        float speedRot;
        float timeRot;

        speedRot = UnityEngine.Random.Range(-1.0f, 1.0f);
        timeRot = UnityEngine.Random.Range(1.0f, 4.0f);
        Debug.Log(speedRot);
        zAngle = speedRot;
        StartCoroutine(RandomGen(timeRot));
    }
}

