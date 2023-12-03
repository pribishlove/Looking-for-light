using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")] // Создаем новый объект playerData, щелкнув правой кнопкой мыши в окне проекта, затем Create/Player/Player Data, и перетащите его на игрока
public class PlayerData : ScriptableObject
{
	[Header("Гравитация")]
	[HideInInspector] public float gravityStrength; // Сила притяжения (гравитация), необходимая для желаемой высоты прыжка и времени прыжка до вершины.
	[HideInInspector] public float gravityScale; // Сила гравитации игрока как множитель гравитации (задается в ProjectSettings/Physics2D).
	// Также это значение, устанавливаемое для rigidbody2D.gravityScale игрока.
	[Space(5)]
	public float fallGravityMult; // Множитель для gravityScale игрока при падении.
	public float maxFallSpeed; // Максимальная скорость падения (терминальная скорость) игрока при падении.
	[Space(5)]
	public float fastFallGravityMult; // Больший множитель для gravityScale игрока, когда он падает и нажата кнопка вниз.
	// Позволяет игроку падать особенно быстро, если он хочет.
	public float maxFastFallSpeed; // Максимальная скорость падения (терминальная скорость) игрока при выполнении быстрого падения.

	[Space(20)]

	[Header("Бег")]
	public float runMaxSpeed; // Целевая скорость, которую мы хотим, чтобы игрок достиг.
	public float runAcceleration; // Скорость, с которой наш игрок ускоряется до максимальной скорости, может быть установлена на runMaxSpeed для мгновенного ускорения или на 0, чтобы не было ускорения.
	[HideInInspector] public float runAccelAmount; // Фактическая сила (умноженная на speedDiff), применяемая к игроку.
	public float runDecceleration; // Скорость, с которой наш игрок замедляется с текущей скорости, может быть установлена на runMaxSpeed для мгновенного замедления или на 0, чтобы не было замедления.
	[HideInInspector] public float runDeccelAmount; // Фактическая сила (умноженная на speedDiff), применяемая к игроку.
	[Space(5)]
	[Range(0f, 1)] public float accelInAir; // Множители, применяемые к скорости ускорения, когда игрок в воздухе.
	[Range(0f, 1)] public float deccelInAir;
	[Space(5)]
	public bool doConserveMomentum = true;

	[Space(20)]

	[Header("Прыжок")]
	public float jumpHeight; // Высота прыжка игрока.
	public float jumpTimeToApex; // Время между применением силы прыжка и достижением желаемой высоты прыжка.
	[HideInInspector] public float jumpForce; // Фактическая сила, применяемая к игроку вверх, когда он прыгает.

	[Header("Оба типа прыжков")]
	public float jumpCutGravityMult; // Множитель для увеличения гравитации, если игрок отпускает кнопку прыжка во время прыжка.
	[Range(0f, 1)] public float jumpHangGravityMult; // Уменьшает гравитацию, когда игрок близок к вершине прыжка.
	public float jumpHangTimeThreshold; // Скорости (близкие к 0), при которых игрок будет испытывать дополнительное "задержание прыжка".
	// Скорость velocity.y игрока наиболее близка к 0 на вершине прыжка (подумайте о градиенте параболы или квадратичной функции).
	[Space(0.5f)]
	public float jumpHangAccelerationMult;
	public float jumpHangMaxSpeedMult;

	[Header("Прыжок на стену")]
	public Vector2 wallJumpForce; // Фактическая сила (на этот раз заданная нами), применяемая к игроку при прыжке от стены.
	[Space(5)]
	[Range(0f, 1f)] public float wallJumpRunLerp; // Уменьшает эффект движения игрока во время прыжка от стены.
	[Range(0f, 1.5f)] public float wallJumpTime; // Время после прыжка от стены, когда движение игрока замедляется.
	public bool doTurnOnWallJump; // Игрок повернется в сторону прыжка от стены.

	[Space(20)]

	[Header("Скольжение")]
	public float slideSpeed;
	public float slideAccel;

	[Header("Помощники")]
	[Range(0.01f, 0.5f)] public float coyoteTime; // Период допустимой задержки после падения с платформы, когда можно все равно прыгнуть.
	[Range(0.01f, 0.5f)] public float jumpInputBufferTime; // Период допустимой задержки после нажатия прыжка, когда прыжок будет автоматически выполнен, как только будут выполнены требования (например, находится на земле).

	
	


	// Unity Callback, вызывается при обновлении инспектора
    private void OnValidate()
    {
		// Рассчитываем силу гравитации с помощью формулы (гравитация = 2 * jumpHeight / timeToJumpApex^2)
		gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);

		// Рассчитываем масштаб гравитации rigidbody (т.е. сила гравитации относительно значения гравитации unity, см. ProjectSettings/Physics2D)
		gravityScale = gravityStrength / Physics2D.gravity.y;

		// Рассчитываем ускорение и замедление бега, используя формулу: amount = ((1 / Time.fixedDeltaTime) * acceleration) / runMaxSpeed
		runAccelAmount = (50 * runAcceleration) / runMaxSpeed;
		runDeccelAmount = (50 * runDecceleration) / runMaxSpeed;

		// Рассчитываем jumpForce с помощью формулы (initialJumpVelocity = gravity * timeToJumpApex)
		jumpForce = Mathf.Abs(gravityStrength) * jumpTimeToApex;

		#region Диапазон переменных
		runAcceleration = Mathf.Clamp(runAcceleration, 0.01f, runMaxSpeed);
		runDecceleration = Mathf.Clamp(runDecceleration, 0.01f, runMaxSpeed);
		#endregion
	}
}
