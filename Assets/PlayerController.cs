using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Transform player; // Hareket ettirilecek obje
    public Transform[] targetPosition ;
    public float playerSpeed;
    int targetPositionINT = 0;
    bool playerCanMove = true;// Objenin gitmesini istediðiniz konum

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerCanMove) // Sol týk (veya dokunma)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (player != null)
        {
            playerCanMove = false;
            player.DOMove(targetPosition[targetPositionINT].position, 1 / playerSpeed).SetEase(Ease.Linear).OnComplete(()=>  playerCanMove = true);

            if (targetPositionINT < targetPosition.Length-1)
            {
                targetPositionINT++;
            }
       
        }
        else
        {
            Debug.LogWarning("Hedef obje atanmadý!");
        }
    }
}
