using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField]
    Button buttonPlay;

    [SerializeField]
    GameObject header;

    void Start()
    {
        
        buttonPlay.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Vector3 headerEndPos = new(header.transform.position.x, header.transform.position.y + 300f, header.transform.position.z);
        header.transform.DOMove(headerEndPos, .5f).SetEase(Ease.InBack).OnComplete(() =>
        {
            header.SetActive(false);

            GameManager.instance.StartGame();
        });
        
        buttonPlay.gameObject.SetActive(false);
    }
}
