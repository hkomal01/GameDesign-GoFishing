using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_movement : MonoBehaviour
{
    public float fish_speed = 5;
    public Rigidbody2D fish;
    public Rigidbody2D wall;
    //public GameHandler gameHandlerObj;

    private Vector2 movement;
    private Vector3 flip;
    // Update is called once per frame
    void Start()
    {
        movement.x = -1;
        movement.y = 0;

        flip.x = 2;
        flip.y = 2;
        flip.z = 1;

    }

    void FixedUpdate()
    {
        fish.MovePosition(fish.position + movement * fish_speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Debug.Log("Fish on wall");
            
            movement.x = movement.x * -1;
            
            flip.x = flip.x * -1;
            fish.transform.localScale = flip;
            //fish.MovePosition(fish.position + movement * fish_speed * Time.fixedDeltaTime);
        }
    }
}
