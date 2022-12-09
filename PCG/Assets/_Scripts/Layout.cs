using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Layout : MonoBehaviour
{
    [SerializeField]
    protected Graphics graphics = null;
    
    protected Vector2Int startPos = new Vector2Int(0, 0);

    protected abstract void RunMapGenerator();

    public void MapGenerator()
    {
        graphics.Clear();
        RunMapGenerator();
    }
}
