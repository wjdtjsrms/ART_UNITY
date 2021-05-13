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

    public void useRigiBbody() // �����⿡�� ����ó���� �ϰ� �ϴ� �޼ҵ�
    {
        TrashRigidbody.useGravity = true;
        TrashRigidbody.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal")) // �������� ���� ���� ó��
        {
            GameManager.Instance.SetCount(); // ������ ������ �ϳ� ���δ�.
            audioSource.Play();
            Destroy(this.gameObject, 3f);
        }
        if (other.CompareTag("Hand")) // �÷��̾� ��Ʈ�ѷ��� �浹�Ͽ��� �� ó��
        {
            useRigiBbody(); // ���� ���� ó���� �Ѵ�.
        }
    }
}
