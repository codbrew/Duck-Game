using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour
{
    public float playerSpeed = 4f;
    public Animator animator;

    //private float _verticalMoveInput;
    private float _horizontalMoveInput;

    private bool _walkingDiagonal;
    public Transform leftBound;
    public Transform rightbound;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

            GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;
        //_verticalMoveInput = Input.GetAxisRaw("Vertical");
  
        _horizontalMoveInput = Input.GetAxisRaw("Horizontal");



        if (_horizontalMoveInput < 0 && transform.position.x > leftBound.position.x)
        {
            if (transform.position.x > leftBound.position.x)
            {
                animator.SetBool("WalkingLeft", true);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
        }

        else if (_horizontalMoveInput > 0)
        {
            if (transform.position.x < rightbound.position.x)
            {
                animator.SetBool("WalkingLeft", true);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }

        }
        else
        {
            animator.SetBool("WalkingLeft", false);
        }

    }
}
