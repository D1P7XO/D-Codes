using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace, placementIndicator;
    private ARRaycastManager m_RaycastManager;
    private Pose m_PlacementPose;
    private bool m_PlacementPoseIsValid = false;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public LayerMask layerMask;

    public GameObject[] TestingGround;
    bool IsPlaced = true;

    void Awake()
    {
#if UNITY_EDITOR
        for (int i = 0; i < TestingGround.Length; i++)
        {
            TestingGround[i].SetActive(true);
        }
#else
        for (int i = 0; i < TestingGround.Length; i++)
        {
            TestingGround[i].SetActive(false);
        }
#endif

        m_RaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (IsPlaced)
        {
            TryUpdatePlacementPose();
            UpdatePlacementIndicator();

            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            // we actually ignore touchPosition, and always use screenCenter for the ray

            if (m_PlacementPoseIsValid)
            {
                PlaceObject();
                IsPlaced = false;
            }
        }
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, m_PlacementPose.position, m_PlacementPose.rotation);
        placementIndicator.SetActive(false);
    }

    private void UpdatePlacementIndicator()
    {
        if (m_PlacementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(m_PlacementPose.position, m_PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose(Vector3 hitPoint)
    {
        m_PlacementPose.position = hitPoint;
        var cameraForward = Camera.main.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        m_PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
    }

    private void TryUpdatePlacementPose()
    {
#if UNITY_EDITOR
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
        RaycastHit hit;

        m_PlacementPoseIsValid = Physics.Raycast(ray, out hit, 500f, layerMask);
        if (m_PlacementPoseIsValid)
        {
            UpdatePlacementPose(hit.point);
        }
#else
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        m_RaycastManager.Raycast(screenCenter, s_Hits, TrackableType.Planes);
        m_PlacementPoseIsValid = s_Hits.Count > 0;
        if (m_PlacementPoseIsValid)
        {
            UpdatePlacementPose(s_Hits[0].pose.position);
        }
#endif
    }

}