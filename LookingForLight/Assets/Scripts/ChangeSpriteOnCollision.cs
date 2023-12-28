using UnityEngine;

public class ChangeSpriteOnPlayerCollision : MonoBehaviour
{
    public Sprite newSprite;  // ������� ����� ������ � ����������
    private Sprite originalSprite;  // ������, ������� ����� �������� ��� ������

    private void Start()
    {
        originalSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        // ������ ������ �� �����
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
