using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float power = 100;

    /// <summary>
    /// 発射レート
    /// </summary>
    [SerializeField]
    float rapid = 0.5f;

    float timer;

    PlayerMovement player;

    void Start()
    {

    }

    void Update()
    {
        player = GetComponent<PlayerMovement>();

        print(timer);

        if (Input.GetMouseButton(0))
        {
            A();
        }
    }

    void Fire(float power)
    {
        timer += Time.deltaTime;

        if (timer < rapid) return;

        print("pass");
        var bulletIns = Instantiate(bullet, transform.position, Quaternion.identity);
        var bulletRb = bulletIns.GetComponent<Rigidbody>();
        // bulletRb.AddForce(this.gameObject.transform.forward * power, ForceMode.Impulse);
        bulletRb.AddForce(player.transform.forward * power, ForceMode.Impulse);
        timer = 0;
    }

    void A()
    {
        timer += Time.deltaTime;
        if (timer >= rapid)
        {
            print("fired");
            var bulletIns = Instantiate(bullet, transform.position, transform.rotation);
            var bulletRb = bulletIns.GetComponent<Rigidbody>();
            bulletRb.AddForce(transform.right * power, ForceMode.Impulse);
            timer -= rapid;
        }
    }
}
