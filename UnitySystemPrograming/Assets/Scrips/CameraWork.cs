
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    [Header("ī�޶� ���� Ÿ��")]
    public Transform target; // �÷��̾��� Transform

    [Header("ī�޶� ����")]
    public Vector3 offset = new Vector3(0f, 5f, -7f); // �÷��̾���� �Ÿ� �� ����
    public float smoothSpeed = 10f; // ī�޶� ������� �ӵ� (���� Ŭ���� ����)

    // ��� Update()�� ���� �Ŀ� ȣ��Ǵ� �Լ�. ī�޶� �����ӿ� ����ϸ� ������ ����.
    void LateUpdate() {
        // Ÿ��(�÷��̾�)�� ������ �ƹ��͵� ���� ����
        if (target == null) return;

        // 1. ���ϴ� ī�޶� ��ġ ���
        // �÷��̾��� ��ġ + (�÷��̾��� ȸ���� * ������ �Ÿ�)
        // �̷��� �ϸ� �÷��̾ ȸ���� �� offset�� �Բ� ȸ���ؼ� �׻� �� �ڿ� �ְ� ��
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // 2. ���� ī�޶� ��ġ���� ���ϴ� ��ġ�� �ε巴�� �̵�
        // Vector3.Lerp(������ġ, ��ǥ��ġ, �ӵ�)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // 3. �׻� Ÿ���� �ٶ󺸵��� ����
        transform.LookAt(target);
    }
}
