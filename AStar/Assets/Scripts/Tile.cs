using UnityEngine;

public enum TileType
{
    Blocked,
    Undiscovered,
    Discovered,
    Visited,
    Goal
}

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public int gScore = int.MaxValue;
    public int fScore = int.MaxValue;
    public TileType tileType;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetType(TileType tileType)
    {
        this.tileType = tileType;
        Color color = Color.white;
        switch (tileType)
        {
            case TileType.Blocked:
                color = Color.black;
                break;
            default:
            case TileType.Undiscovered:
                color = Color.white;
                break;
            case TileType.Discovered:
                color = Color.blue;
                break;
            case TileType.Visited:
                color = Color.green;
                break;
            case TileType.Goal:
                color = Color.red;
                break;
        }
        spriteRenderer.color = color;
    }
}
