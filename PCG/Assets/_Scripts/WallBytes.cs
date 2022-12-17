using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallBytes
{

    public static HashSet<int> wallTop = new HashSet<int>
    {
        0b0010 //On wall position -- TOP 0 = NO -- RIGHT 0 = NO -- BOTTOM 1 = YES -- LEFT 0 = NO
    };

    public static HashSet<int> wallSideLeft = new HashSet<int>
    {
        0b0100 //On wall position -- TOP 0 = NO -- RIGHT 1 = YES -- BOTTOM 0 = NO -- LEFT 0 = NO
    };

    public static HashSet<int> wallSideRight = new HashSet<int>
    {
        0b0001 //On wall position -- TOP 0 = NO -- RIGHT 0 = NO -- BOTTOM 0 = NO -- LEFT 1 = YES
    };

    public static HashSet<int> wallBottm = new HashSet<int>
    {
        0b1000 //On wall position -- TOP 1 = YES -- RIGHT 0 = NO -- BOTTOM 0 = NO -- LEFT 0 = NO
    };

    public static HashSet<int> wallMid = new HashSet<int>
    {
        0b1101,
        0b0101,
        0b1101,
        0b1001
    };

    public static HashSet<int> fillerWalls = new HashSet<int>
    {
        0b1111,
        0b0110,
        0b0011,
        0b1010,
        0b1100,
        0b1110,
        0b1011,
        0b0111
    };

    public static HashSet<int> corridorBlock = new HashSet<int>
    {
        0b10111110,
        0b10101111,
        0b11101011,
        0b11111010
    };

    public static HashSet<int> wallInnerCornerUpRight = new HashSet<int>
    {
        0b11100001
    };

    public static HashSet<int> wallInnerCornerUpLeft = new HashSet<int>
    {
        0b11000111,
    };

    public static HashSet<int> wallOuterCornerDownLeft = new HashSet<int>
    {
        0b01000000
    };

    public static HashSet<int> wallOuterCornerDownRight = new HashSet<int>
    {
        0b00000001
    };

    public static HashSet<int> wallOuterCornerUpLeft = new HashSet<int>
    {
        0b00010000,
    };

    public static HashSet<int> wallOuterCornerUpRight = new HashSet<int>
    {
        0b00000100,
    };
}
