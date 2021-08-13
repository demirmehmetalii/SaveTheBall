using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Level : MonoBehaviour
{
    public Transform ball;
    public List<BallMove> ballMoves = new List<BallMove>();
    public List<GameObject> aiList = new List<GameObject>();

    [Header("Camara And Player Position Settings")]
    public Transform cameraStartPosition;

    public Transform playerStartPosition;

    public void StartCameraPlayerPosition()
    {
        GameManager.Instance.cameraPosition.transform.position = cameraStartPosition.transform.position;
        GameManager.Instance.cameraPosition.transform.eulerAngles = cameraStartPosition.transform.eulerAngles;
        PlayerController.Instance.transform.position = playerStartPosition.position;
    }
}