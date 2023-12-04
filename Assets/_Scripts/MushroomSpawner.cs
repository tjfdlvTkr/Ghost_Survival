using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // 스폰할 몬스터들의 프리팹 배열
    public float spawnInterval = 3f; // 몬스터 스폰 간격
    public float spawnRadius = 3f; // 스폰 위치 반경

    private void Start()
    {
        // 시작하면 일정 시간마다 몬스터를 생성하는 코루틴 시작
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            if (!GameManager.instance.isGameover) {
                yield return new WaitForSeconds(spawnInterval);

                // 스폰 위치를 스포너의 위치 주변으로 랜덤하게 설정
                Vector2 randomSpawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

                // 몬스터 프리팹 배열에서 랜덤하게 몬스터를 선택하여 생성
                GameObject randomMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
                Instantiate(randomMonsterPrefab, randomSpawnPos, Quaternion.identity);
            }

        }
    }
}
