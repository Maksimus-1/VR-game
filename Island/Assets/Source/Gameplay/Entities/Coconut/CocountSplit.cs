using UnityEngine;
using UnityEngine.AddressableAssets;

public class CocountSplit : MonoBehaviour
{
    [SerializeField] 
    private GameObject _coconutUp, _coconutDown;

    [SerializeField] private AssetReferenceGameObject _coconutUpper, _coconutLower;

    [SerializeField]
    private Transform coconutBroken;

    private int _splitChance = 4;

    private bool _wasDetachedFromHand;
    public bool WasDetachedFromHand {
        get { return _wasDetachedFromHand; }
        set { _wasDetachedFromHand = value; }
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (_wasDetachedFromHand) {
            if (Random.Range(0, _splitChance) == 0) {    // ����� ����� 0, �� ����� ������ �����������
                _coconutDown.SetActive(true);
                _coconutUp.SetActive(true);

                GameObjectsRegistries.Instance.Register(_coconutDown, _coconutLower.AssetGUID);
                GameObjectsRegistries.Instance.Register(_coconutUp, _coconutUpper.AssetGUID);

                _coconutDown.transform.parent = coconutBroken;
                _coconutUp.transform.parent = coconutBroken;
                coconutBroken.parent = transform.parent;

                GameObjectsRegistries.Instance.Unregister(this.gameObject);

                Destroy(this.gameObject);
            }
            else {  // ����� ��������� ���� ������������
                _splitChance -= 1;
            }
            _wasDetachedFromHand = false;
        }
    }
}
