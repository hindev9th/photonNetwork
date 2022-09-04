using UnityEngine;
using Photon.Pun;
using TMPro;

public class PhotonLogin : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI textName;
    public TMP_InputField inputYourName;
    [SerializeField]private GameObject btnLogout,panelRoom;
    public virtual void Login(){
        PhotonNetwork.LocalPlayer.NickName = inputYourName.text;
        PhotonNetwork.ConnectUsingSettings();
        if(PhotonNetwork.IsConnected){
            textName.text = "Name: " + PhotonNetwork.LocalPlayer.NickName;
            inputYourName.enabled = false;
            btnLogout.SetActive(true);
            panelRoom.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("lobby");
    }
}
