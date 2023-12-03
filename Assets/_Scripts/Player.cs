using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public int maxHealth = 100; // 플레이어의 최대 체력
    private int currentHealth; // 현재 체력

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform balsa;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth; // 시작 시 최대 체력으로 초기화
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        
        Vector3 movement = new Vector3(horizontalInput, verticalInput,0f) * moveSpeed * Time.deltaTime; 
        transform.Translate(movement);

       
        if (horizontalInput > 0)
        {
            animator.SetFloat("DirectionX", 1f); 
        }
        else if (horizontalInput < 0)
        {
            animator.SetFloat("DirectionX", -1f); 
        }
        else
        {
            animator.SetFloat("DirectionX", 0f);
        }

        if (verticalInput > 0)
        {
            animator.SetFloat("DirectionY", 1f);
        }
        else if (verticalInput < 0)
        {
            animator.SetFloat("DirectionY", -1f);
        }
        else
        {
            animator.SetFloat("DirectionY", 0f);
        }
        Shoot();
    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    void Shoot()
    {
        Vector3 shootingDirection = new Vector3(animator.GetFloat("DirectionX"), animator.GetFloat("DirectionY"), 0f).normalized;

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastShotTime > shootInterval)
            {
                if (shootingDirection != Vector3.zero)
                {
                    float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    Instantiate(weapon, balsa.position, rotation);
                    lastShotTime = Time.time;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            // 몬스터와 충돌 시 피해를 입습니다.
            TakeDamage(10); // 예시로 10의 피해 입힘
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage; // 피해만큼 체력 감소

        if (currentHealth <= 0)
        {
            // 플레이어가 사망했을 때의 로직 추가 가능
            Debug.Log("Player died!");
        }
    }
}
