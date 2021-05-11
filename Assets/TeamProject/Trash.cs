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
        if (other.CompareTag("Goal")) // ���̶� �浹 �� ó��
        {
            GameManager.Instance.SetCount();
            audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        if (other.CompareTag("Hand")) // �÷��̾� ��Ʈ�ѷ��� �浹�Ͽ��� �� ó��
        {
            useRigiBbody(); // ���� ���� ó���� �Ѵ�.
        }
    }
}
