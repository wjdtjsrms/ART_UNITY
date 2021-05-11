using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Rigidbody Trashrigidbody;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Trashrigidbody = this.GetComponent<Rigidbody>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void useRigiBbody()
    {
        Trashrigidbody.useGravity = true;
        Trashrigidbody.isKinematic = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) // 골이랑 충돌 후 처리
        {
            GameManager.Instance.SetCount();
            audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        if (other.CompareTag("Hand")) // 플레이어 콘트롤러와 충돌하였을 때 처리
        {
            useRigiBbody(); // 이제 물리 처리를 한다.
        }
    }
}
