using UnityEngine;

namespace Box
{
    public class Back : MonoBehaviour
    {
        
        public SpriteRenderer body, head;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            body.sortingOrder = -1;
            head.sortingOrder = -1;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            body.sortingOrder = 1;
            head.sortingOrder = 1;
        }
    }
}
