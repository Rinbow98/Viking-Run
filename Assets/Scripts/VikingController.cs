using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]

public class VikingController : MonoBehaviour
{
    [SerializeField] float MovingSpeed;
    [SerializeField] float JumpingForce;

    CharacterController characterController;
    Rigidbody rigidbody;
    Animator animator;

    bool isIdle = true;
    bool onGround = true;
    bool run = true;
    bool jump = false;
    bool right = false;
    bool left = false;
    float rotateTimer = 0f;

    Transform ground = null;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rotateTimer = Time.time;
    }

    void Update()
    {
        Vector3 lastPosition = transform.position;
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

        if (Mathf.Abs(transform.position.x - ground.position.x) < 0.1f && Mathf.Abs(transform.position.z - ground.position.z) < 0.1f)
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
        
        animator.SetBool("Run", run);
        animator.SetBool("Jump", jump);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            onGround = false;
        }
        else if (collision.gameObject.name.Equals("fence_01(Clone)"))
        {
            run = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            jump = false;
            onGround = true;
            ground = collision.transform;
            if (ground.parent.name == "left_road(Clone)" || ground.parent.name == "right_road(Clone)" || ground.parent.name == "module_02_tile_02_ac Variant(Clone)")
                ground = ground.parent;
            else if (ground.parent.parent.name == "left_road(Clone)" || ground.parent.parent.name == "right_road(Clone)")
                ground = ground.parent.parent;
        }
        else if (collision.gameObject.name.Equals("fence_01(Clone)"))
        {
            run = false;
        }
    }

}
