using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "GameSettings/WorldSettings", order = 1)]
public class WorldSettings : ScriptableObject, WorldSettings.IBerriesSettings, WorldSettings.IBananaTreeSettings, WorldSettings.ICoconutPalmSettings, WorldSettings.IEvacSettings, WorldSettings.INutritionSettings {
    public enum Difficulties {
        explorerMode = 0,
        easy = 1,
        medium = 2,
        hard = 3
    };

    [SerializeField]
    private Difficulties _difficulty;
    public Difficulties Difficulty { get { return _difficulty; } }

    #region interfaces
    public interface IBerriesSettings {
        int MinBerriesOnStart { get; }
        int MaxBerriesOnStart { get; }
        int TimeoutBerryRespawnInSeconds { get; }
        int TimeToRespawnBerryInSeconds { get; }
        bool UseRandomBerryRespawnTime { get; }
        int MinTimeToRespawnBerryInSeconds { get; }
        int MaxTimeToRespawnBerryInSeconds { get; }
    }
    public interface IBananaTreeSettings {
        bool UseRandomTreeStartScale { get; }
        float MinTreeScale { get; }
        float MaxTreeScale { get; }
        float TimeToGrowthInSeconds { get; }
        bool UseRandomGrowthTime { get; }
        float MinTimeToGrowthInSeconds { get; }
        float MaxTimeToGrowthInSeconds { get; }
        float StartGrowthProgres { get; }
        bool UseRandomStartGrowthProgress { get; }
        float MinStartGrowthProgress { get; }
        float MaxStartGrowthProgress { get; }

        bool UseRandomRipePhaseDuration { get; }
        float RipePhaseDurationInSeconds { get; }
        float MinPhaseRipeDurationInSeconds { get; }
        float MaxPhaseRipeDurationInSeconds { get; }
        float StartRipeningMoment { get; }

        int MinBananasToDrop { get; }
        int MaxBananasToDrop { get; }
    }
    public interface ICoconutPalmSettings {
        int MinCoconutsOnStart { get; }
        int MaxCoconutsOnStart { get; }
        int MinTimeToRespawnInSeconds { get; }
        int MaxTimeToRespawnInSeconds { get; }
        float ChanceToSpawnOnStart { get; }
    }
    public interface IEvacSettings {
        int RocketChance { get; }
        int SosRocksChance { get; }
        int BonfireChance { get; }
        int BonfireDuration { get; }
        int ChanceTickRateInSeconds { get; }
        int SignalGunsAmount { get; }
        int BonfiresAmount { get; }
        int LightersAmount { get; }
    }
    public interface INutritionSettings {
        float BerryNutrVal { get; }
        float CoconutNutrVal { get; }
        float BananaNutrVal { get; }
    }
    #endregion

    #region ��������� ������ � �������� ����
    [Header("��������� ������ � �������� ����")]

    [SerializeField, Range(0, 100), Tooltip("����������� ���������� ���� �� ������ ����")]
    private int _minBerriesOnStart;
    int IBerriesSettings.MinBerriesOnStart { get { return _minBerriesOnStart; } }

    [SerializeField, Range(0, 100), Tooltip("������������ ���������� ���� �� ������ ����")]
    private int _maxBerriesOnStart;
    int IBerriesSettings.MaxBerriesOnStart { get { return _maxBerriesOnStart; } }


    [SerializeField, Range(1, 100000), Tooltip("����-���, \"���������\" �������� �������/��������� ����� � ��������")]
    private int _timeoutBerryRespawnInSeconds;
    int IBerriesSettings.TimeoutBerryRespawnInSeconds { get { return _timeoutBerryRespawnInSeconds; } }

    [SerializeField, Range(1, 100000), Tooltip("�����, ����� �������� �������� ����� ����� ����� �������/�������� ������")]
    private int _timeToRespawnBerryInSeconds;
    int IBerriesSettings.TimeToRespawnBerryInSeconds { get { return _timeToRespawnBerryInSeconds; } }

    [SerializeField, Tooltip("��������������� ����� ��������")]
    private bool _useRandomBerryRespawnTime;
    bool IBerriesSettings.UseRandomBerryRespawnTime { get { return _useRandomBerryRespawnTime; } }

    [SerializeField, Range(1, 100000), Tooltip("����������� ����� �������� ����� � ��������")]
    private int _minTimeToRespawnBerryInSeconds;
    int IBerriesSettings.MinTimeToRespawnBerryInSeconds { get { return _minTimeToRespawnBerryInSeconds; } }

