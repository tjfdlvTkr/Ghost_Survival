using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    private Player player;
    private TilemapVisualizer tilemapVisualizer;
    private Movement2D movement2D;
    private Vector2Int[] pathToPlayer;
    private Vector2Int moveDirection;
    private int currentPathIndex;

    private void Awake()
    {
        tilemapVisualizer = FindObjectOfType<TilemapVisualizer>();
        player = FindObjectOfType<Player>();
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        if (GameManager.instance.isGameover) return;

        if (pathToPlayer == null || currentPathIndex >= pathToPlayer.Length)
        {
            // 플레이어의 위치를 가져옴
            Vector2 playerPosition = player.GetPosition();

            // BFS 알고리즘을 사용하여 최단 경로 계산
            Vector2 monsterPosition = transform.position;

            HashSet<Vector2Int> walkableTiles = tilemapVisualizer.GetWalkableTiles();
            pathToPlayer = BFS.GetPath(Vector2Int.FloorToInt(monsterPosition), Vector2Int.FloorToInt(playerPosition), walkableTiles);
            currentPathIndex = 0;
        }
        else
        {
        Vector2Int nextPosition = pathToPlayer[currentPathIndex];
         moveDirection = nextPosition - Vector2Int.FloorToInt(transform.position);

         if (movement2D.MoveTo(new Vector3(moveDirection.x, moveDirection.y, 0)))
          {
              currentPathIndex++;
          }
        }       
    }

    public Vector2Int getMovedirection() { return moveDirection; }
}

