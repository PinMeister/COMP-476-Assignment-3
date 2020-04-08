using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView view;
    public GameObject avatar;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
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
