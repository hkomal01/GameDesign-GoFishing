using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_movement : MonoBehaviour
{
    public float fish_speed = 5;
    public GameObject hook;
    public Rigidbody2D fish;

    private bool isCaught = false;
    private Vector2 movement;
    private Vector3 flip;
    // Update is called once per frame
    void Start()
    {
        movement.x = -1;
        movement.y = 0;

        flip.x = fish.transform.localScale.x;
        flip.y = fish.transform.localScale.y;
        flip.z = 1;

    }

    void FixedUpdate()
    {
        if (!isCaught){
            fish.MovePosition(fish.position + movement * fish_speed * Time.fixedDeltaTime);
        }else{
            Vector3 pos = hook.transform.position;
            pos.z = -5;
            fish.transform.position = pos;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            
            movement.x = movement.x * -1;
            
            flip.x = flip.x * -1;
            fish.transform.localScale = flip;
        }else if (other.gameObject.tag == "hook")
        {
            Debug.Log("Fish Hooked");
            Debug.Log("FISH name IS: " + fish.gameObject.name);

            isCaught = true;
            Vector3 pos = hook.transform.position;
            pos.z = -5;
            fish.gameObject.transform.position = pos;
        }
    }


}
