using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    private const float Speed = 0.1f;
    [SerializeField] GameObject tilePrefab;

    int[,] map = new int[,]
    {
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {0, 3, 0, 0, 0, 0, 0, 0 },
        {0, 0, 0, 0, 0, 0, 0, 0 },
        {1, 1, 1, 1, 0, 0, 0, 0 },
        {0, 0, 0, 1, 0, 0, 0, 0 },
        {0, 2, 0, 1, 0, 0, 0, 0 },
        {0, 0, 0, 1, 0, 0, 0, 0 },
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

        Tile start = null;
        Tile end = null;

        for (int y = 0; y < length; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Tile t = Instantiate(tilePrefab, new Vector3(x, length - y, 0), Quaternion.identity).GetComponent<Tile>();
                t.SetType(map[y, x] == 1 ? TileType.Blocked : TileType.Undiscovered);
                t.x = x;
                t.y = y;
                tiles[y, x] = t;
                if (map[y, x] == 2)
                {
                    start = t;   
                }
                else if (map[y, x] == 3)
                {
                    end = t;
                }
            }
        }


        StartCoroutine(AStarCoroutine(start, end));
    }

    IEnumerator AStarCoroutine(Tile start, Tile goal)
    {
        var closedSet = new HashSet<Tile>();
        var openSet = new List<Tile>() { start };

        start.gScore = 0;
        start.fScore = HeuristicCostEstimate(start, goal);
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
            yield return new WaitForSeconds(Speed);

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
                    yield return new WaitForSeconds(Speed);
                    openSet.Add(neighbor);
                }
                else if (tentativeGScore >= neighbor.gScore)
                {
                    continue;
                }

                neighbor.predecessor = current;
                neighbor.gScore = tentativeGScore;
                neighbor.fScore = neighbor.gScore + HeuristicCostEstimate(neighbor, goal);
            }
        }

        var predecessor = goal;
        while (predecessor != null)
        {
            predecessor.SetType(TileType.Goal);
            predecessor = predecessor.predecessor;
            yield return new WaitForSeconds(Speed);
        }
        start.SetType(TileType.Goal);
    }

    int HeuristicCostEstimate(Tile source, Tile destination)
    {
        return 0;
        //return Mathf.Abs(source.x - destination.x) + Mathf.Abs(source.y - destination.y);
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
