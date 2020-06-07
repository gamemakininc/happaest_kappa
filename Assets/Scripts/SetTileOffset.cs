using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetTileOffset : MonoBehaviour
{
    //Use this to offset tile so that it spawns on the edge of the camera
    void Awake()
    {
        transform.position = transform.position + new Vector3(GetComponent<SpriteRenderer>().bounds.extents.x, 0, 0);
    }
}
