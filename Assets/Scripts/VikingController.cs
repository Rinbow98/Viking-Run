using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    [SerializeField] float MovingSpeed;
    [SerializeField] float JumpingForce;

    Rigidbody rigidbody;
    Animator animator;

    bool isIdle;
    bool jump;
    bool right;
    bool left;
    bool run;
    bool onGround;
    float rotateTimer;

    Transform ground;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isIdle = true;
        jump = false;
        right = false;
        left = false;
        run = true;
        onGround = true;
        rotateTimer = Time.time;
        ground = null;
    }

    void Update()
    {
        Vector3 lastPosition = transform.position;
        if (HowToPlay.GameStart && run)
            transform.position += transform.rotation * Vector3.forward * MovingSpeed * Time.deltaTime;
        
        if (!right && !left && Time.time - rotateTimer > 0.5f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                left = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                right = true;
            }
        }

        if (ground && Mathf.Abs(transform.position.x - ground.position.x) < 0.1f && Mathf.Abs(transform.position.z - ground.position.z) < 0.1f)
        {
            if (left)
            {
                transform.position = ground.position + new Vector3(0f, transform.position.y, 0f);
                transform.Rotate(0f, -90f, 0f);
                left = false;
                rotateTimer = Time.time;
            }
            else if (right)
            {
                transform.position = ground.position + new Vector3(0f, transform.position.y, 0f);
                transform.Rotate(0f, 90f, 0f);
                right = false;
                rotateTimer = Time.time;
            }
        }

        if (Input.GetKey(KeyCode.Space) && onGround && !jump)
        {
            rigidbody.AddForce(JumpingForce * Vector3.up);
            jump = true;
        }

        if (transform.position.y < 0f)
        {
            run = false;
            onGround = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        
        animator.SetBool("Run", run);
        animator.SetBool("Jump", jump);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump = false;
            onGround = true;
            ground = collision.transform;
            if (ground.parent.name == "left_road(Clone)" || ground.parent.name == "right_road(Clone)" || ground.parent.name == "module_02_tile_02_ac Variant(Clone)")
                ground = ground.parent;
            else if (ground.parent.parent.name == "left_road(Clone)" || ground.parent.parent.name == "right_road(Clone)")
                ground = ground.parent.parent;
        }
        else if (collision.gameObject.name == "fence_01 Variant(Clone)")
        {
            if (transform.position.y <= 1)
            {
                run = false;
                onGround = false;
            }
        }
    }

}
