using UnityEngine;

public class BerriesSettings : GameSettings
{
    [Header("��������� ������ � �������� ����")]

    [SerializeField, Range(0, 100), Tooltip("����������� ���������� ���� �� ������ ����")]
    private int _minBerriesOnStart;
    public int MinBerriesOnStart { 
        get {  return _minBerriesOnStart; } 
        private set {
            if (value < 0) value = 0;
            if (value > _maxBerriesOnStart) value = _maxBerriesOnStart;

            _minBerriesOnStart = value;
        }
    }


    [SerializeField, Range(0, 100), Tooltip("������������ ���������� ���� �� ������ ����")]
    private int _maxBerriesOnStart;
    public int MaxBerriesOnStart { 
        get { return _maxBerriesOnStart; } 
        private set {
            if (value < 0) value = 0;
            if (value < _minBerriesOnStart) value = _minBerriesOnStart;

            _maxBerriesOnStart = value; 
        }
    }


    [SerializeField, Range(1, 100000), Tooltip("����-���, \"���������\" �������� �������/��������� ����� � ��������")]
    private int _timeoutBerryRespawnInSeconds;
    public int TimeoutBerryRespawnInSeconds { 
        get {
            return _timeoutBerryRespawnInSeconds; 
        } 
        private set { 
            _timeoutBerryRespawnInSeconds = value; 
        }
    }


    [SerializeField, Range(1, 100000), Tooltip("�����, ����� �������� �������� ����� ����� ����� �������/�������� ������")]
    private int _timeToRespawnBerryInSeconds;
    public int TimeToRespawnBerryInSeconds { 
        get { 
            return _timeToRespawnBerryInSeconds; 
        } 
        private set { 
            _timeToRespawnBerryInSeconds = value; 
        }
    }


    [SerializeField, Tooltip("��������������� ����� ��������")]
    private bool _useRandomBerryRespawnTime;
    public bool UseRandomBerryRespawnTime { 
        get { 
            return _useRandomBerryRespawnTime; 
        } 
        private set { 
            _useRandomBerryRespawnTime = value; 
        }
    }


    [SerializeField, Range(1, 100000), Tooltip("����������� ����� �������� ����� � ��������")]
    private int _minTimeToRespawnBerryInSeconds;
    public int MinTimeToRespawnBerryInSeconds { 
        get { 
            return _minTimeToRespawnBerryInSeconds; 
        } 
        private set { 
            _minTimeToRespawnBerryInSeconds = value; 
        }
    }


    [SerializeField, Range(1, 100000), Tooltip("������������ ����� �������� ����� � ��������")]
    private int _maxTimeToRespawnBerryInSeconds;
    public int MaxTimeToRespawnBerryInSeconds { 
        get { 
            return _maxTimeToRespawnBerryInSeconds; 
        } 
        private set { 
            _maxTimeToRespawnBerryInSeconds = value; 
        } 
    }
}
