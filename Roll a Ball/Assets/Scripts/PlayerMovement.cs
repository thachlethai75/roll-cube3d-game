using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float forwardSpeed = 2400f;
    private float sideSpeed = 20f;
    private bool isGrounded = true;
    private float buffTimer;
    private bool isBooting;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        buffTimer = 0;
        isBooting = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardSpeed * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * sideSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * sideSpeed;

        transform.Translate(horizontal, 0, vertical);

        //   if(Input.GetKey("d"))
        //   {
        //       rb.AddForce(sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //   }

        //   if(Input.GetKey("a"))
        //   {
        //       rb.AddForce(-sideSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        //   }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (isBooting)
        {
            buffTimer += Time.deltaTime;
            if (buffTimer >= 3)
            {
                forwardSpeed = 2400f;
                buffTimer = 0;
                isBooting = false;
            }
        }
        Debug.Log(forwardSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speedboot")
        {
            isBooting = true;
            forwardSpeed = 4000f;
            Destroy(other.gameObject);
        }
        if(other.tag == "Jumpboot")
        {
            isBooting = true;
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
