using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float rororo = 0.1f;
    [SerializeField] float rotateSpeed = 120f;

    bool moveToDest = false;
    Vector3 _destPos;
    Animator anim;

    void Start()
    {
        // Managers.Input.KeyAction += OnKeyBoard;
        Managers.Input.MouseAction += OnMouseClicked;
        anim = GetComponent<Animator>();

    }

    float wait_run_ratio;
    bool isJumping = false;
    bool isFalling = false;
    bool isCastring = false;

    

    enum PlayerState
    {
        DIE,
        MOVING,
        IDLE,
        CASTING,
        JUMPING,
        FALLING
    }

    PlayerState _state = PlayerState.IDLE;

    void UpdateDie()
    {

    }

    void OnRunEvent()
    {
        // Debug.Log("왼발");
    }

    void UpdateMoving()
    {
        Vector3 dir = _destPos - transform.position;

        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.IDLE;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1f, 10.0f * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");

        anim.SetBool("isRun", true);
    }

    void UpdateIdle()
    {
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0f, 10.0f * Time.deltaTime);
        //anim.SetFloat("wait_run_ratio", wait_run_ratio);
        //anim.Play("WAIT_RUN");
        anim.SetBool("isRun", false);
    }

    void Update()
    {   
        /*
        //if (Input.GetKey(KeyCode.W)) {
        //    // 월드 좌표로 움직임
        //    // transform.position += Vector3.forward * Time.deltaTime * speed;
        //    // 자기 기준으로 움직임
        //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //    // 회전
        //    // transform.rotation = Quaternion.LookRotation(Vector3.forward);
        //    // 부드러운 회전
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
        */

        switch (_state)
        {
            case PlayerState.DIE:
                UpdateDie();
                break;
            case PlayerState.MOVING:
                UpdateMoving();
                break;
            case PlayerState.IDLE:
                UpdateIdle();
                break;
            case PlayerState.CASTING:
                break;
            case PlayerState.JUMPING:
                break;
            case PlayerState.FALLING:
                break;
            default:
                break;  
        }
    }

    /*
    void OnKeyBoard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        moveToDest = false;
    }
    */

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {

            _destPos = hit.point;

            _state = PlayerState.MOVING;

            // moveToDest = true;

            // Debug.Log($"Raycast Camera : {hit.collider.gameObject.name}");
        }
    }
}