using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Scenes : MonoBehaviour
    {
        public void ToTitle() => Section.Load(Constant.Title);
        public void ToMain() => Section.Load(Constant.Main);
        public void ToClear() => Section.Load(Constant.Clear);
        public void ToFail() => Section.Load(Constant.Failure);
    }
}
