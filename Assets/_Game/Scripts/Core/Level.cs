using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform camera;

    public Transform ball;
    public List<BallMove> ballMoves = new List<BallMove>();
    public List<CharacterController> ai = new List<CharacterController>();
}