    [SerializeField, Range(1, 100000), Tooltip("������������ ����� �������� ����� � ��������")]
    private int _maxTimeToRespawnBerryInSeconds;
    int IBerriesSettings.MaxTimeToRespawnBerryInSeconds { get { return _maxTimeToRespawnBerryInSeconds; } }
    #endregion

    #region ��������� ����� ��������� �����
    [Header("��������� ����� ��������� �����")]

    [SerializeField]
    private bool _useRandomTreeStartScale = true;
    bool IBananaTreeSettings.UseRandomTreeStartScale { get { return _useRandomTreeStartScale; } }

    [SerializeField, Range(0.5f, 1)]
    private float _minTreeScale = 1;
    float IBananaTreeSettings.MinTreeScale { get { return _minTreeScale; } }

    [SerializeField, Range(1.1f, 2)]
    private float _maxTreeScale = 1.74f;
    float IBananaTreeSettings.MaxTreeScale { get { return _maxTreeScale; } }

    [SerializeField, Range(0, 100000)]
    private float _timeToGrowthInSeconds;
    float IBananaTreeSettings.TimeToGrowthInSeconds { get { return _timeToGrowthInSeconds; } }

    [SerializeField]
    private bool _useRandomGrowthTime = true;
    bool IBananaTreeSettings.UseRandomGrowthTime { get { return _useRandomGrowthTime; } }
    
    [SerializeField, Range(1, 100000)]
    private float _minTimeToGrowthInSeconds;
    float IBananaTreeSettings.MinTimeToGrowthInSeconds { get { return _minTimeToGrowthInSeconds; } }
    
    [SerializeField, Range(2, 100000)]
    private float _maxTimeToGrowthInSeconds;
    float IBananaTreeSettings.MaxTimeToGrowthInSeconds { get { return _maxTimeToGrowthInSeconds; } }

    [SerializeField, Range(0, 1)]
    private float _startGrowthProgress = 0;
    float IBananaTreeSettings.StartGrowthProgres { get { return _startGrowthProgress; } }

    [SerializeField]
    private bool _useRandomStartGrowthProgress;
    bool IBananaTreeSettings.UseRandomStartGrowthProgress { get { return _useRandomStartGrowthProgress; } }

    [SerializeField, Range(0, 1)]
    private float _minStartGrowthProgress;
    float IBananaTreeSettings.MinStartGrowthProgress { get { return _minStartGrowthProgress; } }

    [SerializeField, Range(0, 1)]
    private float _maxStartGrowthProgress;
    float IBananaTreeSettings.MaxStartGrowthProgress { get { return _maxStartGrowthProgress; } }

    #endregion

    #region ��������� �������� ���������� ��������� �����
    [Header("��������� �������� ���������� ��������� �����")]

    [SerializeField]
    private bool _useRandomRipePhaseDuration;
    bool IBananaTreeSettings.UseRandomRipePhaseDuration { get { return _useRandomRipePhaseDuration; } }

    [SerializeField, Range(1, 100000)]
    private float _ripePhaseDurationInSeconds = 4;
    float IBananaTreeSettings.RipePhaseDurationInSeconds { get { return _ripePhaseDurationInSeconds; } }

    [SerializeField, Range(1, 100000)]
    private float _minPhaseRipeDurationInSeconds;
    float IBananaTreeSettings.MinPhaseRipeDurationInSeconds { get { return _minPhaseRipeDurationInSeconds; } }

    [SerializeField, Range(1, 100000)]
    private float _maxPhaseRipeDurationInSeconds;
    float IBananaTreeSettings.MaxPhaseRipeDurationInSeconds { get { return _maxPhaseRipeDurationInSeconds; } }

    [SerializeField, Range(0, 1), Tooltip("� ����� �������� ����� ������ �������� ���� ���������� ������")]
    private float startRipeningMoment = 0.8f;
    float IBananaTreeSettings.StartRipeningMoment { get { return startRipeningMoment; } }
    #endregion

    #region ��������� ����������� ��������� �����
    [Header("��������� ����������� ��������� �����")]

    [SerializeField, Range(1, 100)]
    private int _minBananasToDrop = 1;
    int IBananaTreeSettings.MinBananasToDrop { get { return _minBananasToDrop; } }

