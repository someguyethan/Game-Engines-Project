using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlaceTile : MonoBehaviour
{
    public Camera cam;

    public Tilemap map;

    public TileBase ground;
    public TileBase groundPreview;

    public GameObject ballPrefab;
    public TileBase ballPrefab_preview;

    public GameObject laserPrefab;
    public TileBase laserPrefab_preview;

    public GameObject jumpPadPrefab;
    public TileBase jumpPadPrefab_preview;

    public GameObject doorPrefab;
    public TileBase doorPrefab_preview;

    public GameObject playerPrefab;
    public TileBase playerPrefab_preview;

    Vector3Int temp = Vector3Int.zero;

    Vector2Int[] directions = new Vector2Int[] 
    { 
        new Vector2Int(1,0),
        new Vector2Int(1,-1),
        new Vector2Int(0,-1),
        new Vector2Int(-1,-1),
        new Vector2Int(-1,0),
        new Vector2Int(-1,1),
        new Vector2Int(0,1),
        new Vector2Int(1,1)
    };

    public bool doTile = true;
    public bool doDestroy = false;
    GameObject currentPrefab;
    TileBase currentPrefab_preview;

    private bool isDirty = true;

    void Start()
    {
        currentPrefab = ballPrefab;
        currentPrefab_preview = ballPrefab_preview;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);
        Vector3 worldPos3 = new Vector3 (worldPos.x, worldPos.y, 0f);

        if (Input.GetKeyDown(KeyCode.T))
            doTile = !doTile;
        else if (Input.GetKeyDown(KeyCode.R))
            doDestroy = !doDestroy;
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCurrent(ballPrefab, ballPrefab_preview);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetCurrent(doorPrefab, doorPrefab_preview);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetCurrent(laserPrefab, laserPrefab_preview);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetCurrent(jumpPadPrefab, jumpPadPrefab_preview);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetCurrent(playerPrefab, playerPrefab_preview);
        }

        if (doTile)
            PaintTile(worldPos3);
        else if (!doTile)
            PaintPrefab(worldPos3, currentPrefab, currentPrefab_preview);

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
                Resume();
            else if (Time.timeScale == 1)
                Pause();
        }
    }
    void PaintTile(Vector3 worldPos)
    {
        ClearPreviews(worldPos);
        RemoveTile(worldPos);

        if (map.GetTile(map.WorldToCell(worldPos)) == null)
        {
            map.SetTile(map.WorldToCell(worldPos), groundPreview);
            isDirty = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            map.SetTile(map.WorldToCell(worldPos), ground);
        }
        
    }
    void PaintPrefab(Vector3 worldPos, GameObject prefab, TileBase prefab_preview)
    {
        ClearPreviews(worldPos);

        if (map.GetTile(map.WorldToCell(worldPos)) == null)
        {
            map.SetTile(map.WorldToCell(worldPos), prefab_preview);
            isDirty = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
            Instantiate(prefab, new Vector3(map.WorldToCell(worldPos).x + 0.5f, map.WorldToCell(worldPos).y + 0.5f, 0f), Quaternion.identity);

        
    }
    public void ClearPreviews(Vector3 worldPos)
    {
        if (isDirty)
        {
            for (int i = 1; i <= 8; i++)
            {
                Vector3Int temp = new Vector3Int(map.WorldToCell(worldPos).x + directions[i - 1].x,
                                                 map.WorldToCell(worldPos).y + directions[i - 1].y, 0);

                if (map.GetTile(temp) == jumpPadPrefab_preview)
                {
                    map.SetTile(temp, null);
                }
                if (map.GetTile(temp) == playerPrefab_preview)
                {
                    map.SetTile(temp, null);
                }
                if (map.GetTile(temp) == laserPrefab_preview)
                {
                    map.SetTile(temp, null);
                }
                if (map.GetTile(temp) == doorPrefab_preview)
                {
                    map.SetTile(temp, null);
                }
                if (map.GetTile(temp) == ballPrefab_preview)
                {
                    map.SetTile(temp, null);
                }
                if (map.GetTile(temp) == groundPreview)
                {
                    map.SetTile(temp, null);
                }
            }
            isDirty = false;
        }
    }
    void Pause()
    {
        Time.timeScale = 0;
    }
    void Resume()
    {
        Time.timeScale = 1;
    }

    public void SetCurrent(GameObject prefab, TileBase prefab_preview)
    {
        currentPrefab = prefab;
        currentPrefab_preview = prefab_preview;
    }
    void RemoveTile(Vector3 worldPos)
    {
        if (doDestroy)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                map.SetTile(map.WorldToCell(worldPos), null);
            }
        }
    }
}
