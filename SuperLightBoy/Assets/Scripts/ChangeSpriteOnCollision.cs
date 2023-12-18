using UnityEngine;

public class ChangeSpriteOnPlayerCollision : MonoBehaviour
{
    public Sprite newSprite;  // ”кажите новый спрайт в инспекторе
    private Sprite originalSprite;  // —прайт, который будет сохранен при старте

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
        // ћен€ем спрайт на новый
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
