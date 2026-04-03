using System.Collections;
using UnityEngine;

public class BinZoom : MonoBehaviour
{
    public float zoomScale = 1.15f;
    public float zoomSpeed = 10f;

    private Vector3 originalScale;
    private Vector3 targetScale;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * zoomSpeed
        );
    }

    public void SetHighlighted(bool highlighted)
    {
        targetScale = highlighted ? originalScale * zoomScale : originalScale;
    }

    public void ResetScaleNow()
    {
        targetScale = originalScale;
        transform.localScale = originalScale;
    }
}