using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public static class WallGenerator 
{
    public static void createWalls(HashSet<Vector2Int> groundPos, Graphics graphics)
    {
        var displayWall = wallDirection(groundPos, Direction.directionList);
        var cornerWall = wallDirection(groundPos, Direction.diagonalList);
        //var block = wallDirection(groundPos, Direction.diagonalList);
        CreateAllWalls(graphics, displayWall, groundPos);
        CreateCorners(graphics, cornerWall, groundPos);
        //CreateBlocks(graphics, block, groundPos);
    }

    public static void createBlocks(HashSet<Vector2Int> groundPos, Graphics graphics)
    { 
        var block = blockDirection(groundPos, Direction.diagonalList);
        CreateBlocks(graphics, block, groundPos);
    }

    private static void CreateCorners(Graphics graphics, HashSet<Vector2Int> cornerWall, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in cornerWall)
        {
            string binaryWalls = "";
            foreach (var directions in Direction.allDirections)
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
            graphics.createSingleCornerWall(pos, binaryWalls);
        }
    }

    private static void CreateBlocks(Graphics graphics, HashSet<Vector2Int> block, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in block)
        {
            string binaryWalls = "";
            foreach (var directions in Direction.allDirections)
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
            graphics.createCorridorBlock(pos, binaryWalls);
        }
        ObjectHandler.get();
    }

        private static void CreateAllWalls(Graphics graphics, HashSet<Vector2Int> displayWall, HashSet<Vector2Int> groundPos)
    {
        foreach (var pos in displayWall)
        {
            string binaryWalls = "";
            foreach (var direction in Direction.directionList)
            {
                var neighborPos = pos + direction;
                if (groundPos.Contains(neighborPos))
                {
                    binaryWalls += "1";
                }
                else
                {
                    binaryWalls += "0";
                }
            }
            graphics.createSingleWall(pos, binaryWalls);
        }
    }

    private static HashSet<Vector2Int> wallDirection(HashSet<Vector2Int> groundPos, List<Vector2Int> directions)
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
                if (groundPos.Contains(nextTo) == true && randomizer < 10)
                {
                    blockPos.Add(nextTo);
                }
            }
        }
        return blockPos;
    }
}
