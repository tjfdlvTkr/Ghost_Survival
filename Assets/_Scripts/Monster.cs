using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    private Animator animator;

    public float speed;

    public float health;
    public float maxHealth;
    public RuntimeAnimatorController animController;
    public Rigidbody2D target;

    Vector2 direction;

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
        direction = dirVec.normalized;  // 움직이는 방향을 계산하여 저장합니다.
        Vector2 nextVec = direction * speed * Time.fixedDeltaTime;
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
        anim.runtimeAnimatorController = animController;
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

        // 움직이는 방향에 따라 애니메이션 상태를 변경합니다.
        animator.SetBool("UP", direction.y > 0);
        animator.SetBool("Down", direction.y < 0);
        animator.SetBool("Right", direction.x > 0);
        animator.SetBool("Left", direction.x < 0);
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
