using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    //public TileBase Tile;
    public string name;
    public Sprite image;
    //public ItemType item;
    //public ActionType action;
    //public Vector2Int range = new Vector2Int(5,4);
    public bool stackable = true;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
