using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon;

namespace Toon.Debug
{
    public class DebugAngleDiff : MonoBehaviour
    {
        GameObject player, cam;
        Text t;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag(Const.Player);
            cam = GameObject.FindGameObjectWithTag(Const.Cam);
            t = GetComponent<Text>();
        }

        void Update()
        {
            float playerAngle = Mathf.Floor(player.transform.eulerAngles.y),
                cameraAngle = Mathf.Floor(cam.transform.eulerAngles.y);
            //t.text = @$"player: {player.transform.localEulerAngles.y}
            //camera: {cam.transform.localEulerAngles.y}";
            t.text = @$"player: {playerAngle}, camera: {cameraAngle}
            diff: {Mathf.DeltaAngle(playerAngle, cameraAngle)}";
            // t.text = $"distance: {Quaternion.Angle(player.transform.rotation, cam.transform.rotation)}";
            // t.text = $"distance: {Vector3.SignedAngle(player.transform.rotation, cam.transform.rotation, Vector3.up)}";
            // t.text = GetAngleDiff(player.transform.rotation, cam.transform.rotation).ToString();
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
}