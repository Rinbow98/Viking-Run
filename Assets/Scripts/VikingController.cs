using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

public class VikingController : MonoBehaviour
{
    [SerializeField] float MovingSpeed;
    [SerializeField] float JumpingForce;

    CharacterController characterController;
    Rigidbody rigidbody;
    Animator animator;
    NavMeshAgent meshAgent;

    Vector3 movedirection;
    float horizontalInput;
    float verticalInput;

    bool isIdle = true;
    bool onGround = false;
    bool run = false;
    bool jump = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.updatePosition = false;
        onGround = true;
    }

    void Update()
    {
        run = false;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += MovingSpeed * Time.deltaTime * Vector3.forward;
            run = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += MovingSpeed * Time.deltaTime * Vector3.back;
            run = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += MovingSpeed * Time.deltaTime * Vector3.right;
            run = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += MovingSpeed * Time.deltaTime * Vector3.left;
            run = true;
        }

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rigidbody.AddForce(JumpingForce * Time.deltaTime * Vector3.up);
            jump = true;
        }
        
        animator.SetBool("Run", run);
        animator.SetBool("Jump", jump);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " Exit " + onGround);
        
        onGround = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            onGround = true;
            jump = false;
        }
    }

}
