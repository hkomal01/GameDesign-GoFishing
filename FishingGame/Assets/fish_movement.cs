using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_movement : MonoBehaviour
{
    public float fish_speed = 5;
    public Rigidbody2D fish;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = -1;
        movement.y = 0;
    }

    void FixedUpdate()
    {
        if (fish.position.x + movement.x < -9)
        {
            movement.x = 16;
            fish.MovePosition(movement);

        } else {
            fish.MovePosition(fish.position + movement * fish_speed * Time.fixedDeltaTime);
        }
    }
}
