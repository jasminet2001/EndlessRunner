using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacles();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstacleOne;
    public GameObject obstacleTwo;
    public GameObject obstacleThree;

    void SpawnObstacles()
    {
        //random point
        int ObstacleSpawnIndex = Random.Range(3, 8);
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform;

        int ObstacleSpawnIndexTwo = Random.Range(3, 8);
        Transform spawnPointTwo = transform.GetChild(ObstacleSpawnIndexTwo).transform;

        int ObstacleSpawnIndexThree = Random.Range(3, 8);
        Transform spawnPointThree = transform.GetChild(ObstacleSpawnIndexThree).transform;

        //spawn at the random point
        Instantiate(obstacleOne, spawnPoint.position, Quaternion.identity,transform);
        Instantiate(obstacleTwo, spawnPointTwo.position, Quaternion.identity, transform);
        Instantiate(obstacleThree, spawnPointThree.position, Quaternion.identity, transform);
    }
}
