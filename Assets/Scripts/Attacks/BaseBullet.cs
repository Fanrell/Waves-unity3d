using UnityEngine;

namespace Attacks
{
    public class BaseBullet : MonoBehaviour
    {
        public float aliveTime = 5f;
        public float speed = 3f;
        public Vector3 direction = Vector3.up;
        public Vector3 startPosition = new Vector3();
        public Color lightColor = Color.red;

        private void Start()
        {
            var light = GetComponent(typeof(Light)) as Light;
            light.color = lightColor;
            transform.position = startPosition;
        }

        void Update()
        {
            var position = transform.position;
            position = Vector3.LerpUnclamped(position, position + direction, speed * Time.deltaTime);
            transform.position = position;
        }

        private void LateUpdate()
        {
            aliveTime -= 1f;
            if(aliveTime <= 0)
                Destroy(gameObject);
            
        }
    }
}
