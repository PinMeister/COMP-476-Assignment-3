using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviourPun
{
    public GameObject avatar;

    void Start()
    {
        if (photonView.IsMine)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                avatar = PhotonNetwork.Instantiate("Blue", Setup.setup.spawnLocations[0].position, Setup.setup.spawnLocations[0].rotation, 0);
            }
            else
            {
                avatar = PhotonNetwork.Instantiate("Red", Setup.setup.spawnLocations[1].position, Setup.setup.spawnLocations[1].rotation, 0);
            }
        }
    }
}
