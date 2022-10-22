using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootMovement : MonoBehaviour
{
    public float boot_speed = 5;
    public GameObject hook;
    public Rigidbody2D boot;

    
    private Vector2 movement;
    private Vector3 flip;
    private float rotate;
    // Update is called once per frame
    void Start()
    {
        rotate = 45f;

        movement.x = -1;
        movement.y = 0;

        flip.x = boot.transform.localScale.x;
        flip.y = boot.transform.localScale.y;
        flip.z = 1;

    }

    void FixedUpdate()
    {
        boot.MovePosition(boot.position + movement * boot_speed * Time.fixedDeltaTime);
        boot.transform.Rotate(0, 0, rotate * Time.deltaTime);
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            // Debug.Log("Fish on wall");

            movement.x = movement.x * -1;

            //flip.x = flip.x * -1;
            rotate = rotate * -1;
            //boot.transform.localScale = flip;
        }
        else if (other.gameObject.tag == "hook")
        {
            Debug.Log("Boot Hooked");
            // Debug.Log("FISH name IS: " + fish.gameObject.name);

            
        }
    }


}
