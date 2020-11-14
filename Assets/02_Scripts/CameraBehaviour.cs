using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    //[SerializeField]
    //private Transform m_cursor
    [SerializeField]
    private Vector3 offSet;
    [SerializeField]
    private float smoothSpeed = 5.0f;
    //[SerializeField]
    //private Camera m_cam;
    [SerializeField]
    private float minBoundary;
    [SerializeField]
    private float maxBoundary;

    private Camera cam;
    private float mouseScroll;
    private float targetZoom;
    private float zoomFactor = 3.0f;
    private float zoomLerpSpeed = 10.0f;
    private int xDirection = -1;

    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    private void Update()
    {
        TrackPlayer();
        ZoomInOut();
    }

    private void TrackPlayer()
    {
        Vector3 desiredPosition = player.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,
            desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    private void ZoomInOut()
    {
        mouseScroll = Input.mouseScrollDelta.y / 10;
        targetZoom -= mouseScroll * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, minBoundary, maxBoundary);
        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom, 
            Time.deltaTime * zoomLerpSpeed);
    }
}
