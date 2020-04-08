using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviourPun
{
    [SerializeField] float speed = 20;
    [SerializeField] GameObject shellPrefab;
    [SerializeField] Transform fireTransform;
    public Vector3 position;
    public Vector3 destination;
    public Vector3 direction;
    public bool cooldown;
    public float timer;

    public bool north;
    public bool south;
    public bool east;
    public bool west;

    void Start()
    {
        timer = 1;
    }

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
            north = false;
            south = true;
            east = false;
            west = false;
        }
        if (transform.position == new Vector3(-41, 0, 29))
        {
            position = new Vector3(-41, 0, 29);
            destination = new Vector3(5, 0, 29);
            north = false;
            south = false;
            east = true;
            west = false;
        }
        if (transform.position == new Vector3(5, 0, 29))
        {
            position = new Vector3(5, 0, 29);
            destination = new Vector3(5, 0, 45);
            north = true;
            south = false;
            east = false;
            west = false;
        }
        if (transform.position == new Vector3(5, 0, 45))
        {
            position = new Vector3(5, 0, 45);
            destination = new Vector3(-41, 0, 45);
            north = false;
            south = false;
            east = false;
            west = true;
        }        
        
        // Set destination for Zombie 2
        if (transform.position == new Vector3(17, 0, 15))
        {
            position = new Vector3(17, 0, 15);
            destination = new Vector3(17, 0, -15);
            north = false;
            south = true;
            east = false;
            west = false;
        }
        if (transform.position == new Vector3(17, 0, -15))
        {
            position = new Vector3(17, 0, -15);
            destination = new Vector3(-41, 0, -15);
            north = false;
            south = false;
            east = false;
            west = true;
        }
        if (transform.position == new Vector3(-41, 0, -15))
        {
            position = new Vector3(-41, 0, -15);
            destination = new Vector3(-41, 0, 15);
            north = true;
            south = false;
            east = false;
            west = false;
        }
        if (transform.position == new Vector3(-41, 0, 15))
        {
            position = new Vector3(-41, 0, 15);
            destination = new Vector3(17, 0, 15);
            north = false;
            south = false;
            east = true;
            west = false;
        }

        if (north)
        {
            direction = new Vector3(0, 0, 1);
        }
        if (south)
        {
            direction = new Vector3(0, 0, -1);
        }
        if (east)
        {
            direction = new Vector3(1, 0, 0);
        }
        if (west)
        {
            direction = new Vector3(-1, 0, 0);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.LookAt(destination);

        // Shoot if player tank is directly in front of them with no obstacles between them
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            Debug.DrawRay(transform.position, direction * 50, Color.green);
            if (hit.collider.tag == "Tank" && !cooldown)
            {
                AudioSource shooting = GetComponent<AudioSource>();
                shooting.Play();

                GameObject shell = PhotonNetwork.Instantiate("Shell", fireTransform.position, this.transform.rotation);
                shell.transform.localScale = new Vector3(4, 4, 4);
                cooldown = true;
            }
        }

        if (cooldown)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 1;
                cooldown = false;
            }
        }
    }
}
