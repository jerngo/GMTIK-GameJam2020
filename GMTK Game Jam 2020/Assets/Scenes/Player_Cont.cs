using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Cont : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;
    public float jumpForce = 10f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool checkpoint = false;
    public float xAxis;
    public float yAxis;
    public float zAxis;
    public GameObject checkPoint;

    GameObject cam;
    public void updateAxis()
    {
        checkpoint = true;
        xAxis = this.transform.position.x;
        yAxis = this.transform.position.y;
        zAxis = this.transform.position.z;

    }

    public void ResetPosition()
    {
        beAlive();
        this.transform.position = checkPoint.transform.position;
    }

    void beAlive() {
        isDead = false;
        aliveEyes.SetActive(true);
        deadEyes.SetActive(false);
    }

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        beAlive();
        StartCoroutine(blinking());
    }

    IEnumerator blinking() {
        yield return new WaitForSeconds(5);
        aliveEyes.GetComponent<Animator>().SetTrigger("Blink");
        StartCoroutine(blinking());
    }

    // Update is called once per frame
    void Update()
    {

       // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //if (Input.GetButtonDown("Jump"))
        //{
         //   jump = true;
        //}

        //if (Input.GetButtonDown("Crouch"))
        //{
       //     crouch = true;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
        //    crouch = false;
       // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HardStuff") {
            this.GetComponent<Animator>().SetBool("Bounce",true);
           // this.GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HardStuff")
        {
            this.GetComponent<Animator>().SetBool("Bounce", false);
            this.GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        Physics2D.gravity = -cam.transform.up * 9.82f;
        // Move our character
        // controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        //jump = false;
        // Move();
        //Jump();
        // Debug.Log(horizontalMove);
    }

    void Move()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        this.transform.Translate(horizontalAxis * runSpeed * Time.fixedDeltaTime, 0, 0);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Rigidbody2D rgbd = GetComponent<Rigidbody2D>();
            rgbd.AddForce(transform.up * jumpForce);
            

        }
    }

    public GameObject aliveEyes;
    public GameObject deadEyes;

    bool isDead;
    public void Dead(int sceneIndex) {
        if (!isDead) {
            this.GetComponent<AudioManager>().Play("Dead");

        }
        deadEyes.SetActive(true);
        aliveEyes.SetActive(false);
        isDead = true;
        StartCoroutine(DeadAnim(sceneIndex));
    }

    IEnumerator DeadAnim(int sceneIndex) {
        yield return new WaitForSeconds(3);

        if (checkpoint == false)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            ResetPosition();
        }
    }
}

