using UnityEditor;
using UnityEngine;

public class ResourceManager {

    public T Load<T> (string path) where T : Object {

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string _path, Transform _parent = null) {

        GameObject prefab = Load<GameObject>($"Prefabs/{_path}");
        if (prefab == null) {
            Debug.LogError($"ÇÁ¸®ÆÕ ¾øÀ½ : {_path}");
        }

        return Object.Instantiate(prefab, _parent);

    }

    public void Destroy (GameObject go) {
        if (go == null) return;

        Object.Destroy(go);
    }

}
