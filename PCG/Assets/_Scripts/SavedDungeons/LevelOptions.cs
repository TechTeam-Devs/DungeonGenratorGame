using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "levelParameters_" ,menuName = "PCG_1/LevelOptions")]

public class LevelOptions : ScriptableObject
{
    public int iterations = 10;
    public int walkDist = 10;
    public int minRoomWidth = 10;
    public int minRoomHeight = 10;
    public int gameWidth = 70;
    public int gameHeight = 70;
    public int spaceBetweenRooms = 2;

    public bool bendyRooms = true;
}
