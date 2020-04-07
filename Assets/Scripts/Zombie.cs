using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] float speed = 20;
    public Vector3 position;
    public Vector3 destination;

    void Update()
    {
        if ((destination - transform.position).magnitude < 1)
        {
            transform.position = destination;
        }

        // Set destination for Zombie 1
        if (transform.position == new Vector3(-41, 0, 45))
        {
            position = new Vector3(-41, 0, 45);
            destination = new Vector3(-41, 0, 29);
        }
        if (transform.position == new Vector3(-41, 0, 29))
        {
            position = new Vector3(-41, 0, 29);
            destination = new Vector3(5, 0, 29);
        }
        if (transform.position == new Vector3(5, 0, 29))
        {
            position = new Vector3(5, 0, 29);
            destination = new Vector3(5, 0, 45);
        }
        if (transform.position == new Vector3(5, 0, 45))
        {
            position = new Vector3(5, 0, 45);
            destination = new Vector3(-41, 0, 45);
        }        
        
        // Set destination for Zombie 2
        if (transform.position == new Vector3(17, 0, 15))
        {
            position = new Vector3(17, 0, 15);
            destination = new Vector3(17, 0, -15);
        }
        if (transform.position == new Vector3(17, 0, -15))
        {
            position = new Vector3(17, 0, -15);
            destination = new Vector3(-41, 0, -15);
        }
        if (transform.position == new Vector3(-41, 0, -15))
        {
            position = new Vector3(-41, 0, -15);
            destination = new Vector3(-41, 0, 15);
        }
        if (transform.position == new Vector3(-41, 0, 15))
        {
            position = new Vector3(-41, 0, 15);
            destination = new Vector3(17, 0, 15);
        }

        Vector3 velocity = destination - position;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.LookAt(destination);
    }
}
