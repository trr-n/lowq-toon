using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Scenes : MonoBehaviour
    {
        public void ToTitle() => scene.load(constant.Title);
        public void ToMain() => scene.load(constant.Main);
        public void ToClear() => scene.load(constant.Clear);
        public void ToFail() => scene.load(constant.Failure);
    }
}
