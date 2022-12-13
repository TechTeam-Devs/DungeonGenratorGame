using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public void deleteObject(List<GameObject> list)
    {
        foreach (var gameobject in list)
        {
            //Debug.Log(gameobject);
            DestroyImmediate(gameobject);

        }
    }
}
