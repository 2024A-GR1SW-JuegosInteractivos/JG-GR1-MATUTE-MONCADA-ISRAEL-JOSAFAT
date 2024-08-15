using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    [SerializeField] float delayDestroy = 0.5f;
    [SerializeField] Color32 sickColor = new Color(1f, 0f, 0f, 1f);
    [SerializeField] Color32 noSickColor = new Color(1f, 1f, 1f, 1f);
    private SpriteRenderer spriteRenderer;
    bool isSick;

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

        if (other.tag == "Manzana" && !isSick)
        {
            transform.localScale *= 1.04f;
            Destroy(other.gameObject, delayDestroy);
        }else if(other.tag == "Papas" && !isSick) {   
            isSick = true;
            spriteRenderer.color = sickColor;
            Destroy(other.gameObject, delayDestroy);
        }else if(other.tag == "Papas" && isSick) {   
            isSick = true;
            spriteRenderer.color = sickColor;
            Destroy(gameObject, delayDestroy);
        }

        if (other.tag == "Hospital" && isSick)
        {
            isSick = false;
            spriteRenderer.color = noSickColor;
        }

    }

}
