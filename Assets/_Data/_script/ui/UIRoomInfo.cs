using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIRoomInfo : MonoBehaviour
{
    [SerializeField]protected TextMeshProUGUI roomName,roomInfo;
    [SerializeField]protected RoomProfile roomProfile;

    public virtual void SetRoomProfile(RoomProfile roomProfile){
        this.roomProfile = roomProfile;
        this.roomName.text = this.roomProfile.name;
        this.roomInfo.text = this.roomProfile.countCurrentPlayer + "/" + this.roomProfile.maxCountPlayer;
    }
}
