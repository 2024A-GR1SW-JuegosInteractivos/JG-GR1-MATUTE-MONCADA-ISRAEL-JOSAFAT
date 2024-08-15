using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float fastSpeed = 25f;
    [SerializeField] float lowSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -1 * steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión con: " + other.tag);
        Debug.Log(other);
        if (other.tag == "Rapido")
        {
            Debug.Log("Ir rapido");
            moveSpeed = fastSpeed;
        }

        if (other.tag == "Lento")
        {
            Debug.Log("Ir lento");
            moveSpeed = lowSpeed;
        }

    }
}
