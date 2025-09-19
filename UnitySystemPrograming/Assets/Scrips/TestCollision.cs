using UnityEngine;

public class TestCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        // 일반적인
        Debug.Log("Collision!");
    }

    void OnTriggerEnter(Collider other) {
        // isTrigger를 켰을떼
        Debug.Log("Trigger!!!");
    }

    void OnTriggerExit(Collider other) {
        // 나갈때
        Debug.Log("Trigger!!! EXEX");
    }

    void OnTriggerStay(Collider other) {
        // 기달?
        Debug.Log("Trigger!!! STST");
    }

    void Update() {
        // Local <-> World <-> Viewport <-> Screen
        // 
        

        // 트랜스폼 다이렉션 = 매개변수로의 방향을 반환함
        // 이걸 Vector3.forward와 바꾸면 바라보는 방향에 따라 바뀜
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
