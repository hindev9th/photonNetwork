using UnityEngine;
using Photon.Pun;
using TMPro;
public class PhotonCreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]private TMP_InputField inputRoom;
    
    public virtual void createRoom(){
        string room = inputRoom.text;
        PhotonNetwork.CreateRoom(room);
    }
    public virtual void leaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
}
