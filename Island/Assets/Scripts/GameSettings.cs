using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // ------------------   �����   ---------------------------------
    [Header("��������� ������ � �������� ����")]
    [Range(0, 100)] public int minBerriesOnStart;
    [Range(0, 100)] public int maxBerriesOnStart;

    [Range(1, 100000)] public int timeoutBerryRespawnInSeconds;

    [Range(1, 100000)] public int timeToRespawnBerryInSeconds;
    public bool useRandomBerryRespawnTime;
    [Range(1, 100000)] public int minTimeToRespawnBerryInSeconds;
    [Range(1, 100000)] public int maxTimeToRespawnBerryInSeconds;
    //---------------------------------------------------------------

    // ------------------   ��������� �������   ---------------------------------
    [Header("��������� ����� ��������� �����")]
    public bool useRandomBananaTreeStartScale = true;
    [Range(0.5f, 1)] public float minBananaTreeScale = 1;
    [Range(1.1f, 2)] public float maxBananaTreeScale = 1.74f;
    [Range(1, 100000)] public float minTimeToGrowthInSeconds;
    [Range(2, 100000)] public float maxTimeToGrowthInSeconds;

    [Header("��������� �������� ���������� ��������� �����")]
    [Range(1, 100000)] public float ripePhaseDurationInSeconds = 4;
    public bool useRandomRipePhaseDuration;
    [Range(1, 100000)] public float minPhaseRipeDurationInSeconds;
    [Range(1, 100000)] public float maxPhaseRipeDurationInSeconds;

    [Header("��������� ����������� ��������� �����")]
    [Range(1, 100)] public int minBananasToDrop = 1;
    [Range(1, 100)] public int maxBananasToDrop = 10;
    //---------------------------------------------------------------------------

    //[Header("��������� ��������� �����")]

}
