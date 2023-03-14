using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    float move = 10;
    Value value;
    GameObject self;

    class Value
    {
        public float move;
        public Value(float move) { this.move = move; }
    }

    void Start()
    {
        value = new(move: 10);
    }

    void Update()
    {
        // transform.Translate(Moves.Move(speed: move));
        self = this.gameObject;
        self.transform.Translate(Moves.Move(speed: value.move));
    }

    class Moves
    {
        public static Vector3 Move(float speed)
        {
            Vector3 move = new(
                Input.GetAxis(Mine.Keys.Horizontal),
                Input.GetAxis(Mine.Keys.Vertical)
            );
            return speed * Time.deltaTime * move;
        }
    }
}
