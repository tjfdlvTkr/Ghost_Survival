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

        if (horizontalInput > 0)
        {
            animator.SetFloat("Direction", 1f); // ������ ���� �ִϸ��̼�
        }
        else if (horizontalInput < 0)
        {
            animator.SetFloat("Direction", -1f); // ���� ���� �ִϸ��̼�
        }
        else if (verticalInput > 0)
        {
            animator.SetFloat("Direction", 2f); // ���� ���� �ִϸ��̼�
        }
        else if (verticalInput < 0)
        {
            animator.SetFloat("Direction", -2f); // �Ʒ��� ���� �ִϸ��̼�
        }
        else
        {
            // �÷��̾ ���� ���� ���� �ִϸ��̼��� �����մϴ�.
            animator.SetFloat("Direction", 0f);
        }

    }
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    
}