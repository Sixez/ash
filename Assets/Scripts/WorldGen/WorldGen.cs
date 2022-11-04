using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGen : MonoBehaviour
{
    public GameObject tilegridPrefab;
    public GameObject tilemapPrefab;

    internal void Generate()
    {
        GameObject tilegrid = Instantiate(tilegridPrefab);
        GameObject tilemap = Instantiate(tilemapPrefab);
        Tilemap tilePallete = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Tiles/TilePallete.prefab").transform.GetChild(0).gameObject.GetComponent<Tilemap>();

		tilegrid.name = "TileGrid";
        tilemap.name = "TileMap";
        tilemap.transform.SetParent(tilegrid.transform);

        Grid grid = tilegrid.AddComponent<Grid>();
        Tilemap map = tilemap.AddComponent<Tilemap>();
        tilemap.AddComponent<TilemapRenderer>();

        grid.cellSize = new Vector3(1, 1, 0);

        for (int i =  0; i < 32; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                map.SetTile(new Vector3Int(i, j), tilePallete.GetTile(new Vector3Int(1, 0)));
            }
        }
        map.SetTile(new Vector3Int(16, 4, -1), tilePallete.GetTile(new Vector3Int(0, 0)));
    }
}
