using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Rigidbody TrashRigidbody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        TrashRigidbody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }

    public void useRigiBbody() // 쓰레기에게 물리처리를 하게 하는 메소드
    {
        TrashRigidbody.useGravity = true;
        TrashRigidbody.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) // 쓰레기통 골인 이후 처리
        {
            GameManager.Instance.SetCount(); // 쓰래기 갯수를 하나 줄인다.
            audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        if (other.CompareTag("Hand")) // 플레이어 콘트롤러와 충돌하였을 때 처리
        {
            useRigiBbody(); // 이제 물리 처리를 한다.
        }
    }
}
