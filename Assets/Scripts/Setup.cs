using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    public static Setup setup;

    public List<Transform> spawnLocations;

    private void OnEnable()
    {
        if (setup == null)
        {
            setup = this;
        }
    }
}
