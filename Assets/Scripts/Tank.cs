using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviourPun
{
    [SerializeField] float moveSpeed = 30;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] Transform fireTransform;
    public bool alive;
    public bool cooldown;
    public bool poweredUp;
    public float timer;
    public float boostTimer;

    void Start()
    {
        alive = true;
        timer = 0.75f;
        boostTimer = 3;
    }

    void Update()
    {
        if (photonView.IsMine && alive) // can only move and shoot while alive
        {
            if (Input.GetAxisRaw("Vertical") < 0)
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Vertical") > 0)
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") < 0)
                transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") > 0)
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && !cooldown) // press space to fire projectile, cannot spam projectiles
            {
                AudioSource shooting = GetComponent<AudioSource>();
                shooting.Play();

                GameObject shell = PhotonNetwork.Instantiate("Shell", fireTransform.position, this.transform.rotation);
                shell.transform.localScale = new Vector3(4, 4, 4);
                cooldown = true;
            }
            
            if (cooldown)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    timer = 0.75f;
                    cooldown = false;
                }
            }

            if (poweredUp)
            {
                //transform.GetChild(2).gameObject.SetActive(true);
                moveSpeed = 60;
                boostTimer -= Time.deltaTime;

                if (boostTimer <= 0)
                {
                    boostTimer = 3;
                    moveSpeed = 30;
                    photonView.RPC("undoPowerUp", RpcTarget.All);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other) // pick up powerup and destroy it
    {
        if (!poweredUp)
        {
            poweredUp = true;
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    [PunRPC]
    private void undoPowerUp()
    {
        poweredUp = false;
        //transform.GetChild(2).gameObject.SetActive(false);
    }
}
