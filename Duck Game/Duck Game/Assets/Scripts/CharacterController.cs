using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour
{
    public float playerSpeed = 4f;
    //public Animator animator;

    //private float _verticalMoveInput;
    private float _horizontalMoveInput;

    private bool _walkingDiagonal;

    public void Start()
    {
        //animator = GetComponent<Animator>();
    }
    public void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        GetComponent<Rigidbody2D>().velocity = targetVelocity * playerSpeed;
        //_verticalMoveInput = Input.GetAxisRaw("Vertical");
        _horizontalMoveInput = Input.GetAxisRaw("Horizontal");

        /*if ((_verticalMoveInput < 0 && _horizontalMoveInput < 0) || (_verticalMoveInput < 0 && _horizontalMoveInput > 0)|| (_verticalMoveInput > 0 && _horizontalMoveInput > 0) || (_verticalMoveInput > 0 && _horizontalMoveInput < 0))
            _walkingDiagonal = true;
        else
            _walkingDiagonal = false;

        if ((_verticalMoveInput < 0) || (_verticalMoveInput < 0 && _horizontalMoveInput < 0) || (_verticalMoveInput < 0 && _horizontalMoveInput > 0))
        {
            animator.SetBool("WalkingForward", true);
        }
        else
        {
            animator.SetBool("WalkingForward", false);
        }

        if ((_verticalMoveInput > 0)|| (_verticalMoveInput > 0 && _horizontalMoveInput > 0)|| (_verticalMoveInput > 0 && _horizontalMoveInput < 0))
        {
            animator.SetBool("WalkingBackward", true);
        }
        else
        {
            animator.SetBool("WalkingBackward", false);
        }

        if (_horizontalMoveInput < 0 && _walkingDiagonal == false)
        {
            animator.SetBool("WalkingLeft", true);
        }
        else
        {
            animator.SetBool("WalkingLeft", false);
        }

        if (_horizontalMoveInput > 0 && _walkingDiagonal == false)
        {
            animator.SetBool("WalkingRight", true);
        }
        else
        {
            animator.SetBool("WalkingRight", false);
        }*/
    }
}
