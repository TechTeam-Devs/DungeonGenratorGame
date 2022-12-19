using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public void DeleteObject(List<GameObject> ObjectList)
    {
        foreach (var gameObject in ObjectList)
        {
          
            Destroy(gameObject);

        }
    }
}
