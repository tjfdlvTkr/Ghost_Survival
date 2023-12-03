using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public GameObject player;
    private Animator animator;

    private float detectionRange = 5f;
    private float attackRange = 2f;

    public float speed;

    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    [System.Serializable]
    public class SpawnData
    {
        public int spriteType;
        public float speed = 10f;
        public float health = 50;
        // 필요한 다른 데이터들을 추가로 정의할 수 있습니다.
    }

    bool isLive;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isLive)
        {
            return;
        }

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

    void LateUpdate()
    {
        if (!isLive)
        {
            return;
        }
        spriter.flipX = target.position.x < rigid.position.x;
    }

   
    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
        else if (distance <= detectionRange)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon"))
            return;

        health -= collision.GetComponent<Weapon>().damage;

        if (health > 0)
        {
            // 몬스터의 피격 처리 로직을 추가해야 합니다.
        }
        else
        {
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}