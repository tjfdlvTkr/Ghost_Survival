using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public Animator animator;
    void Start()
    {
        // ���� ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ�� Animator ������Ʈ�� �����ͼ� �Ҵ�
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // ���� �̵� �Է� (��, ��)
        float verticalInput = Input.GetAxis("Vertical"); // ���� �̵� �Է� (��, ��)

        Vector3 movement = new Vector3(horizontalInput, verticalInput,0f) * moveSpeed * Time.deltaTime; // �̵� ���� ���
        transform.Translate(movement); // �÷��̾� �̵�

        // 상하좌우 방향에 따라 애니메이션 실행
        if (horizontalInput > 0)
        {
            animator.SetFloat("DirectionX", 1f); // 오른쪽 방향 애니메이션
        }
        else if (horizontalInput < 0)
        {
            animator.SetFloat("DirectionX", -1f); // 왼쪽 방향 애니메이션
        }
        else
        {
            animator.SetFloat("DirectionX", 0f);
        }

        if (verticalInput > 0)
        {
            animator.SetFloat("DirectionY", 1f); // 위쪽 방향 애니메이션
        }
        else if (verticalInput < 0)
        {
            animator.SetFloat("DirectionY", -1f); // 아래쪽 방향 애니메이션
        }
        else
        {
            animator.SetFloat("DirectionY", 0f);
        }
    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
       
}