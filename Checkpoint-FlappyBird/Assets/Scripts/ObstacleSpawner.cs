using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    //Public varibles are editable from the inspector
    public GameObject obstaclePrefab;
    public float minY;
    public float maxY;
    public float distance;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Obstacle")
        {
            //Choose random Y position
            float obstacleY = Random.Range(minY, maxY);
            //Destroy passed Obstacle
            Destroy(col.gameObject);
            //Choose a position for the new obstacle
            Vector3 spawnPosition = new Vector3(transform.position.x + distance, obstacleY, 0);
            //Instantiate the new obstacle
            Instantiate(obstaclePrefab, spawnPosition , Quaternion.identity);
            
        }
    }
}
