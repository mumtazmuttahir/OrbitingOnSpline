using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    We are using Lerp function from Unity
    Lerp = Linear Interpolation
    Vector3 = 3 pointer structure
    Vector3 Lerp(Vector3 a, Vector3 b, float t);
    Start point    a = Start value, returned when t = 0.
    End   point    b = End value, returned when t = 1.
    Divisional gap t = Value used to interpolate between a and b.
    https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    */

public class Curve : MonoBehaviour
{
    #region private_variables
    //Normal Variables
    private float interpolationGap = 0.0f;
    //Serialized Variables
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private GameObject pointC;
    [SerializeField] private GameObject pointD;
    [SerializeField] private GameObject pointABCD;
    #endregion

    #region public_variables
    #endregion

    private void Start() {
        Debug.Log ("Start Called");
    }

    // Update is called once per frame
    void Update()
    {
        //This works from 0 to 1, 
        //As soon as the value of interpolation becomes 1, it is reset to 0
        interpolationGap = (interpolationGap + Time.deltaTime) % 1.0f;

        pointABCD.transform.position = CubicLerp(pointA.transform.position,
                                                pointB.transform.position,
                                                pointC.transform.position,
                                                pointD.transform.position,
                                                interpolationGap);


    }

    private Vector3 QuadraticCurveLerp (Vector3 _point1, 
                                        Vector3 _point2, 
                                        Vector3 _point3, 
                                        float interpolationTime) {

        Vector3 point12 = Vector3.Lerp(_point1, _point2, interpolationTime);
        Vector3 point23 = Vector3.Lerp(_point2, _point3, interpolationTime);

        return Vector3.Lerp (point12, point23, interpolationTime);
    }

        private Vector3 CubicLerp (Vector3 _point1, 
                                        Vector3 _point2, 
                                        Vector3 _point3,
                                        Vector3 _point4, 
                                        float interpolationTime) {
                                            
        Vector3 point12_23 = QuadraticCurveLerp(_point1, _point2, _point3, interpolationTime);
        Vector3 point23_34 = QuadraticCurveLerp(_point2, _point3, _point4, interpolationTime);

        return Vector3.Lerp (point12_23, point23_34, interpolationTime);
    }
}
