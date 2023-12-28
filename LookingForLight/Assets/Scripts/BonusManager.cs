using UnityEngine;

public class BonusManager : MonoBehaviour
{
    public delegate void BonusCollectedAction();
    public static event BonusCollectedAction OnBonusCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Игрок подобрал бонус, вызываем событие
            TriggerBonusCollected();

            // Выполняем дополнительные действия при подборе бонуса
            Destroy(gameObject);
        }
    }

    private void TriggerBonusCollected()
    {
        OnBonusCollected?.Invoke();
    }
}
