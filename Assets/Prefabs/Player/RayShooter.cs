using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    private GameObject _fireball;
    [SerializeField] private GameObject fireballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth/2 - size/4;
        float posY = _camera.pixelHeight/2 - size/4;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_fireball == null)
            {
                _fireball = Instantiate(fireballPrefab) as GameObject;
                _fireball.transform.position =
                    transform.TransformPoint(Vector3.forward * 1.5f);
                _fireball.transform.rotation = transform.rotation;
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
