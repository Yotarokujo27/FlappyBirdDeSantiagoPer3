using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumnPull : MonoBehaviour
{
    public int collumnPoolSize = 5;
    public GameObject collumnPrefab;
    public float spawnRate = 4f;
    public float collumnMin = -1f;
    public float collumnMax = 3.5f;

    private GameObject[] collumns;
    private Vector2 objectPoolPosition = new Vector2 (10f, 0f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentcollumn = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        collumns = new GameObject[collumnPoolSize];
        for (int i = 0; i < collumnPoolSize; i++)
        {
            collumns[i] = (GameObject) Instantiate(collumnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned = Time.deltaTime;
        if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(collumnMin, collumnMax);
            collumns[currentcollumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentcollumn++;
            if(currentcollumn >= collumnPoolSize)
            {
                currentcollumn = 0;
            }
        }
    }
}
