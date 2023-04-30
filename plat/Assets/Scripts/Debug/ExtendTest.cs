using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameTitle;

public class ExtendTest : MonoBehaviour
{
    public List<int> i;

    void Start()
    {
        i ??= null;
        for (int j = 1; j <= 100; j++)
        {
            i.Add(j);
        }
    }

    void Update()
    {
        i[i.Capacity.random()].show();

        if (1 == 1)// true
        {
            "1です".show();
        }
        if (1 == 2)
        {

        }
    }
}
