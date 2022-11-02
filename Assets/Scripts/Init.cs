using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public GameObject playerPrefab;
    void Awake()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        player.name = playerPrefab.name;

        GameObject.Find("loader").SetActive(false);
    }
}
