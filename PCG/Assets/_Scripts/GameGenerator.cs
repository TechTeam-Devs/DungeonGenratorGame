using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class GameGenerator : Layout
{
    [SerializeField]
    protected LevelOptions levelParameters;

    private List<GameObject> gameObjects;

    protected override void RunMapGenerator()
    {
        if(gameObjects.Count > 0) {
            foreach (var gameobject in gameObjects)
            {
                Debug.Log(gameobject);
                DestroyImmediate(gameobject);
            }
            gameObjects.Clear();
        }
        
        CreateRooms();
    }

    private void CreateRooms()
    {
        var list = GameAlgorithms.BinarySpacing(new BoundsInt((Vector3Int)startPos, new Vector3Int
            (levelParameters.gameWidth, levelParameters.gameHeight, 0)), levelParameters.minRoomWidth, levelParameters.minRoomHeight);

        HashSet<Vector2Int> ground = new HashSet<Vector2Int>();

        if (levelParameters.bendyRooms == true)
        {
            ground = RoomRandomGen(list);
        }
        else
        {
            ground = CreateBinarySpacingRooms(list);
        }

        List<Vector2Int> centerOfRoom = new List<Vector2Int>();
        foreach (var room in list)
        {
            centerOfRoom.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }

        List<Vector2Int> endOfCorridor = new List<Vector2Int>();
        foreach (var room in list)
        {
            endOfCorridor.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }

        Vector2 playerStartPos = centerOfRoom[0];
        Vector2 goalStartPos = centerOfRoom.Last();
        
        GameObject player = GameObject.Find("Player");
        player.transform.position = playerStartPos;

        GameObject goal = GameObject.Find("DummyGoal");
        goal.transform.position = goalStartPos;

        HashSet<Vector2Int> corri = Connect(centerOfRoom);
        ground.UnionWith(corri);

        Vector2 testPos = endOfCorridor.Last();

        GameObject test = GameObject.Find("DummyTest");
        test.transform.position = testPos;

        graphics.createGroundTiles(ground);
        WallGenerator.createWalls(ground, graphics);
        WallGenerator.createBlocks(ground, graphics);

    }

    private HashSet<Vector2Int> RoomRandomGen(List<BoundsInt> list)
    {
        HashSet<Vector2Int> ground = new HashSet<Vector2Int>();
        for (int i = 0; i < list.Count; i++)
        {
            var roomBoundery = list[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBoundery.center.x), Mathf.RoundToInt(roomBoundery.center.y));
            var roomGround = RandomPath(levelParameters, roomCenter);
            foreach (var pos in roomGround)
            {
                if (pos.x >= (roomBoundery.xMin + levelParameters.spaceBetweenRooms) && pos.x <= (roomBoundery.xMax - levelParameters.spaceBetweenRooms) && pos.y >= (roomBoundery.yMin
                    - levelParameters.spaceBetweenRooms) && pos.y <= (roomBoundery.yMax - levelParameters.spaceBetweenRooms))
                {
                    ground.Add(pos);
                }
            }
        }
        return ground;
    }

    private HashSet<Vector2Int> Connect(List<Vector2Int> centerOfRoom)
    {
        HashSet<Vector2Int> corri = new HashSet<Vector2Int>();
        var tempCenter = centerOfRoom[Random.Range(0, centerOfRoom.Count)];
        centerOfRoom.Remove(tempCenter);

        while(centerOfRoom.Count > 0)
        {
            Vector2Int closestRoom = FindClosestRoom(tempCenter, centerOfRoom);
            centerOfRoom.Remove(closestRoom);
            HashSet<Vector2Int> tempCorri = CreateCorri(tempCenter, closestRoom);
            tempCenter = closestRoom;
            corri.UnionWith(tempCorri);
        }
        return corri;
    }

    private Vector2Int FindClosestRoom(Vector2Int tempCenter, List<Vector2Int> centerOfRoom)
    {
        Vector2Int closestRoom = Vector2Int.zero;
        float dist = float.MaxValue;
        foreach (var pos in centerOfRoom)
        {
            float currDist = Vector2Int.Distance(pos, tempCenter);
            if(currDist < dist)
            {
                dist = currDist;
                closestRoom = pos;
            }
        }
        return closestRoom;
    }

    private HashSet<Vector2Int> CreateCorri(Vector2Int tempCenter, Vector2Int closestRoom)
    {
        HashSet<Vector2Int> corri = new HashSet<Vector2Int>();
        var pos = tempCenter;
        corri.Add(pos);
        while(pos.y != closestRoom.y)
        {
            if(closestRoom.y > pos.y)
            {
                pos += Vector2Int.up;
            }
            else if (closestRoom.y < pos.y)
            {
                pos += Vector2Int.down;
            }
            corri.Add(pos);        
        }
        while (pos.x != closestRoom.x)
        {
            if(closestRoom.x > pos.x)
            {
                pos += Vector2Int.right;
            }
            else if (closestRoom.x < pos.x)
            {
                pos += Vector2Int.left;
            }
            corri.Add(pos);
        }
        List<Vector2Int> gameObjecttt = corri.ToList();
        Vector2 position = gameObjecttt[0];
        GameObject test = GameObject.Find("DummyTest");
        GameObject clone = Instantiate(test, position, transform.rotation);
        gameObjects.Add(clone);
        return corri;
    }

    private HashSet<Vector2Int> CreateBinarySpacingRooms(List<BoundsInt> list)
    {
        HashSet<Vector2Int> ground = new HashSet<Vector2Int>();
        foreach (var room in list)
        {
            for (int x = levelParameters.spaceBetweenRooms; x < room.size.x; x++)
            {
                for (int y = levelParameters.spaceBetweenRooms; y < room.size.y; y++)
                {
                    Vector2Int pos = (Vector2Int)room.min + new Vector2Int(x, y);
                    ground.Add(pos);
                }
            }
        }
        return ground;
    }

    protected HashSet<Vector2Int> RandomPath(LevelOptions levelParameters, Vector2Int pos)
    {
        var currPos = pos;
        HashSet<Vector2Int> groundPos = new HashSet<Vector2Int>();
        for (int i = 0; i < levelParameters.iterations; i++)
        {
            var path = GameAlgorithms.AgentBasedWalk(currPos, levelParameters.walkDist);
            groundPos.UnionWith(path);
            if (levelParameters.bendyRooms == true)
            {
                currPos = groundPos.ElementAt(Random.Range(0, groundPos.Count));
            }
        }
        return groundPos;
    }
}
