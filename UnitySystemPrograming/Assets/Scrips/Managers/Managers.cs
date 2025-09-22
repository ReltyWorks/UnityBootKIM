using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; // 유일성이 보장됨

    public static Managers Instance { get { Init(); return s_instance; } }

    InputManager im = new InputManager();
    ResourceManager rm = new ResourceManager();

    public static InputManager Input { get { return Instance.im; } }
    public static ResourceManager Resource { get { return Instance.rm; } }

    void Start()
    {
        Init();
    }

    void Update()
    {
        im.OnUpdate();
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");

            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}