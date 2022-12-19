using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class WallGenerator 
{

    public static void CreateWalls(HashSet<Vector2Int> groundPos, Graphics graphics)
    {
        var mainWallPos = WallDirection(groundPos, Direction.directionList);
        var cornerWallPos = WallDirection(groundPos, Direction.diagonalDirectionList);
        
        CreateMainWalls(graphics, mainWallPos, groundPos);
        CreateCorners(graphics, cornerWallPos, groundPos);
        
    }

    private static void CreateCorners(Graphics graphics, HashSet<Vector2Int> cornerWallPos, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in cornerWallPos)
        {
            string binaryWalls = "";
            foreach (var directions in Direction.allDirectionsList)
            {
                var neigherborPos = pos + directions;
                if (groundPos.Contains(neigherborPos))
                {
                    binaryWalls += "1";
                }
                else
                {
                    binaryWalls += "0";
                }
            }
            graphics.CreateSingleCornerWall(pos, binaryWalls);
        }
    }

    private static void CreateMainWalls(Graphics graphics, HashSet<Vector2Int> mainWallPos, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in mainWallPos)
        {
            string binaryMainWalls = "";
            foreach (var direction in Direction.directionList)
            {
                var neighborPos = pos + direction;
                if (groundPos.Contains(neighborPos))
                {
                    binaryMainWalls += "1";
                }
                else
                {
                    binaryMainWalls += "0";
                }
            }
            graphics.CreateSingleWall(pos, binaryMainWalls);
        }
    }

    private static HashSet<Vector2Int> WallDirection(HashSet<Vector2Int> groundPos, List<Vector2Int> directions)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();
        foreach (var pos in groundPos)
        {
            foreach (var direction in directions)
            {
                var nextTo = pos + direction;
                if (groundPos.Contains(nextTo) == false)
                {
                    wallPos.Add(nextTo);
                }
            }
        }
        return wallPos;
    }

    private static HashSet<Vector2Int> blockDirection(HashSet<Vector2Int> groundPos, List<Vector2Int> directions)
    {
        HashSet<Vector2Int> blockPos = new HashSet<Vector2Int>();
        foreach (var pos in groundPos)
        {
            foreach (var direction in directions)
            {
                var nextTo = pos + direction;
                var randomizer = Random.Range(0, 100);
                if (groundPos.Contains(nextTo) == true && randomizer < 50)
                {
                    blockPos.Add(nextTo);
                }
            }
        }
        return blockPos;
    }

    public static void CreateBlocks(HashSet<Vector2Int> groundPos, Graphics graphics)
    {
        var blockPos = blockDirection(groundPos, Direction.diagonalDirectionList);
        CreateBlocks(graphics, blockPos, groundPos);
    }

    private static void CreateBlocks(Graphics graphics, HashSet<Vector2Int> blockPos, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in blockPos)
        {
            string binaryBlocks = "";
            foreach (var directions in Direction.allDirectionsList)
            {
                var neigherborPos = pos + directions;
                if (groundPos.Contains(neigherborPos))
                {
                    binaryBlocks += "1";

                }
                else
                {
                    binaryBlocks += "0";

                }
            }
            graphics.CreateCorridorBlock(pos, binaryBlocks);
        }
    }
}
