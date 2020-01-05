using UnityEngine;


namespace Matt
{
    public class CameraControl : MonoBehaviour
    {
        [Header("速度"), Range(0, 10)]
        public float speed = 10;

        private Transform target;

        private void Start()
        {
            target = GameObject.Find("Hero").transform;
        }

        private void LateUpdate()
        {
            Vector3 cam = transform.position;
            Vector3 tar = target.position;
            tar.z = -10;
            tar.y = Mathf.Clamp(tar.y, -0, 0);
            tar.x = Mathf.Clamp(tar.x, -0.03f, 34.6f);
            transform.position = Vector3.Lerp(cam, tar, 1.0f * Time.deltaTime * speed);
        }
    }
}

