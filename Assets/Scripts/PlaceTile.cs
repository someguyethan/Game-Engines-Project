using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTile : MonoBehaviour
{
    public Tilemap map;
    public TileBase ground;
    public TileBase groundPreview;

    Vector3Int temp = Vector3Int.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 worldPos3 = new Vector3 (worldPos.x, worldPos.y, 0f);
       
        if (map.GetTile(map.WorldToCell(worldPos3)) == null)
            map.SetTile(map.WorldToCell(worldPos3), groundPreview);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            map.SetTile(map.WorldToCell(worldPos3), ground);
        }
    }
}
