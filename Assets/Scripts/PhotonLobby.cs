using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomOptions roomOptions = new RoomOptions();

    private void Awake()
    {
        lobby = this;
    }

    void Start()
    {
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRoom("Room");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", transform.position, Quaternion.identity, 0);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("Room", roomOptions, TypedLobby.Default);
    }
}
