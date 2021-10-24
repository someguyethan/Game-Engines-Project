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

    Vector2Int[] directions = new Vector2Int[] { new Vector2Int(1,0),
                                                 new Vector2Int(1,-1),
                                                 new Vector2Int(0,-1),
                                                 new Vector2Int(-1,-1),
                                                 new Vector2Int(-1,0),
                                                 new Vector2Int(-1,1),
                                                 new Vector2Int(0,1),
                                                 new Vector2Int(1,1)};

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Vector3 worldPos3 = new Vector3 (worldPos.x, worldPos.y, 0f);
        

        if (map.GetTile(map.WorldToCell(worldPos3)) == null)
        {
            map.SetTile(map.WorldToCell(worldPos3), groundPreview);
            //reset all others
            for (int i = 1; i <= 8; i++)
            {
                Vector3Int temp = new Vector3Int(map.WorldToCell(worldPos3).x + directions[i - 1].x,
                                                 map.WorldToCell(worldPos3).y + directions[i - 1].y,
                                                 0);
                if (map.GetTile(temp) == groundPreview)
                {
                    map.SetTile(temp, null);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            map.SetTile(map.WorldToCell(worldPos3), ground);
        }
    }
}
