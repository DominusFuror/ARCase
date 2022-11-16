using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ImageChekr : MonoBehaviour
{
    [SerializeField]
    ARRaycastManager manager;

   


    [SerializeField]
    GameObject portal;
    [SerializeField]
    GameObject portal2;



    [SerializeField]
    UnityEngine.UI.Text text;
    [SerializeField]
    float angle = 0;
    [SerializeField]
    float angleChange = 0;
    [SerializeField]
    bool followAngle = false;

    [SerializeField]
    GameObject arrow;


    private void Start()
    {
       
    }
    private void Update()
    {

        
        Vector2 screenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        manager.Raycast(screenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes);

        if (hits.Count > 0)
        {
            if (Input.touchCount > 0)
            {
              
                if(Input.touches[0].phase == TouchPhase.Began)
                {

                    portal.transform.position = hits[0].pose.position;
                    portal.transform.rotation = (hits[0].pose.rotation);
                    
              

                }


            }

        }
        arrow.transform.LookAt(Camera.main.transform);
        if (followAngle)
        {
            angleChange = Camera.main.transform.rotation.eulerAngles.y - angle;
            mirorCamera.transform.rotation = Quaternion.Euler(mirorCamera.transform.rotation.eulerAngles.x, angleChange - 180, mirorCamera.transform.eulerAngles.z);

        }

    }
    [SerializeField]
    GameObject mirorCamera;

}
