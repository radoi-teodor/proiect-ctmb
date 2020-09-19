using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWayPointScript : MonoBehaviour
{

    public GameObject look_obj;
    public List<GameObject> waypoints = new List<GameObject>();
    public float offsetWaypoint = .5f;
    public float viteza = 5;
    public float viteza_look = 5;

    GameObject waypoint;
    int waypoint_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = waypoints[waypoint_index];
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position-waypoint.transform.position).magnitude <= offsetWaypoint)
        {
            if(waypoint_index< waypoints.Count-1)
            {
                waypoint_index++;
            }
            else
            {
                waypoint_index = 0;
            }

            waypoint = waypoints[waypoint_index];
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          waypoint.transform.position,
                                          viteza*0.05f);

        Quaternion look_rot = Quaternion.LookRotation(look_obj.transform.position - transform.position);

        transform.rotation = Quaternion.Lerp(transform.rotation, look_rot, viteza_look * 0.05f);

    }
}
