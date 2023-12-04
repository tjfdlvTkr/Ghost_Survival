using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject weaponPrefab;
    private Transform firePoint;
    private float shootInterval = 0.5f;
    private float lastShotTime = 0f;

    public float moveSpeed = 5f;
    public Animator animator;
    protected new Rigidbody2D rigidbody;
    protected BoxCollider2D boxCollider;

    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isGameover) return;

        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.z = 0f;
        Vector3 shootingDirection = direction.normalized;

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

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot(shootingDirection);
        }
    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    void Shoot(Vector3 direction)
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Instantiate(weaponPrefab, transform.position + direction * 0.5f, rotation);
            audio.Play();
            lastShotTime = Time.time;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.OnPlayerDead();
        }
    }
}
