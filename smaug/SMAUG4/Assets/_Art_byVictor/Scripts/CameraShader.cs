using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

public class CameraShader : MonoBehaviour
{

    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;

    public float focusSpeed;
    public float maxFocusDistance;
    public LayerMask layersToHit;

    DepthOfField depthOfField;

    public Volume volume;

    Bloom bloom;
    void Start()
    {

        volume.profile.TryGet(out depthOfField);
    }


    void Update()
    {
        raycast = new Ray(transform.position, transform.forward * maxFocusDistance);

        isHit = false;

        if (Physics.Raycast(raycast, out hit, maxFocusDistance, layersToHit))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);

        }
        else
        {
            if (hitDistance < maxFocusDistance)
            {
                hitDistance++;
            }
        }

        SetFocus();

    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = Mathf.Lerp(depthOfField.focusDistance.value, hitDistance, Time.deltaTime * focusSpeed);
    }
    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.5f);

            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 100f);
        }

    }
}
