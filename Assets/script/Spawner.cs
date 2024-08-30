using UnityEngine;

namespace Spawner 
{
    public class ObstacleSpawner : MonoBehaviour
    {
        public GameObject obstaclePrefab;
        public float spawnTime = 2f;
        public Vector2 centerPosition = new Vector2(0, 0);
        public float spawnRadius = 5f;

        private void Start()
        {
            InvokeRepeating("SpawnObstacle", spawnTime, spawnTime);
        }

        void SpawnObstacle()
        {
            float angle = Random.Range(0, Mathf.PI * 2);
            float radius = Random.Range(0, spawnRadius);

            float x = centerPosition.x + radius * Mathf.Cos(angle);
            float y = centerPosition.y + radius * Mathf.Sin(angle);
            Vector3 spawnPosition = new Vector3(x, y, 0);

            GameObject spawnedObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            Destroy(spawnedObstacle, Random.Range(3, 6));
        }
    }
}
