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

    void Update() {
        // Local <-> World <-> Viewport <-> Screen
        // 
        

        // Ʈ������ ���̷��� = �Ű��������� ������ ��ȯ��
        // �̰� Vector3.forward�� �ٲٸ� �ٶ󺸴� ���⿡ ���� �ٲ�
        Vector3 look = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach(RaycastHit hit in hits) {
            Debug.Log($"Raycast Hit : {hit.collider.gameObject.name}");
        }

        //if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10)) {
        //    Debug.Log($"Raycast Hit : {hit.collider.gameObject.name}");
        //}

    }
}
