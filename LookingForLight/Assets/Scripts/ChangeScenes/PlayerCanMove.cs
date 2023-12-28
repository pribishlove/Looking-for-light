using UnityEngine;
using UnityEngine.UI;


public class PlayerCanMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            // Обрабатывайте ввод и передвижение только если разрешено
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }

    // Метод для включения или отключения управления
    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }
}
