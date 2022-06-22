using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject players;

    private void Start()
    {
        SpawnPlayers();
    }

    private void OnLevelWasLoaded(int level)
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        players.transform.position = transform.position;

    }
    //todo: balanceboard
    // check if spikes/lava can be integrated in tile palette (prefabs with scripts)
}
