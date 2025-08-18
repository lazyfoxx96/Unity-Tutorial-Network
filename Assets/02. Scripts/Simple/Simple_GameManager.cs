using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Simple_GameManager : MonoBehaviourPun
{
    IEnumerator Start()
    {
        yield return null;

        // 생성 및 동기화
        PhotonNetwork.Instantiate("Player", Vector3.up, Quaternion.identity);
    }
}
