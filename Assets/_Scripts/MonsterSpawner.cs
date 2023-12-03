using System;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public int spawnRange = 10;

    private void Start()
    {
        SpawnMonster();
    }

    private void SpawnMonster()
    {
        // 랜덤한 위치 생성
        Vector3 randomPosition = new Vector3(
            UnityEngine.Random.Range(-spawnRange, spawnRange),
            0,
            UnityEngine.Random.Range(-spawnRange, spawnRange)
        );

        // 몬스터 생성
        Instantiate(monsterPrefab, randomPosition, Quaternion.identity);

        // 몬스터 생성
        Instantiate(monsterPrefab, randomPosition, Quaternion.identity);
    }
}
