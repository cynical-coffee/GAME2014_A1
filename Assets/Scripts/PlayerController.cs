using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float fMoveSpeed;
    [SerializeField] private int iHealth;
    [SerializeField] private int iDamage;
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
        if (Input.touchCount > 0)
        {
            Touch mTouch = Input.GetTouch(0);
            Vector2 vTouchPosition = Camera.main.ScreenToWorldPoint(mTouch.position);
            float fTouchX = vTouchPosition.x;
            float fTouchY = vTouchPosition.y;
            switch (mTouch.phase)
            {
                case TouchPhase.Began:
                    if (math.abs(fTouchY) > math.abs(fTouchX))
                    {
                        if (fTouchY > 0)
                        {
                            vInput = new Vector2(0, 1);
                            mRigidbody2D.velocity = vInput * fMoveSpeed;
                        }
                        if (fTouchY < 0)
                        {
                            vInput = new Vector2(0, -1);
                            mRigidbody2D.velocity = vInput * fMoveSpeed;
                        }
                    }
                    if (math.abs(fTouchX) > math.abs(fTouchY))
                    {
                        if (fTouchX > 0)
                        {
                            vInput = new Vector2(1, 0);
                            mRigidbody2D.velocity = vInput * fMoveSpeed;
                        }
                        if (fTouchX < 0)
                        {
                            vInput = new Vector2(-1, 0);
                            mRigidbody2D.velocity = vInput * fMoveSpeed;
                        }
                    }
                    mAnimator.SetBool("IsMoving", true);
                    break;
                case TouchPhase.Ended:
                    if (math.abs(fTouchX) == 0 && math.abs(fTouchY) == 0)
                    {
                        Attack();
                    }
                    vInput = new Vector2(0, 0);
                    mRigidbody2D.velocity = new Vector2(0, 0);
                    mAnimator.SetBool("IsMoving", false);
                    break;
                
            }
            mAnimator.SetFloat("Horizontal", vInput.x);
            mAnimator.SetFloat("Vertical", vInput.y);
        }
    }

    void Attack()
    {
        mAnimator.SetTrigger("Attack");
        Debug.Log("Attacked");
    }

    public void DealtDamage(int iDamage)
    {
        iHealth -= iDamage;
    }
}
