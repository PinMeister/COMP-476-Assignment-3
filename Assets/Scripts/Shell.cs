using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    Tank player;

    void Start()
    {
        player = transform.parent.gameObject.GetComponent<Tank>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(collision.gameObject);

            if (transform.parent.name == "Player 1")
            {
                player.player1Fired = false;
            }

            if (transform.parent.name == "Player 2")
            {
                player.player2Fired = false;
            }

            Destroy(this);
        }

        if (collision.gameObject.tag == "Tank") // if shell collides with tank, put it in "Dead" state
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            collision.gameObject.GetComponent<Tank>().alive = false;

            Destroy(this);
        }
    }
}
