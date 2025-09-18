using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float rororo = 0.1f;
    [SerializeField] float rotateSpeed = 120f;


    void Start() {
        Managers.Input.KeyAction -= OnKeyBoard;
        Managers.Input.KeyAction += OnKeyBoard;
    }




    void Update() {

        //if (Input.GetKey(KeyCode.W)) {
        //    // ���� ��ǥ�� ������
        //    // transform.position += Vector3.forward * Time.deltaTime * speed;
        //    // �ڱ� �������� ������
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //    // ȸ��
        //    // transform.rotation = Quaternion.LookRotation(Vector3.forward);
        //    // �ε巯�� ȸ��
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), rororo);
        //}
            
        //if (Input.GetKey(KeyCode.A)) {
        //    // transform.position += Vector3.left * Time.deltaTime * speed;
        //    // transform.Translate(Vector3.left * Time.deltaTime * speed);
        //    // transform.rotation = Quaternion.LookRotation(Vector3.left);
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), rororo);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(1f, 0f, 0f) * Time.deltaTime), rororo);
        //}

        //if (Input.GetKey(KeyCode.S)) {
        //    // transform.position += Vector3.back * Time.deltaTime * speed;
        //    transform.Translate(Vector3.back * Time.deltaTime * speed);
        //    // transform.rotation = Quaternion.LookRotation(Vector3.back);
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), rororo);
        //}

        //if (Input.GetKey(KeyCode.D)) {
        //    // transform.position += Vector3.right * Time.deltaTime * speed;
        //    //transform.Translate(Vector3.right * Time.deltaTime * speed);
        //    //transform.rotation = Quaternion.LookRotation(Vector3.right);
        //    // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), rororo);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(-1f, 0f, 0f) * Time.deltaTime), rororo);
        //}

    }

    void OnKeyBoard() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
