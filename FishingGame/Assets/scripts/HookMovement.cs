using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookMovement : MonoBehaviour
{
    public GameHandler gameHandlerObj;

    private float horizontal;
    private float startrotation;
    private float max_rot;
    private float speed = 8f;
    public float jumpingPower = 4f;
    public float total_fish_weight_held = 0f;
    public float num_fish_held = 0f;
    public float num_fish_common_held = 0f;
    public float num_fish_3_held = 0f;
    public float num_fish_5_held = 0f;
    float total_fish_held = 0f;

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
            num_fish_held += 1;
            total_fish_held += 1;
        }
        else if (other.gameObject.tag == "fish_common")
        {
            hasFish = true;
            num_fish_common_held += 1;
            total_fish_held += 1;
        }
        else if (other.gameObject.tag == "fish_3")
        {
            hasFish = true;
            num_fish_3_held += 1;
            total_fish_held += 1;
        }
        else if (other.gameObject.tag == "fish_5")
        {
            hasFish = true;
            num_fish_5_held += 1;
            total_fish_held += 1;
        }
        //if (other.gameObject.tag == "waterTop" && hasFish)
        //{
        //    SceneManager.LoadScene("boat");
        //}
        if (other.gameObject.tag == "boot")
        {
            // if (PlayerPrefs.GetFloat("FishingSessionsRemaining") > 1)
            // {
            //     PlayerPrefs.SetFloat("FishingSessionsRemaining", PlayerPrefs.GetFloat("FishingSessionsRemaining") - 1);
            // }
            // else
            // {
            //     Debug.Log("You have fished the maximum number of times! You Lose!");
            //     Application.Quit();
            // }
            rb.velocity = new Vector2(rb.velocity.x, 4.75f);
            gameHandlerObj.boatError();
            // SceneManager.LoadScene("boat");
        }
    }


    // Update is called once per frame
    void Update()
    {
       

        float total_fish_weight_held = 0.5f * num_fish_common_held + 0.75f * num_fish_held + 1.5f * num_fish_3_held + 1.75f * num_fish_5_held;
        float fish_on_hook_max = PlayerPrefs.GetFloat("RodLevel") + 4;
        
        if (total_fish_held > fish_on_hook_max) {
            Debug.Log("total fish is: " + total_fish_held.ToString("R"));
            Debug.Log("max fish hook is: " + fish_on_hook_max.ToString("R"));
            
            rb.velocity = new Vector2(rb.velocity.x, 4.75f);
            gameHandlerObj.fishError();
            // SceneManager.LoadScene("boat");  
        }
            
        horizontal = Input.GetAxisRaw("Horizontal");

        if (hasFish)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f/(Mathf.Sqrt(1 + total_fish_weight_held)));
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
