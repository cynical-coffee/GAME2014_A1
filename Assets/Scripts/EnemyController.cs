using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject mPlayer;
    [SerializeField] private float fMovementRange;
    [SerializeField] private float fRange;
    [SerializeField] private int iHealth;
    private Vector3 vStartingPoint;
    private PlayerController mPlayerController;


    void Start()
    {
        mPlayerController = mPlayer.gameObject.GetComponent<PlayerController>();
        vStartingPoint = transform.position;
    }

    void Update()
    {
        Wander();
    }

    void Wander()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, fMovementRange) + vStartingPoint.x,
            transform.position.y);
        DetectPlayer();
    }

    void DetectPlayer()
    {
        Vector2 vPlayerPosition = new Vector2(mPlayer.transform.position.x, mPlayer.transform.position.y);
        if (Vector2.Distance(mPlayer.transform.position, transform.position) <= fRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, vPlayerPosition, 3 * Time.deltaTime);
        }
    }

    void Attack()
    {
        mPlayerController.DealtDamage(3);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == mPlayer)
        {
            //TODO: Attack();
            //Attack();
            Debug.Log("Collision");
        }
    }

    public void DealtDamage(int iDamage)
    {
        iHealth -= iDamage;
    }

}
