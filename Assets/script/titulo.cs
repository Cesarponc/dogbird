using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titulo : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject columnPrefab;

    public float columnMin = -2f;
    public float columnMax = 1.2f;
    private float spawnXPosition = 8.5f;

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15, 0);

    private float timeSinceLastSpawned;
    public float spawnRate;

    private int currentColumn;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }

        }

        
    }
   
}
