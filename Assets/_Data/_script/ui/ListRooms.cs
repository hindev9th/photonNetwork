using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class ListRooms : MonoBehaviourPunCallbacks
{
    public Transform roomContent;
    public UIRoomInfo uIRoomInfo;
    public List<RoomInfo> updatedRooms;
    public List<RoomProfile> rooms = new List<RoomProfile>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        this.updatedRooms = roomList;

        foreach(RoomInfo roomInfo in roomList){
            if(roomInfo.RemovedFromList) this.RoomRemove(roomInfo);
            else this.RoomAdd(roomInfo);
        }
        this.UpdateRoomProfileUI();
    }

    protected virtual void RoomAdd(RoomInfo roomInfo){
        RoomProfile roomProfile;

        roomProfile = this.RoomByName(roomInfo.Name);
        if(roomProfile != null) return;

        roomProfile = new RoomProfile{
            name = roomInfo.Name,
            countCurrentPlayer = roomInfo.PlayerCount,
            maxCountPlayer = roomInfo.MaxPlayers
        };
        this.rooms.Add(roomProfile);
    }
    protected virtual void RoomRemove(RoomInfo roomInfo){
        RoomProfile roomProfile = this.RoomByName(roomInfo.Name);
        if(roomProfile == null) return;
        this.rooms.Remove(roomProfile);
    }
    
    protected virtual RoomProfile RoomByName(string name){
        foreach(RoomProfile roomProfile in this.rooms){
            if(roomProfile.name == name) return roomProfile;
        }
        return null;
    }

    public virtual void UpdateRoomProfileUI(){
        foreach(Transform chlid in this.roomContent){
            Destroy(chlid.gameObject);
        }

        foreach(RoomProfile roomProfile in this.rooms){
            UIRoomInfo uIRoomInfo = Instantiate(this.uIRoomInfo);
            uIRoomInfo.SetRoomProfile(roomProfile);
            uIRoomInfo.transform.SetParent(this.roomContent);
        }
    }
}
