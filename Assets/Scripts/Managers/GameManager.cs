using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    SplineFollower splineFollower;

    public bool gameStarted;

    [SerializeField]
    Transform guy;

    private void Start()
    {
        gameStarted = false;
        splineFollower.follow = false;
    }
    public void StartGame()
    {
        gameStarted = true;
        splineFollower.follow = true;

        for (int i = 0; i < guy.childCount; i++)
        {
            guy.GetChild(i).GetComponent<Guy>().Run();
        }
    }
    public void Lose()
    {
        gameStarted = false;
        splineFollower.follow = true;
    }
    public void Win()
    {
        gameStarted = false;
        splineFollower.follow = false;

        for (int i = 0; i < guy.childCount; i++)
        {
            guy.GetChild(i).GetComponent<Guy>().Win();

            VfxManager.instance.PlayVFX(VfxManager.VfxType.confetti, guy.transform.position);
        }
    }

    public void CheckLose()
    {
        print(guy.childCount);

        if (guy.childCount < 1)
        {
            Lose();

            print("asdadasasdasadad");
        }
    }
}
