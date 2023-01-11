using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private Vector3 min;
    private Vector3 max;
    private Transform trans;
    public Transform target;
    public Vector2 margin;
    public Vector2 smoothing;
    public BoxCollider2D bounds;
    public GameObject camera;
    public bool IsFollowing { get; set; }


    public void Start()
    {
        trans = transform;
        min = bounds.bounds.min;
        max = bounds.bounds.max;
        IsFollowing = target != null;
    }


    public void LateUpdate()
    {
        float x = trans.position.x;
        float y = trans.position.y;

        if (IsFollowing)
        {
            if (Mathf.Abs(x - target.position.x) > margin.x)
            {
                x = Mathf.Lerp(x, target.position.x, smoothing.x * Time.deltaTime);
            }

            if (Mathf.Abs(y - target.position.y) > margin.y)
            {
                y = Mathf.Lerp(y, target.position.y, smoothing.y * Time.deltaTime);
            }

            float cameraHalfWidth = camera.GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

            x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, min.y + camera.GetComponent<Camera>().orthographicSize, max.y - camera.GetComponent<Camera>().orthographicSize);
            trans.position = new Vector3(x, y, trans.position.z);
        }
    }
}
