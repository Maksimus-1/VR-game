using DataPersistence.Gameplay;
using UnityEngine;
using static SpawnManager;

[RequireComponent(typeof(BananaTreeGrowth), typeof(BananaRipening))]
public class BananaTreeManager : MonoBehaviour, ISpawner
{
    private BananaRipening _bananaRipening;

    private BananaTreeGrowth _bananaTreeGrowth;

    [SerializeField] private BananaDrop _bananaDrop;

    private bool _hasInitialized = false;

    private static bool _hasStarted = false;
    public static bool HasStarted { get { return _hasStarted; } }

/*    public void SetData(BananaTreeData data)
    {
        _bananaRipening.SetData();
    }*/

    public BananaTreeData GetData()
    {
        return new BananaTreeData(gameObject.name, _bananaRipening.GetData(), _bananaTreeGrowth.GetData());
    }

    private void Start() {
        _hasStarted = true;
    }

    public void Init(BananaTreeData data)
    {
        _bananaRipening = GetComponent<BananaRipening>();
        _bananaTreeGrowth = GetComponent<BananaTreeGrowth>();

        _bananaTreeGrowth.AllowRipening += OnAllowRipening;

        _bananaDrop.Init();

        if (data == null)
        {
            _bananaRipening.Init(null);
            _bananaTreeGrowth.Init(null);
        }
        else
        {
            _bananaRipening.Init(data.ripeningData);
            _bananaTreeGrowth.Init(data.growthData);

            if (data.ripeningData.allowRipening == true)
            {
                OnAllowRipening();
            }
        }

        _hasInitialized = true;
    }

/*    void ISpawner.Init() {
        _bananaRipening = GetComponent<BananaRipening>();
        _bananaTreeGrowth = GetComponent<BananaTreeGrowth>();

        _bananaRipening.Init();
        _bananaTreeGrowth.Init();

        _bananaTreeGrowth.AllowRipening += OnAllowRipening;

        _hasInitialized = true;
    }*/

    void ISpawner.BeginSpawn() {
/*        if (!_hasInitialized) {
            _spawner.Init();
        }*/
        _bananaTreeGrowth.StartGrowth();
    }

    void OnAllowRipening() {
        _bananaTreeGrowth.AllowRipening -= OnAllowRipening;

        _bananaRipening.StartRipening();
    }
}
