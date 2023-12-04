using System.Collections.Generic;
using UnityEngine;

public class BFS 
{
    private static readonly Vector2Int[] directions =
    {
    new Vector2Int(-1, 0), // 좌
    new Vector2Int(1, 0),  // 우
    new Vector2Int(0, -1), // 하
    new Vector2Int(0, 1)   // 상
    };

    public static Vector2Int[] GetPath(Vector2Int start, Vector2Int end, HashSet<Vector2Int> walkableTiles)

    {
        // BFS 알고리즘을 위한 큐 생성
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        queue.Enqueue(start);

        // 방문 여부를 확인하는 딕셔너리 생성
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        cameFrom.Add(start, start);

        // BFS 알고리즘 실행
        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();

            if (current == end) 
            {
                break;
            }

            foreach (Vector2Int direction in directions)
            {
                Vector2Int neighbour = current + direction;

                // 이동 가능한 타일만을 탐색하도록 수정된 부분
                if (walkableTiles.Contains(neighbour) && !cameFrom.ContainsKey(neighbour))
                {
                    queue.Enqueue(neighbour);
                    cameFrom[neighbour] = current;
                }
            }
        }

        // 경로 생성
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int currentStep = end;

        while (currentStep != start) 
        {
            path.Add(currentStep);
            currentStep = cameFrom[currentStep];
        }
        path.Add(start);
        path.Reverse();

        return path.ToArray();
    }

    private static IEnumerable<Vector2Int> GetNeighbours(Vector2Int position) 
    {
        // 상하좌우 이웃 위치 반환
        yield return position + Vector2Int.up;
        yield return position + Vector2Int.down;
        yield return position + Vector2Int.left;
        yield return position + Vector2Int.right;
    }
    
    private static bool IsAccessible(Vector2Int position, HashSet<Vector2Int> walkableTiles)
{
    return walkableTiles.Contains(position);
}
}