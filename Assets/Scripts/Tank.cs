using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] float moveSpeed = 30;
    [SerializeField] float rotateSpeed = 100;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Vertical") > 0)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") < 0)
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
        if (Input.GetAxisRaw("Horizontal") > 0)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
