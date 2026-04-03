using UnityEngine;

public class FloatingFeedback : MonoBehaviour
{
    private float floatSpeed = 1.5f;
    private float duration = 1f;
    private float elapsed = 0f;

    private Vector3 initialScale;
    private SpriteRenderer spriteRenderer;
    private FeedbackSoundManager feedbackSoundManager;
    public void Initialize(float speed, float displayDuration, bool isCorrect)
    {
        floatSpeed = speed;
        duration = displayDuration;
        initialScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        feedbackSoundManager = FindObjectOfType<FeedbackSoundManager>();
        if (spriteRenderer == null)
        {
            
        }
    }

    void Update()
    {
        float delta = Time.deltaTime;
        elapsed += delta;

        
        transform.position += Vector3.up * floatSpeed * delta;

        
        float scaleFactor = Mathf.Lerp(1f, 1.3f, elapsed / duration);
        transform.localScale = initialScale * scaleFactor;

        
        if (spriteRenderer != null)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            Color c = spriteRenderer.color;
            c.a = alpha;
            spriteRenderer.color = c;
        }

        if (elapsed >= duration)
            Destroy(gameObject);
    }
}