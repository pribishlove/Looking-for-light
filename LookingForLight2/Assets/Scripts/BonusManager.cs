using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public delegate void BonusCollectedAction();
    public static event BonusCollectedAction OnBonusCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ����� �������� �����, �������� �������
            TriggerBonusCollected();

            // ��������� �������������� �������� ��� ������� ������
            Destroy(gameObject);
        }
    }

    private void TriggerBonusCollected()
    {
        OnBonusCollected?.Invoke();
    }
}
