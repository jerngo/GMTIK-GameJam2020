using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour
{
    public GameObject cam;
    public float zAngle = 0.5f;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        //float horizontalMove = Input.acceleration.x;

         if (horizontalMove > 0)
         {
          cam.transform.Rotate(0, 0, zAngle, Space.Self);
        //  cam.transform.Rotate(0, 0, zAngle * Mathf.Clamp(horizontalMove, -5, 5), Space.Self);
        }
         else if (horizontalMove < 0)
         {
          cam.transform.Rotate(0, 0, -zAngle, Space.Self);
        }


    }
}
