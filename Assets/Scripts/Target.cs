using UnityEngine;

public class Target : MonoBehaviour
{
    public Sprite onSite, offSite;
    public int onTarget;
    public float radius;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Box")) return;
        _spriteRenderer.sprite = onSite;
        onTarget = 1;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (!other.gameObject.CompareTag("Box")) return;
        Vector3 targetPosition = transform.position, boxPosition = other.gameObject.transform.position;
        var distance = Vector2.Distance(
            new Vector2(boxPosition.x, boxPosition.y),
            new Vector2(targetPosition.x, targetPosition.y)
            );
        if (!(distance >= radius)) return;
        _spriteRenderer.sprite = offSite;
        onTarget = 0;


    }
}
