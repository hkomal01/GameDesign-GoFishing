using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{   
    public float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
    }

}

