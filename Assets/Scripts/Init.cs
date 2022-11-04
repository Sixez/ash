using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Init : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject mainCamera;
    void Awake()
    {
        Tilemap worldTileGrid = FindObjectOfType<Tilemap>();
        Vector2 spawnPos = Vector2.zero;
        print(worldTileGrid.size);
        for (int i = 0; i < worldTileGrid.size.x; i++)
        {
            for (int j = 0; j < worldTileGrid.size.y; j++)
            {
                TileBase tile = worldTileGrid.GetTile(new Vector3Int(i, j, -1));

				if (tile && tile.name.Equals("SpawnPoint"))
                {
                    spawnPos.x = i + 0.5f;
                    spawnPos.y = j + 0.5f;
                }
            }
        }
        GameObject player = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        player.name = playerPrefab.name;
        mainCamera.transform.SetParent(player.transform);
        mainCamera.transform.localPosition = new Vector3(0, 0.5f, -10);

        Destroy(GameObject.Find("loader"));
    }
}
