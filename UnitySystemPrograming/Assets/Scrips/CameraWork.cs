
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [Header("카메라가 따라갈 타겟")]
    public Transform target; // 플레이어의 Transform

    [Header("카메라 설정")]
    public Vector3 offset = new Vector3(0f, 5f, -7f); // 플레이어와의 거리 및 높이
    public float smoothSpeed = 10f; // 카메라가 따라오는 속도 (값이 클수록 빠름)

    // 모든 Update()가 끝난 후에 호출되는 함수. 카메라 움직임에 사용하면 떨림이 없음.
    void LateUpdate() {
        // 타겟(플레이어)이 없으면 아무것도 하지 않음
        if (target == null) return;

        // 1. 원하는 카메라 위치 계산
        // 플레이어의 위치 + (플레이어의 회전값 * 설정된 거리)
        // 이렇게 하면 플레이어가 회전할 때 offset도 함께 회전해서 항상 등 뒤에 있게 됨
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // 2. 현재 카메라 위치에서 원하는 위치로 부드럽게 이동
        // Vector3.Lerp(시작위치, 목표위치, 속도)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // 3. 항상 타겟을 바라보도록 설정
        transform.LookAt(target);
    }
}
