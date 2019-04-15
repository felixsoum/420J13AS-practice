using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;

    int[,] map = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {1, 1, 1, 1, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
    };

    Tile[,] tiles;
    int length;
    int width;

    void Awake()
    {
        length = map.GetLength(0);
        width = map.GetLength(1);

        tiles = new Tile[length, width];

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile t = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity).GetComponent<Tile>();
                t.SetType(map[y, x] == 0 ? TileType.Undiscovered : TileType.Blocked);
                t.x = x;
                t.y = y;
                tiles[y, x] = t;
            }
        }

        Tile start = tiles[1, 1];
        Tile end = tiles[6, 1];

        StartCoroutine(AStarCoroutine(start, end));
    }

    IEnumerator AStarCoroutine(Tile start, Tile goal)
    {
        var closedSet = new HashSet<Tile>();
        var openSet = new List<Tile>() { start };

        start.gScore = 0;
        HeuristicCostEstimate(start, goal);
        goal.SetType(TileType.Goal);

        while (openSet.Count > 0)
        {
            openSet.Sort((a, b) => { return a.fScore.CompareTo(b.fScore); });
            var current = openSet[0];
            openSet.RemoveAt(0);
            closedSet.Add(current);
            current.SetType(TileType.Visited);
            if (current == goal)
            {
                break;
            }
            yield return new WaitForSeconds(0.5f);

            foreach (var neighbor in GetNeighbors(current))
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                if (neighbor.tileType == TileType.Blocked)
                {
                    continue;
                }

                int tentativeGScore = current.gScore + 1;

                if (!openSet.Contains(neighbor))
                {
                    neighbor.SetType(TileType.Discovered);
                    yield return new WaitForSeconds(0.5f);
                    openSet.Add(neighbor);
                }
                else if (tentativeGScore >= neighbor.gScore)
                {
                    continue;
                }

                neighbor.gScore = tentativeGScore;
                HeuristicCostEstimate(neighbor, goal);
                neighbor.fScore += neighbor.gScore;
            }
        }
    }

    void HeuristicCostEstimate(Tile source, Tile destination)
    {
        //source.fScore = 0;
        source.fScore = Mathf.Abs(source.x - destination.x) + Mathf.Abs(source.y - destination.y);
    }

    List<Tile> GetNeighbors(Tile tile)
    {
        var neighbors = new List<Tile>();
        if (tile.y > 0)
        {
            neighbors.Add(tiles[tile.y - 1, tile.x]);
        }
        if (tile.y < length - 1)
        {
            neighbors.Add(tiles[tile.y + 1, tile.x]);
        }
        if (tile.x > 0)
        {
            neighbors.Add(tiles[tile.y, tile.x - 1]);
        }
        if (tile.x < width - 1)
        {
            neighbors.Add(tiles[tile.y, tile.x + 1]);
        }
        return neighbors;
    }
}
