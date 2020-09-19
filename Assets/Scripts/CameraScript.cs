using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Vector3 offset = new Vector3(0, 0, -10);
    public float viteza_urmarire = 5;
    public float viteza_rotatie = 5;
    public GameObject jucator;

    Vector3 targetVector = new Vector3();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        targetVector = jucator.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
                                          targetVector + offset,
                                          .01f * viteza_urmarire
                                         );

        Quaternion rotatie_cam = Quaternion.LookRotation(
                                            targetVector - transform.position
                                        );

        transform.rotation = Quaternion.Lerp(
                                                transform.rotation,
                                                rotatie_cam,
                                                .01f * viteza_rotatie
                                            );
    }
}
