using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookMovement : MonoBehaviour
{
    private float horizontal;
    private float startrotation;
    private float max_rot;
    private float speed = 8f;
    public float jumpingPower = 4f;
    public Rigidbody2D rb;
    [SerializeField] private float rotationSpeed;

    private bool hasFish = false;
    

    private void Start()
    {
        startrotation = transform.localEulerAngles.z;
        max_rot = 45f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fish")
        {
            hasFish = true;
        }
        if (other.gameObject.tag == "waterTop" && hasFish)
        {
            SceneManager.LoadScene("boat");
        }
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (hasFish)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        
    }



    private void FixedUpdate()
    {
        float twist;
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Vector2 movementDirection = new Vector2(horizontal, 0);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection * -1);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }
        twist = Mathf.DeltaAngle(startrotation, transform.localEulerAngles.z);
        if(twist > max_rot)
        {
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, max_rot);
        }
        if (twist < -max_rot)
        {
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -max_rot);
        }

    }
}
