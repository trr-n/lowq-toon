using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        Text setumeiT;

        [SerializeField]
        GameObject panel;

        [SerializeField]
        HP playerHp;

        [SerializeField]
        Manager manager;

        [SerializeField]
        UnityEvent onDead;

        [SerializeField]
        new Rigidbody rigidbody;

        [SerializeField]
        new CapsuleCollider collider;

        [SerializeField]
        Vector3 spawnPosOnRoof;

        [SerializeField]
        int bulletDamage = 25;

        [SerializeField]
        BossCamera bossCam;

        [SerializeField]
        float bosCamMoveDuration = 2;

        float merikoming = 0.5f, pcdis = 3f;
        Vector3 spawnedPos;
        public Vector3 SpawnedPos => spawnedPos;
        public GameObject pcamera;

        void Start()
        {
            init();
            playerHp.SetMax();
        }

        void Update()
        {
            RayForCamera();
            if (!playerHp.IsZero())
                return;
            onDead.Invoke();
        }

        void RayForCamera()
        {
            var origin = transform.position + Vector3.up * 1;
            var ray = new Ray(origin, pcamera.transform.position - transform.position);
            var dis = Vector3.Distance(pcamera.transform.position, transform.position);
            if (Physics.Raycast(ray, out var hit, dis))// && !hit.collider.CompareTag("Terrain"))
            {
                if (Vector3.Distance(origin, pcamera.transform.position) > pcdis)
                    pcamera.transform.position = hit.point + pcamera.transform.forward * merikoming;
                else
                    pcamera.transform.position = Vector3.one * 100;
            }

        }

        public void Radish()
        {
            manager.Controllable = false;
            collider.isTrigger = true;
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(Constant.Bullet))
                playerHp.Damage(bulletDamage);
        }

        void OnTriggerEnter(Collider info)
        {
            if (info.Compare(Constant.Portal))
            {
                transform.position = spawnPosOnRoof;
                bossCam.BossCameraMove(bosCamMoveDuration, setumeiT);
            }
        }

        void init()
        {
            playerHp ??= GetComponent<HP>();
            manager ??= Gobject.Find(Constant.Manager).GetComponent<Manager>();
            collider ??= GetComponent<CapsuleCollider>();
            rigidbody ??= GetComponent<Rigidbody>();
            pcamera = GameObject.FindGameObjectWithTag(Constant.Camera);
            manager.Controllable = true;
            collider.isTrigger = false;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            onDead?.AddListener(Radish);
            onDead?.AddListener(manager.Failing);
        }
    }
}
