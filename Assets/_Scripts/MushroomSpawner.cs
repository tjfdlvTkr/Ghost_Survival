using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // ������ ���͵��� ������ �迭
    public float spawnInterval = 3f; // ���� ���� ����
    public float spawnRadius = 3f; // ���� ��ġ �ݰ�

    private void Start()
    {
        // �����ϸ� ���� �ð����� ���͸� �����ϴ� �ڷ�ƾ ����
        StartCoroutine(SpawnMonsters());
    }

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            if (!GameManager.instance.isGameover) {
                yield return new WaitForSeconds(spawnInterval);

                // ���� ��ġ�� �������� ��ġ �ֺ����� �����ϰ� ����
                Vector2 randomSpawnPos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

                // ���� ������ �迭���� �����ϰ� ���͸� �����Ͽ� ����
                GameObject randomMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
                Instantiate(randomMonsterPrefab, randomSpawnPos, Quaternion.identity);
            }

        }
    }
}
