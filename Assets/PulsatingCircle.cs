using UnityEngine;

public class PulsatingCircle : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 2f;

    private SpriteRenderer spriteRenderer;
    private float scale = 2f;

    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        scale = 1f + this.amplitude * Mathf.Sin(this.frequency * Time.time);
        transform.localScale = new Vector3(this.scale, this.scale, 1f);
        
        Color newColor = this.spriteRenderer.color;
        newColor.a = this.scale;
        this.spriteRenderer.color = newColor;
    }
}
