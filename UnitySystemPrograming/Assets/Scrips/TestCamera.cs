using UnityEngine;

public class TestCamera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // 아래 세줄을 위에 한줄로 만듬
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir = dir.normalized;

            int mask = (1 << 8) | (1 << 9);
            int mask2 = LayerMask.GetMask("Monster", "Wall");

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("wall")))
            {
                Debug.Log($"Raycast Camera : {hit.collider.gameObject.name}");
            }
            // 아래나 위나 같음
            //if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f)) {
            //    Debug.Log($"Raycast Camera : {hit.collider.gameObject.name}");
            //}
        }
    }
}