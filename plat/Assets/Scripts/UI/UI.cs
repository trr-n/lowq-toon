using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class UI : MonoBehaviour
    {
        /*
        プレイヤーの体力表示(数字、ゲージ)
        塔の体力表示(ゲージ)
        */
        [System.Serializable]
        struct Player
        {
            public HP hp;
            public Text text;
        }
        [SerializeField]
        Player player;

        [System.Serializable]
        struct Tower
        {
            public HP hp;
            public Text text;
        }
        [SerializeField]
        Tower tower;

        [SerializeField]
        UnityEvent UpdateText;

        public void Texts()
        {
            player.text.text = "remain hp: " + player.hp.Current.ToString();
        }
    }
}
