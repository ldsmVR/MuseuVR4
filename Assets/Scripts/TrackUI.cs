using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackUI : MonoBehaviour
{
    [SerializeField]
    private Camera PlayerCamera;

    [SerializeField]
    private Transform Subject;

    // Update is called once per frame
    void Update()
    {
        if(Subject)
        {
            transform.position = PlayerCamera.WorldToScreenPoint(Subject.position);
        }
    }
}
