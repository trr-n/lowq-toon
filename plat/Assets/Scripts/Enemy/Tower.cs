using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        GameObject player;

        [SerializeField]
        HP hp;

        [SerializeField]
        int damage;

        readonly Vector3 TowerPosition = new(8.731677f, 3.177724f, -7.152449f);

        void Update()
        {
            LookingAtPlayer();
        }

        void ClampingMe()
        {
            transform.setr(y: Numeric.Clamp(transform.rotation.y, 225, 283));
            transform.position = TowerPosition;
        }

        void LookingAtPlayer()
        {
            Vector3 a = new(transform.position.x, 0, transform.position.z),
                b = new(player.transform.position.x, 0, player.transform.position.z);
            transform.rotation = Quaternion.LookRotation(b - a, Vector3.up);
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(Constant.Missile))
                hp.Damage(damage);
        }
    }
}
