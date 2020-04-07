using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] float moveSpeed = 30;
    [SerializeField] float rotateSpeed = 100;
    public bool player1Fired;
    public bool player2Fired;
    public bool alive;

    void Start()
    {
        player1Fired = false;
        player2Fired = false;
        alive = true;
    }

    void Update()
    {
        if (alive)
        {
            if (Input.GetAxisRaw("Vertical") < 0)
                transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Vertical") > 0)
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") < 0)
                transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
            if (Input.GetAxisRaw("Horizontal") > 0)
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space)) // press space to fire projectile
            {
                if (this.name == "Player 1")
                {
                    player1Fired = true;
                }
                if (this.name == "Player 2")
                {
                    player2Fired = true;
                }
            }
        }
    }
}
