using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class GameAlgorithms
{
    public static HashSet<Vector2Int> AgentBasedWalk(Vector2Int startPos, int walkDist)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < walkDist; i++)
        {
            var nextPos = prevPos + Direction.GetRandomDirection();
            prevPos = nextPos;
            path.Add(nextPos);
        }
        return path;
    }

    public static List<BoundsInt> BinarySpacing(BoundsInt splitSpace, int minWidth, int minHeight)
    {
        Queue<BoundsInt> queue = new Queue<BoundsInt>();
        List<BoundsInt> list = new List<BoundsInt>();
        queue.Enqueue(splitSpace);
        while (queue.Count > 0)
        {
            var room = queue.Dequeue();
            if (room.size.y >= minHeight && room.size.x >= minWidth)
            {
                if (Random.value < 0.5f)
                {
                    if (room.size.y >= minHeight * 2)
                    {
                        SplitHorizontally(minWidth, queue, room);
                    }
                    else if (room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minHeight, queue, room);
                    }
                    else
                    {
                        list.Add(room);
                    }
                }
                else
                {
                    if (room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minWidth, queue, room);
                    }
                    else if (room.size.y >= minHeight * 2)
                    {
                        SplitHorizontally(minHeight, queue, room);
                    }
                    else
                    {
                        list.Add(room);
                    }
                }
            }
        }
        return list;
    }

    private static void SplitVertically(int minWidth, Queue<BoundsInt> queue, BoundsInt room)
    {
        var verSplit = Random.Range(1, room.size.x);
        BoundsInt firstRoom = new BoundsInt(room.min, new Vector3Int(verSplit, room.size.y, room.size.z));
        BoundsInt secondRoom = new BoundsInt(new Vector3Int(room.min.x + verSplit, room.min.y, room.min.z),
            new Vector3Int(room.size.x - verSplit, room.size.y, room.size.z));
        queue.Enqueue(firstRoom);
        queue.Enqueue(secondRoom);
    }

    private static void SplitHorizontally(int minHeight, Queue<BoundsInt> queue, BoundsInt room)
    {
        var horSplit = Random.Range(1, room.size.y);
        BoundsInt firstRoom = new BoundsInt(room.min, new Vector3Int(room.size.x, horSplit, room.size.z));
        BoundsInt secondRoom = new BoundsInt(new Vector3Int(room.min.x, room.min.y + horSplit, room.min.z),
            new Vector3Int(room.size.x, room.size.y - horSplit,  room.size.z));
        queue.Enqueue(firstRoom);
        queue.Enqueue(secondRoom);
    }
}