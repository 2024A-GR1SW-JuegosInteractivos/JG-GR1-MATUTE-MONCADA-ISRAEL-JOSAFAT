using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    [SerializeField] float delayDestroy = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color(1f, 0f, 0f, 1f);
    [SerializeField] Color32 noHasPackageColor = new Color(1f, 1f, 1f, 1f);
    private SpriteRenderer spriteRenderer;
    bool hasPackage;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Choque");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter Trigger!");

        if (other.tag == "Paquete" && hasPackage)
        {
            Debug.Log("Tanque Destruidp");
            Destroy(gameObject, delayDestroy);
        }else if(other.tag == "Paquete" && !hasPackage) {   
            Debug.Log("Paquete recogido");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, delayDestroy);
        }

        if (other.tag == "Cliente" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noHasPackageColor;
            Debug.Log("Paquete Entregado");
        }

    }

}
