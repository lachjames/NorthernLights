using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AuroraTriggerPoint : MonoBehaviour
{
    public AuroraGIT.ATrigger.AGeometry geometry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        geometry.structid = 3;
        geometry.PointX = transform.localPosition.x;
        geometry.PointY = transform.localPosition.z;
        geometry.PointZ = transform.localPosition.y;
    }
}
