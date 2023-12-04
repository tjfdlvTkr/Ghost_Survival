using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int direction;
    
    protected new Rigidbody2D rigidbody2D;
    protected Animator animator;
    protected CircleCollider2D circleCollider;

    private bool isDead;

    private EnemyMove movedirection;


    void Start()
    {
        movedirection = GetComponent<EnemyMove>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        Vector2Int direction = movedirection.getMovedirection();
        float moveX = direction.x;
        float moveY = direction.y;

        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
    }



    public void onDamaged()
    {
        GameManager.instance.AddScore(1);
        Destroy(gameObject);
    }
}
