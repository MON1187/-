using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private SoulCrystals soulCrystals;

    public void AddData(PieceData piece)
    {
        soulCrystals.Call(piece);
        PicecUIUpdata(piece);
    }

    //UTU//
    private void PicecUIUpdata(PieceData piece)
    {
        switch (piece.PieceType)
        {
            case PieceType.status_UpMaxHealth:
                player.status.st_MaxHealth += GetStatusValue(piece.Lv, piece.PieceType);
                player.status.st_Health += GetStatusValue(piece.Lv, piece.PieceType);
                break;
            case PieceType.status_Upoffense:
                player.status.st_OffensePower += GetStatusValue(piece.Lv, piece.PieceType);
                break;
            case PieceType.status_UpDefance:
                player.status.st_Defense += GetStatusValue(piece.Lv, piece.PieceType);
                break;
        }
    }
    public int GetStatusValue(int Lv,PieceType pieceType)
    {
        Debug.Log(Lv + " : " + pieceType);

        if (pieceType == PieceType.status_UpMaxHealth)
        {
            return Lv switch
            {
                1 => 5,
                2 => 10,
                3 => 20,
                _ => 0
            };
        }
        else if (pieceType == PieceType.status_UpMaxMentality)
        {
            return Lv switch
            {
                1 => 3,
                2 => 5,
                3 => 10,
                _ => 0
            };
        }
        else if (pieceType == PieceType.status_Upoffense)
        {
            return Lv switch
            {
                1 => 1,
                2 => 3,
                3 => 5,
                _ => 0
            };
        }
        else if (pieceType == PieceType.status_UpDefance)
        {
            return Lv switch
            {
                1 => 1,
                2 => 2,
                3 => 3,
                _ => 0
            };
        }
        else return default(int);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 14)
        {
            Piece pieceData = other.GetComponent<Piece>();
            if (pieceData != null)
            {
                AddData(pieceData.data);
                Destroy(pieceData.gameObject);
            }
        }
    }
}
