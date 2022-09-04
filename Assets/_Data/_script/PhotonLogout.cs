using UnityEngine;
using Photon.Pun;
using TMPro;

public class PhotonLogout : MonoBehaviour
{
    [SerializeField]private GameObject btnLogin,panelRoom;
    public TMP_InputField inputYourName;
    [SerializeField]private TextMeshProUGUI textName;
    public virtual void Logout(){
        if(PhotonNetwork.IsConnected){
            PhotonNetwork.Disconnect();
            btnLogin.SetActive(true);
            inputYourName.enabled = true;
            textName.text = "";
            panelRoom.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
