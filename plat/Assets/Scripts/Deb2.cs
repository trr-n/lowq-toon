using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deb2 : MonoBehaviour
{
    [SerializeField]
    GameObject player, cam;
    [SerializeField]
    Text t;

    void Update()
    {
        float v = Mathf.Floor(player.transform.eulerAngles.y), vv = Mathf.Floor(cam.transform.eulerAngles.y);
        //t.text = @$"player: {player.transform.localEulerAngles.y}
             //camera: {cam.transform.localEulerAngles.y}";
        t.text = @$"player: {v}, camera: {vv}
            diff: {Mathf.DeltaAngle(v, vv)}";
        //t.text = $"distance: {Quaternion.Angle(player.transform.rotation, cam.transform.rotation)}";
        //t.text = $"distance: {Vector3.SignedAngle(player.transform.rotation, cam.transform.rotation, Vector3.up)}";
        //t.text = GetAngleDiff(player.transform.rotation, cam.transform.rotation).ToString();
    }

    //public static float GetAngleDiff(Quaternion a, Quaternion b)
    //{
    //    var va = a * Vector3.up;
    //    var vb = b * Vector3.up;

    //    var angleA = Mathf.Atan2(va.x, va.z) * Mathf.Rad2Deg;
    //    var angleB = Mathf.Atan2(vb.x, vb.z) * Mathf.Rad2Deg;

    //    var diff = Mathf.DeltaAngle(angleA, angleB);
    //    return diff;
    //}
}
