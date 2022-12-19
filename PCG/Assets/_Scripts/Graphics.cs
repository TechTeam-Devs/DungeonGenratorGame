using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
//using UnityEngine.WSA;

public class Graphics : MonoBehaviour
{
    [SerializeField]
    private TileBase wallTop;

    [SerializeField]
    private TileBase wallRight;

    [SerializeField]
    private TileBase wallLeft;

    [SerializeField]
    private TileBase wallBottom;

    [SerializeField]
    private TileBase wallMid;

    [SerializeField]
    private TileBase fillerWalls;

    [SerializeField]
    private Tilemap groundTilemap;

    [SerializeField]
    private Tilemap wallTilemap;

    [SerializeField]
    private TileBase groundTiles;

    [SerializeField]
    private TileBase corridorBlock;

    [SerializeField]
    private TileBase wallInnerCornerUpRight;

    [SerializeField]
    private TileBase wallInnerCornerUpLeft;

    [SerializeField]
    private TileBase wallOuterCornerDownRight;

    [SerializeField]
    private TileBase wallOuterCornerDownLeft;

    [SerializeField]
    private TileBase wallOuterCornerUpRight;

    [SerializeField]
    private TileBase wallOuterCornerUpLeft;

   
    public void CreateGroundTiles(IEnumerable<Vector2Int> groundPos)
    {
        CreateTiles(groundPos, groundTilemap, groundTiles);
    }

    private void CreateTiles(IEnumerable<Vector2Int> tilePos, Tilemap tilemap, TileBase tiles)
    {
        foreach (var pos in tilePos)
        {
            CreateSingleTile(tilemap, tiles, pos);
        }
    }

    internal void CreateSingleWall(Vector2Int pos, string Binary)
    {
        int BinaryType = Convert.ToInt32(Binary, 2);
        TileBase tile = null;
        if(WallBytes.wallTop.Contains(BinaryType))
        {
            tile = wallTop;
        }
        else if(WallBytes.wallSideRight.Contains(BinaryType))
        {
            tile = wallRight;
        }
        else if (WallBytes.wallSideLeft.Contains(BinaryType))
        {
            tile = wallLeft;
        }

        else if (WallBytes.wallBottom.Contains(BinaryType))
        {
            tile = wallBottom;
        }

        else if (WallBytes.wallMid.Contains(BinaryType))
        {
            tile = wallMid;
        }
        else if (WallBytes.fillerWalls.Contains(BinaryType))
        {
            tile = fillerWalls;
        }
        if (tile!=null)
        {
            
        CreateSingleTile(wallTilemap, tile, pos);
        }
    }

    private void CreateSingleTile(Tilemap tilemap, TileBase tiles, Vector2Int pos)
    {
        var localTilePos = tilemap.WorldToCell((Vector3Int)pos);
        tilemap.SetTile(localTilePos, tiles);
    }

    public void Clear()
    {
        groundTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void CreateCorridorBlock(Vector2Int pos, string Binary)
    {
        int BinaryType = Convert.ToInt32(Binary, 2);

        if (WallBytes.corridorBlock.Contains(BinaryType))
        {
            GameObject test = GameObject.Find("Blocks");
            GameObject clone = Instantiate(test, (Vector3Int)pos, transform.rotation);
            ObjectHandler.AddBlockToList(clone);
        }
    }

    internal void CreateSingleCornerWall(Vector2Int pos, string Binary)
    {
        int BinaryType = Convert.ToInt32(Binary, 2);
        TileBase tile = null;

        if(WallBytes.wallInnerCornerUpRight.Contains(BinaryType))
        {
            tile = wallInnerCornerUpRight;
        }
        else if (WallBytes.wallInnerCornerUpLeft.Contains(BinaryType))
        {
            tile = wallInnerCornerUpLeft;
        }

        else if (WallBytes.wallOuterCornerDownLeft.Contains(BinaryType))
        {
            tile = wallOuterCornerDownLeft;
        }

        else if (WallBytes.wallOuterCornerDownRight.Contains(BinaryType))
        {
            tile = wallOuterCornerDownRight;
        }

        else if (WallBytes.wallOuterCornerUpRight.Contains(BinaryType))
        {
            tile = wallOuterCornerUpRight;
        }

        else if (WallBytes.wallOuterCornerUpLeft.Contains(BinaryType))
        {
            tile = wallOuterCornerUpLeft;
        }

        if (tile!= null)
        { 
            CreateSingleTile(wallTilemap, tile, pos);
        }
    }
}
