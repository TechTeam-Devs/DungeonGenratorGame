using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectHandler
{
    static List<GameObject> gameObjects = new List<GameObject>();

    public static void add(GameObject thing)
    {
        gameObjects.Add(thing);
    }

    public static void get()
    {
        foreach (var item in gameObjects)
        {
            Debug.Log(item);
        }
        Debug.Log(gameObjects.Count);
    }


    public static List<GameObject> deleteObjects()
    {
        ObjectDestroyer game = new ObjectDestroyer();
        if (gameObjects.Count > 0)
        {
            game.deleteObject(gameObjects);
            gameObjects.Clear();

        }
        return gameObjects;
    }
}
