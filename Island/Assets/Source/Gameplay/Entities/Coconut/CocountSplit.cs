using UnityEngine;

public class CocountSplit : MonoBehaviour
{
    [SerializeField] 
    private GameObject _coconutUp, _coconutDown;

    [SerializeField]
    private Transform coconutBroken;

    private int _splitChance = 5;

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
                _coconutDown.transform.parent = coconutBroken;
                _coconutUp.transform.parent = coconutBroken;
                coconutBroken.parent = transform.parent;
                Destroy(this.gameObject);
            }
            else {  // ����� ��������� ���� ������������
                _splitChance -= 1;
            }
            _wasDetachedFromHand = false;
        }
    }
}
