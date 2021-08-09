using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public Transform cameraStartPosition;
    public Transform playerStartPosition;
    public Transform ball;
    public List<BallMove> ballMoves = new List<BallMove>();
    public List<GameObject> aiList = new List<GameObject>();
}