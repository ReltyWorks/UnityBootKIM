using UnityEngine;

public class TestCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        // �Ϲ�����
        Debug.Log("Collision!");
    }

    void OnTriggerEnter(Collider other) {
        // isTrigger�� ������
        Debug.Log("Trigger!!!");
    }

    void OnTriggerExit(Collider other) {
        // ������
        Debug.Log("Trigger!!! EXEX");
    }

    void OnTriggerStay(Collider other) {
        // ���?
        Debug.Log("Trigger!!! STST");
    }
}
