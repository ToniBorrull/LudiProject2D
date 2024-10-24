using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Start Position")]
    public Transform startingPos;

    [Header("Basic Variables")]
    public float speed;
    public float maxSpeed;
    Rigidbody2D rb;
    public float jumpForce;

    //Raycast
    [Header("Raycast")]
    [Range(0, 2)]
    public float raycastDistance;
    public LayerMask layerMask;
    public bool grounded;

    public Vector2[] abajo;
    public Vector2[] derecha;
    public Vector2[] izquierda;

    [Header("Timer")] 
    private bool timerOn;
    private float timer;
    public float Countdown;

    bool leftObject;
    bool rightObject;


    [Header("Animator")]
    public Animator animator;
 



    // Start is called before the first frame update
    void Start()
    {
        transform.position = startingPos.position;
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Run();
        Jump();
        Timer();

        if (leftObject || rightObject)
        {
            SpeedDown();
            animator.SetBool("idle", true);
            animator.SetBool("running", false);
        }
        else
        {
            SpeedUp();
            animator.SetBool("idle", false);
            animator.SetBool("running", true);
        }

    }

    void FixedUpdate()
    {
        foreach (Vector2 p in abajo)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.up, raycastDistance, layerMask);
            //ABAJO                                                                                                        
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * raycastDistance, Color.red);
            Debug.DrawRay(transform.position + (Vector3)p, -Vector2.up * hit.distance, Color.green);

            //Ground collision
            if (hit.collider != null)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            //Parent restart
            if (hit.collider == null)
            {
                this.transform.parent = null;
            }
        }
        foreach (Vector2 p in izquierda)
        {
            RaycastHit2D hit4 = Physics2D.Raycast(transform.position + (Vector3)p, Vector2.left, raycastDistance, layerMask);

            //DERECHA
            Debug.DrawRay(transform.position + (Vector3)p, Vector2.left * raycastDistance, Color.red);
            Debug.DrawRay(transform.position + (Vector3)p, Vector2.left * hit4.distance, Color.green);
            if (hit4.collider != null)
            {
                leftObject = true;
            }
            else
            {
                leftObject = false;
            }

        }
        foreach (Vector2 p in derecha)
        {
            RaycastHit2D hit3 = Physics2D.Raycast(transform.position + (Vector3)p, -Vector2.left, raycastDistance, layerMask);
            //IZQUIERDA
            Debug.DrawRay(transform.position + (Vector3)p, Vector2.right * raycastDistance, Color.red);
            Debug.DrawRay(transform.position + (Vector3)p, Vector2.right * hit3.distance, Color.green);
            if (hit3.collider != null)
            {
                rightObject = true;
            }
            else
            {
                rightObject = false;
            }
        }
    }

    void Run()
    {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            animator.SetBool("running", true);
        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetBool("jumping", true);
            }
        }
        JumpAnimation();
    }
    void JumpAnimation()
    {
        if (!grounded)
        {
            animator.SetBool("jumping", false);
        }
        if(rb.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("idle", false);
            animator.SetBool("falling", true);
        }
        if (grounded)
        {
            animator.SetBool("falling", false);
            animator.SetBool("idle", true);
        }
    }
    void SpeedUp()
    {
        if (speed < maxSpeed)
        {
            speed += 0.2f;
        }
    }
    void SpeedDown()
    {
        speed = 0;
    }


    //Timer controller
    void Timer()
    {
        TimerCount();
        ResetTimer();
    }
    void TimerCount()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
        }
    }
    void TimerOff()
    {
        timerOn = false;

    }
    void TimerOn()
    {
        timerOn = true;
    }
    void ResetTimer()
    {
        if (timer >= Countdown)
        {
            TimerOff();
            timer = 0f;
        }
    }
}
