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

        

        if (_horizontalMoveInput < 0)
        {
            animator.SetBool("WalkingLeft", true);
        }
        else
        {
            animator.SetBool("WalkingLeft", false);
        }

        if (_horizontalMoveInput > 0)
        {
            animator.SetBool("WalkingRight", true);
        }
        else
        {
            animator.SetBool("WalkingRight", false);
        }
    }
}
