using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    private Animator animator;

    private float detectionRange = 5f;
    private float attackRange = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= attackRange)
        {
            // 거리가 2칸 이하로 가까워지면 공격 애니메이션을 재생합니다.
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
        }
        else if (distance <= detectionRange)
        {
            // 거리가 5칸 이하로 가까워지면 달리기 애니메이션을 재생합니다.
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            // 그 외의 경우에는 모든 애니메이션을 중지합니다.
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }
    }
}

