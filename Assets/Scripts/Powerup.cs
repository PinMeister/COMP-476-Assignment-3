using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float timer;
    
    void Start()
    {
        timer = 0.5f;
    }

    void Update() // powerup flashing effect
    {
        timer -= Time.deltaTime;

        if (transform.childCount > 0)
        {
            if (timer <= 0 && transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                timer = 0.5f;
            }
            else if (timer <= 0 && transform.GetChild(0).gameObject.activeInHierarchy == false)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                timer = 0.5f;
            }
        }
    }
}
