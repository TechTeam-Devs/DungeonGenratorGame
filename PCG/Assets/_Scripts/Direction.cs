using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

    public static class Direction
    {
        public static List<Vector2Int> directionList = new List<Vector2Int>
    {
        new Vector2Int (0, 1), // Direction UP
        new Vector2Int (1, 0), // Direction RIGHT
        new Vector2Int (0, -1), // Direction DOWN
        new Vector2Int (-1, 0) // Direction LEFT
    };

        public static List<Vector2Int> diagonalDirectionList = new List<Vector2Int>
    {
        new Vector2Int (1, 1), // Direction UP-RIGHT
        new Vector2Int (1, -1), // Direction RIGHT-DOWN
        new Vector2Int (-1, -1), // Direction DOWN-LEFT
        new Vector2Int (-1, 1) // Direction LEFT-UP
    };

        public static List<Vector2Int> allDirectionsList = new List<Vector2Int>
    {
        new Vector2Int (0, 1), // Direction UP
        new Vector2Int (1, 1), // Direction UP-RIGHT
        new Vector2Int (1, 0), // Direction RIGHT
        new Vector2Int (1, -1), // Direction RIGHT-DOWN
        new Vector2Int (0, -1), // Direction DOWN
        new Vector2Int (-1, -1), // Direction DOWN-LEFT
        new Vector2Int (-1, 0), // Direction LEFT
        new Vector2Int (-1, 1) // Direction LEFT-UP
    };

        public static Vector2Int GetRandomDirection()
        {
            return directionList[Random.Range(0, directionList.Count)];
        }
    }


