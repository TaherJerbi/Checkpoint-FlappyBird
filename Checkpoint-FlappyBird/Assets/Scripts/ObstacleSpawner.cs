using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject obstaclePrefab;
    public float minY;
    public float maxY;
    public float distance;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Obstacle")
        {
            float obstacleY = Random.Range(minY, maxY);

            Destroy(col.gameObject);

            Vector3 spawnPosition = new Vector3(transform.position.x + distance, obstacleY, 0);

            Instantiate(obstaclePrefab, spawnPosition , Quaternion.identity);
            
        }
    }
}