    [SerializeField, Range(1, 100)]
    private int _maxBananasToDrop = 10;
    int IBananaTreeSettings.MaxBananasToDrop { get { return _maxBananasToDrop; } }
    #endregion

    #region ��������� ������ � �������� �������
    [Header("��������� ������ � �������� �������")]

    [SerializeField, Range(0, 100)]
    private int _minCoconutsOnStart = 0;
    int ICoconutPalmSettings.MinCoconutsOnStart { get { return _minCoconutsOnStart; } }

    [SerializeField, Range(0, 100)]
    private int _maxCoconutsOnStart = 4;
    int ICoconutPalmSettings.MaxCoconutsOnStart { get { return _maxCoconutsOnStart; } }

    [SerializeField, Range(1, 100000)]
    private int _minTimeToRespawnInSeconds;
    int ICoconutPalmSettings.MinTimeToRespawnInSeconds { get { return _minTimeToRespawnInSeconds; } }

    [SerializeField, Range(1, 100000)]
    private int _maxTimeToRespawnInSeconds;
    int ICoconutPalmSettings.MaxTimeToRespawnInSeconds { get { return _maxTimeToRespawnInSeconds; } }

    [SerializeField, Range(0, 1)]
    private float _chanceToSpawnOnStart = 0.4f;
    float ICoconutPalmSettings.ChanceToSpawnOnStart { get { return _chanceToSpawnOnStart; } }
    #endregion

    #region ��������� ��������� ��� ���������
    [Header("��������� ��������� ��� ���������")]

    [SerializeField, Range(0, 100)]
    private int _rocketChance = 1;
    int IEvacSettings.RocketChance { get { return _rocketChance; } }

    [SerializeField, Range(0, 100)]
    private int _sosRocksChance = 1;
    int IEvacSettings.SosRocksChance { get { return _sosRocksChance; } }

    [SerializeField, Range(0, 100)]
    private int _bonfireChance = 1;
    int IEvacSettings.BonfireChance { get { return _bonfireChance; } }

    [SerializeField]
    private int _bonfireDuration = 100;
    int IEvacSettings.BonfireDuration { get { return _bonfireDuration; } }

    [SerializeField]
    private int _chanceTickRateInSeconds = 30;
    int IEvacSettings.ChanceTickRateInSeconds { get { return _chanceTickRateInSeconds; } }

    [SerializeField]
    private int _signalGunsAmount = 1;
    int IEvacSettings.SignalGunsAmount { get { return _signalGunsAmount; } }

    [SerializeField]
    private int _bonfiresAmount = 4;
    int IEvacSettings.BonfiresAmount { get { return _bonfiresAmount; } }

    [SerializeField]
    private int _lightersAmount = 2;
    int IEvacSettings.LightersAmount { get { return _lightersAmount; } }

    #endregion

    #region ��������� ������������� �������� ���
    [Header("��������� ������������� �������� ���")]

    [SerializeField, Range(0, 1)]
    private float _nutritionalValue_Berry = 0.3f;
    float INutritionSettings.BerryNutrVal { get { return _nutritionalValue_Berry; } }

    [SerializeField, Range(0, 1)]
    private float _nutritionalValue_Coconut = 0.3f;
    float INutritionSettings.CoconutNutrVal { get { return _nutritionalValue_Coconut; } }

    [SerializeField, Range(0, 1)]
    private float _nutritionalValue_Banana = 0.3f;
    float INutritionSettings.BananaNutrVal { get { return _nutritionalValue_Banana; } }
    #endregion

    #region ��������� ������
    [Header("��������� ������")]

    [Tooltip("����� � ��������, �� ������� ������� ���������� � 1 �� 0")]
    public float satietyTime;

    [Range(0, 1), Tooltip("������ ������� �������� �������, ��� ������� ������ ����������������� ��������")]
    public float healthIncreaseFromSatietyThreshold;

    [Tooltip("����� � ��������, �� ������� �������� ���������� � 1 �� 0 � ���������� ���������")]
    public float healthDecreaseTimeFromStarving;

    [Tooltip("����� � ��������, �� ������� �������� �������� �� 0 �� 1 ��� ������������ �������")]
    public float healthIncreaseTimeFromSatiety;

    [Range(0, 1), Tooltip("������� ������� �������� ��������, �� ������� ��� ����� ����������������� ��� ���������")]
    public float healthMaxThresholdFromSatiety;

    #endregion
}