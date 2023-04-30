using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameTitle
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            Physics.gravity = Scenes.MainGravity;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
