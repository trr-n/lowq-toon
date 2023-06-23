using UnityEngine;

namespace Toon
{
    public class Above : MonoBehaviour
    {
        [SerializeField] Transform targetTran;
        [SerializeField] new Camera camera;

        void Update()
        {
            transform.position = RectTransformUtility.WorldToScreenPoint(
                camera, targetTran.position + Vector3.up);
        }
    }
}