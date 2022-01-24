using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0f;


    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Happened");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Package" && !hasPackage)
        {
            Debug.Log("Package ");
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;
        }
        if (collision.tag=="Customer"&&hasPackage)
        {
            Debug.Log("Customer");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
