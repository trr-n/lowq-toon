using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;

public class ExtendTest : MonoBehaviour
{
    public List<int> i;

    void Start()
    {
        for (int j = 0; j < 100; j++)
        {
            i.Add(j);
        }

        i[i.Capacity.rint()].show();
    }
}
