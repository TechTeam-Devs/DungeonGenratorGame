using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Graphics : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;

    [SerializeField]
    private Tilemap blockTilemap;

    [SerializeField]
    private Tilemap wallTilemap;

    [SerializeField]
    private TileBase groundTiles;

    [SerializeField]
    private TileBase corridorBlock;

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
    private TileBase wallInnerCornerDownLeft;

    [SerializeField]
    private TileBase wallInnerCornerDownRight;

    [SerializeField]
    private TileBase wallDiagonalCornerDownRight;

    [SerializeField]
    private TileBase wallDiagonalCornerDownLeft;

    [SerializeField]
    private TileBase wallDiagonalCornerUpRight;

    [SerializeField]
    private TileBase wallDiagonalCornerUpLeft;

   
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

        else if (WallBytes.wallBottm.Contains(BinaryType))
        {
            tile = wallBottom;
        }

        else if (WallBytes.wallFull.Contains(BinaryType))
        {
            tile = wallMid;
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

        if(WallBytes.wallInnerCornerDownLeft.Contains(BinaryType))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if (WallBytes.wallInnerCornerDownRight.Contains(BinaryType))
        {
            tile = wallInnerCornerDownRight;
        }

        else if (WallBytes.wallDiagonalCornerDownLeft.Contains(BinaryType))
        {
            tile = wallDiagonalCornerDownLeft;
        }

        else if (WallBytes.wallDiagonalCornerDownRight.Contains(BinaryType))
        {
            tile = wallDiagonalCornerDownRight;
        }

        else if (WallBytes.wallDiagonalCornerUpRight.Contains(BinaryType))
        {
            tile = wallDiagonalCornerUpRight;
        }

        else if (WallBytes.wallDiagonalCornerUpLeft.Contains(BinaryType))
        {
            tile = wallDiagonalCornerUpLeft;
        }

        else if (WallBytes.wallFullEightDirections.Contains(BinaryType))
        {
            tile = wallBottom;
        }

        else if (WallBytes.wallBottmEightDirections.Contains(BinaryType))
        {
            tile = wallMid;
        }


        if (tile!= null)
        {

            CreateSingleTile(wallTilemap, tile, pos);
        }
    }
}
