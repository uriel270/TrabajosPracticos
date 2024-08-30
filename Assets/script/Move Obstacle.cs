using UnityEngine;

namespace MoveObstaculer 
{
    public class MoveObstacle : MonoBehaviour
    {
        public float speed = 5.0f;
        private int direction;

        void Start()
        {
            direction = Random.Range(0, 2) * 2 - 1;
        }

        void Update()
        {
            transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
        }
    }
}
