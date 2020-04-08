using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviourPun
{
    [SerializeField] public float shellSpeed = 60;
    public bool poweredUp;
    AudioSource explosion;

    void Start()
    {
        explosion = GameObject.Find("Shell Explosion").GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Translate(transform.forward * shellSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") // destroy wall upon collision, if powered up, can destroy two walls
        {
            if (poweredUp)
            {
                photonView.RPC("powerUpShell", RpcTarget.Others);
                Destroy(collision.gameObject);
                explosion.Play();
                poweredUp = false;
            }
            else
            {
                Destroy(collision.gameObject);
                explosion.Play();
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Tank") // if shell collides with tank, put it in "Dead" state and stop game
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            collision.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            collision.gameObject.GetComponent<Tank>().alive = false;
            explosion.Play();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    private void powerUpShell()
    {
        poweredUp = true;
    }
}
