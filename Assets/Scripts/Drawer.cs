using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour
{
    [SerializeField]
    LineRenderer line;

    [SerializeField]
    float minDistance = 0.1f;

    [SerializeField]
    private List<Vector3> spawnPoints = new List<Vector3>();

    [SerializeField]
    Transform fallGuys;

    [SerializeField]
    Camera camDraw;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void Update()
    {
        if (gameManager.gameStarted == true)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = camDraw.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Draw(hit);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                SetPositionsChildObject();
                ClearBoard();
            }
        }        
    }
    void SetPositionsChildObject()
    {
        List<Transform> childs = new();

        for (int i = 0; i < fallGuys.childCount; i++)
        {
            childs.Add(fallGuys.GetChild(i));
        }

        if (childs.Count < spawnPoints.Count)
        {
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].DOLocalMove(new Vector3(spawnPoints[i * (spawnPoints.Count / childs.Count)].x, .25f, spawnPoints[i * (spawnPoints.Count / childs.Count)].y), .25f);
            }
        }
    }
    private void ClearBoard()
    {
        line.positionCount = 0;
        spawnPoints.Clear();
    }

    private void Draw(RaycastHit hit)
    {
        var drawArea = hit.collider.gameObject.GetComponent<DrawArea>();
        if (!drawArea)
        {
            return;
        }

        Vector3 linePos = hit.point;
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, linePos);

        Vector3 linePosLocal = drawArea.transform.InverseTransformPoint(linePos);

        if (line.positionCount > 2)
        {
            CheckSpawn(linePosLocal);
        }

        line.gameObject.SetActive(true);
    }

    private void CheckSpawn(Vector3 point)
    {
        var lrPositionCount = line.positionCount;
        if (Vector3.Distance(line.GetPosition(lrPositionCount - 2), point) > minDistance)
        {
            spawnPoints.Add(point);
        }
    }
}
