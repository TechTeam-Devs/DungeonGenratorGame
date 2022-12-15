using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectHandler
{
    private static List<GameObject> blockList = new List<GameObject>();
    private static List<GameObject> enemyList = new List<GameObject>();

    public static void SpawnRandomBlocks()
    {
        if (blockList.Count == 0)
        {
            return;
        }
        int newBlock = Random.Range(0, blockList.Count);

        blockList[newBlock].SetActive(!blockList[newBlock].activeSelf);

    }

    public static void AddBlockToList(GameObject thing)
    {
        blockList.Add(thing);
    }

    public static void AddEnemyToList(GameObject thing)
    {
        enemyList.Add(thing);
    }


    public static void DeleteObjects()
    {
        ObjectDestroyer objectDestroyer = new ObjectDestroyer();
        if (blockList.Count > 0)
        {
            objectDestroyer.DeleteObject(blockList);
            blockList.Clear();

        }
        if (enemyList.Count > 0)
        {
            objectDestroyer.DeleteObject(enemyList);
            enemyList.Clear();
        }
       
    }
}
