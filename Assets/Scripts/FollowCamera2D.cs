using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Camera))]

public class FollowCamera2D : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Tilemap tilemap;

    private Vector3 offset;
    private Vector2 viewportHalfSize;

    private float leftCameraBoundary;
    private float rightCameraBoundary;
    private float bottomCameraBoundary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
        CalculateBounds();
    }

    private void CalculateBounds()
    {
        tilemap.CompressBounds();

        Camera cam = GetComponent<Camera>();

        float orthosize = cam.orthographicSize;
        Vector3 viewportHalfSize = new(orthosize * cam.aspect, orthosize);

        Vector3Int min = tilemap.cellBounds.min;
        Vector3Int max = tilemap.cellBounds.max;

        leftCameraBoundary = min.x + viewportHalfSize.x;
        rightCameraBoundary = max.x + viewportHalfSize.x;
        bottomCameraBoundary = min.y + viewportHalfSize.y;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 steppedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);

        steppedPosition.x = Mathf.Clamp(steppedPosition.x, leftCameraBoundary, rightCameraBoundary);
        steppedPosition.y = Mathf.Clamp(steppedPosition.y, bottomCameraBoundary, steppedPosition.y);

        transform.position = steppedPosition;
    }
}
