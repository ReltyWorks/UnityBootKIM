
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] Define.CameraMode mode = Define.CameraMode.QuarterView;
    [SerializeField] Vector3 delta = Vector3.zero;
    [SerializeField] PlayerController pc;

    void LateUpdate() {

        if (mode == Define.CameraMode.QuarterView) {
            transform.position = pc.transform.position + delta;
            transform.LookAt(pc.transform);
        }
    }

    public void SetQuarterView(Vector3 _delta) {

    }
}
