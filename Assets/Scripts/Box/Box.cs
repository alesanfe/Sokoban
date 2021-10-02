
using UnityEngine;

namespace Box
{
    public class Box : MonoBehaviour
    {
        private Rigidbody2D _boxRb;
        private float _time;
        private bool _exit;
        
        private void Awake()
        {
            _boxRb = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) _boxRb.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player")) _exit = true;
        }

        private void FixedUpdate()
        {
            if (!_exit) return;
            _time += Time.fixedDeltaTime;
            if (!(_time >= 1f)) return;
            _boxRb.bodyType = RigidbodyType2D.Static;
            _time = 0;
        }
    }
}
