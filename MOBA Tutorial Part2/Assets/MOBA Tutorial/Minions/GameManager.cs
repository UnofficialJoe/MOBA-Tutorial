using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject minionPrefab;
    public GameObject redMinionPrefab;
    Vector3 blueSpawnLocation = new Vector3(-45, 1, -45);
    Vector3 redSpawnLocation = new Vector3(45, 1, 45);
    Vector3 botLaneLocation = new Vector3(45, 1, -45);
    Vector3 topLaneLocation = new Vector3(-45, 1, 45);
    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            GameObject minionSpawned;
            //Blue Minion Instantiate
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = redSpawnLocation;
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = botLaneLocation;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = redSpawnLocation;
            minionSpawned = Instantiate(minionPrefab, blueSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = topLaneLocation;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = redSpawnLocation;

            //Red Minion Instantiate
            minionSpawned = Instantiate(redMinionPrefab, redSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = blueSpawnLocation;
            minionSpawned = Instantiate(redMinionPrefab, redSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = botLaneLocation;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = blueSpawnLocation;
            minionSpawned = Instantiate(redMinionPrefab, redSpawnLocation, Quaternion.identity);
            minionSpawned.GetComponent<MinionAIScript>().destination = topLaneLocation;
            minionSpawned.GetComponent<MinionAIScript>().finalDestination = blueSpawnLocation;

            spawn = false;
        }
       
    }
}
