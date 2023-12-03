using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{

    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;
    public GameObject monsterPrefab;
    public GameObject monsterPrefab2;

    // 생성된 몬스터들을 저장할 리스트
    private List<GameObject> spawnedMonsters = new List<GameObject>();
    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
            floorPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
        }
        return floorPositions;
    }
    private void SpawnMonsters(HashSet<Vector2Int> floorPositions)
    {
    // 이동 가능한 타일들의 목록을 가져옵니다.
    HashSet<Vector2Int> walkableTiles = tilemapVisualizer.GetWalkableTiles();

    // 이동 가능한 타일들 중에서 랜덤하게 하나를 선택합니다.
    Vector2Int spawnPosition = walkableTiles.ElementAt(Random.Range(0, walkableTiles.Count));
    // 선택한 위치에 몬스터 1을 스폰합니다.
    GameObject monster = Instantiate(monsterPrefab, (Vector3Int)spawnPosition, Quaternion.identity);
    spawnedMonsters.Add(monster);
    monster.AddComponent<EnemyMove>();
    monster.AddComponent<Movement2D>();
    monster.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);

    // 이동 가능한 타일들 중에서 랜덤하게 하나를 선택합니다.
    Vector2Int spawnPosition2 = walkableTiles.ElementAt(Random.Range(0, walkableTiles.Count));
    // 선택한 위치에 몬스터 2를 스폰합니다.
    monster = Instantiate(monsterPrefab2, (Vector3Int)spawnPosition2, Quaternion.identity);
    spawnedMonsters.Add(monster);
    monster.AddComponent<EnemyMove>();
    monster.AddComponent<Movement2D>();
    monster.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
    }
    public void ClearMonsters()
    {
    foreach (GameObject monster in spawnedMonsters)
     {
        DestroyImmediate(monster);
     }
    spawnedMonsters.Clear(); // 리스트를 비움
    }


    protected override void RunProceduralGeneration()
    {
    HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
    tilemapVisualizer.Clear();
    tilemapVisualizer.PaintFloorTiles(floorPositions);
    WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);

    if (spawnedMonsters.Count > 0)
    {
        ClearMonsters();
    }
    // 몬스터들을 스폰합니다.
    SpawnMonsters(floorPositions);
    }

}
