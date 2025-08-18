using Photon.Pun;
using System.Collections;
using TMPro;
using UnityEngine;

public class Fight_PlayerController : MonoBehaviourPun
{
    private Animator anim;
    [SerializeField] private TextMeshPro nickName;

    [SerializeField] private GameObject punchBox;
    [SerializeField] private GameObject KickBox;

    void Start()
    {
        anim = GetComponent<Animator>();

        //if (photonView.IsMine)
        //{
        //    nickName.text = PhotonNetwork.NickName;
        //    nickName.color = Color.green;
        //}
        //else
        //{
        //    nickName.text = photonView.Owner.NickName;
        //    nickName.color = Color.red;
        //}

    }

    void OnPunch()
    {
        StartCoroutine(PunchRoutine());
    }

    IEnumerator PunchRoutine()
    {
        anim.SetTrigger("Punch");

        yield return new WaitForSeconds(0.5f);
        punchBox.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        punchBox.SetActive(false);
    }

    void OnKick()
    {
            StartCoroutine(KickRoutine());
    }

    IEnumerator KickRoutine()
    {
            anim.SetTrigger("Kick");

            yield return new WaitForSeconds(0.5f);
            KickBox.SetActive(true);

            yield return new WaitForSeconds(0.5f);
            KickBox.SetActive(false);
    }
        
}

