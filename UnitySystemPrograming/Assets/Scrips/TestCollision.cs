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
}
