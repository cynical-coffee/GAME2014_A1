using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float fMoveSpeed;
    private Vector2 vInput;
    private Rigidbody2D mRigidbody2D;
    private Animator mAnimator;

    void Start()
    {
        mRigidbody2D = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mAnimator.SetBool("IsMoving", false);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        mAnimator.SetBool("IsMoving", true);
        vInput.x = Input.GetAxisRaw("Horizontal");
        vInput.y = Input.GetAxisRaw("Vertical");
        mRigidbody2D.velocity = new Vector2(vInput.x * fMoveSpeed, vInput.y * fMoveSpeed);
        mAnimator.SetFloat("Horizontal", vInput.x);
        mAnimator.SetFloat("Vertical", vInput.y);
        if (vInput == Vector2.zero)
        {
            mAnimator.SetBool("IsMoving", false);
        }
    }
}
