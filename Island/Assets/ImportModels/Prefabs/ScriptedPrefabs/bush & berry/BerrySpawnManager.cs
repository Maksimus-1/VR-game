using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnPrefab;
    public Transform parent;

    //for global spawn settings
    public bool useSpawnGlobalSettings = true;
    public GameObject globalSpawnSettings;
    
    //start spawn properties
    public bool useRandomAmount = false;
    public int minBerriesOnStart = 1;
    public int maxBerriesOnStart = 10;
    
    //respawn properties
    public bool allowRespawnBerries = true;
    public int timeoutForSpawnPointInSeconds = 3;
    public int minTimeToRespawn = 1;
    public int maxTimeToRespawn = 4;

    Dictionary<int, bool> spawnPointsDictionary;    //��������� ��� �������� ���������� � ������, � ������� ��� ����������� �����:
                                                    //false - ����� ��������, true - ����� ������
    void InitSpawnPointsDictionary() {
        spawnPointsDictionary = new Dictionary<int, bool>();
        for (int i = 0; i < spawnPoints.Length; i++) {
            spawnPointsDictionary.Add(i, false);
        }
    }
    private void Awake() {
        if (spawnPoints != null) {
            if (useSpawnGlobalSettings && globalSpawnSettings != null) {

            }
            
            else {
                if (minBerriesOnStart > maxBerriesOnStart) minBerriesOnStart = maxBerriesOnStart;
                if (minBerriesOnStart < 0) minBerriesOnStart = 0;
                if (maxBerriesOnStart > spawnPoints.Length) maxBerriesOnStart = spawnPoints.Length;
            }
            InitSpawnPointsDictionary();

            SpawnBerries();
        }
        else {
            Debug.LogAssertion("� ����� ����������� ����� ������ ����");
        }
    }

    IEnumerator _respawnInstance;
    private void Start() {
        if (allowRespawnBerries) {
            _respawnInstance = RespawnBerries();
            StartCoroutine(_respawnInstance);
        }
    }

    IEnumerator RespawnBerries() {
        yield return null;  //���������� ���� ����
        int timeToRespawn;
        while (true) {
            timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
            yield return new WaitForSeconds(timeToRespawn);
            SpawnBerries(false);
        }
    }
    void SpawnBerries(bool isSpawnOnStart = true) {
        int spawnCount;
        if (isSpawnOnStart) {
            if (useRandomAmount) spawnCount = Random.Range(0, spawnPoints.Length + 1);
            else spawnCount = Random.Range(minBerriesOnStart, maxBerriesOnStart);
        }
        else {
            spawnCount = 1;
        }
        int spawnPoint;
        GameObject obj;
        while (spawnCount > 0) {
            spawnPoint = Random.Range(0, spawnPoints.Length);

            if (spawnPointsDictionary[spawnPoint]) {
                continue;
            }

            obj = Instantiate(spawnPrefab, spawnPoints[spawnPoint].position, Quaternion.identity, parent);
            spawnPointsDictionary[spawnPoint] = true;   // ���������� �������� ����� ������ � �����
            StartCoroutine(RespawnCountdown(spawnPoint));

            if (!isSpawnOnStart) StartCoroutine(DestroyConflictBerry(obj));     //���� ������������� ����� ������� ��� ������� �� �����, �� ��� ��������

            spawnCount--;
        }
    }
    IEnumerator RespawnCountdown(int index) {
        yield return new WaitForSeconds(timeoutForSpawnPointInSeconds);
        spawnPointsDictionary[index] = false;
    }
    IEnumerator DestroyConflictBerry(GameObject gameObject) {
        Vector3 startPos = gameObject.transform.localPosition;
        yield return new WaitForFixedUpdate();
        yield return new WaitForSecondsRealtime(Physics.sleepThreshold);

        if (gameObject.transform.localPosition != startPos)
            Destroy(gameObject);
    }
}
