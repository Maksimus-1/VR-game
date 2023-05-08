using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocountSplit : MonoBehaviour
{
    [SerializeField] GameObject coconutUp, coconutDown;
    [SerializeField] Transform coconutBroken;

    int splitChance = 5;

    bool wasDetachedFromHand;
    public bool WasDetachedFromHand {
        get { return wasDetachedFromHand; }
        set { wasDetachedFromHand = value; }
    }
    
    private void OnCollisionEnter(Collision collision) {
        if (wasDetachedFromHand) {
            if (Random.Range(0, splitChance) == 0) {    // ����� ����� 0, �� ����� ������ �����������
                coconutDown.SetActive(true);
                coconutUp.SetActive(true);
                coconutDown.transform.parent = coconutBroken;
                coconutUp.transform.parent = coconutBroken;
                coconutBroken.parent = transform.parent;
                Destroy(this.gameObject);
            }
            else {  // ����� ��������� ���� ������������
                splitChance -= 1;
            }
            wasDetachedFromHand = false;
        }
    }
}
