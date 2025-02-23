using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon Cloud
    }

    public override void OnConnectedToMaster()
    {
        // It's typically better to not disable the message queue unless necessary.
        PhotonNetwork.JoinOrCreateRoom(
            "MainLobby",
            new RoomOptions { MaxPlayers = 20 },
            TypedLobby.Default
        );
        if (!PhotonNetwork.IsMasterClient)
            PhotonNetwork.IsMessageQueueRunning = false; // Disable message queue to prevent updates during connection
        Debug.Log("Connected to Photon, Joining Room...");
        // Try joining or creating the room
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Master Client: " + PhotonNetwork.MasterClient.NickName);
        Debug.Log("Is Master Client: " + PhotonNetwork.IsMasterClient);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError($"Failed to join room: {message}");
    }

    // Optionally, log if you failed to connect to the master server:
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError("Disconnected from Photon: " + cause.ToString());
    }
}
