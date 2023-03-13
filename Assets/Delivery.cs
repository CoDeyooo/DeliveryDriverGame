using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = Color.white;
    [SerializeField] Color32 noPackageColor = Color.white;
    private bool hasPackage = false;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !this.hasPackage)
        {
            this.hasPackage = true;
            this.spriteRenderer.color = this.hasPackageColor;
            other.gameObject.SetActive(false);
            Spawner.SpawnCustomer();
            
        }
        else if (other.tag == "Customer" && this.hasPackage)
        {
            this.hasPackage = false;
            this.spriteRenderer.color = this.noPackageColor;
            other.gameObject.SetActive(false);
            Spawner.SpawnPackage();
        }
    }
}
