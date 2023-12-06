
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Scriptable object, который содержит все параметры движения игрока. Если вы не хотите использовать его,
    // просто вставьте все параметры вручную, но вам придется изменить все ссылки в этом скрипте.

    // КАК ИСПОЛЬЗОВАТЬ: чтобы добавить Scriptable object, щелкните правой кнопкой мыши в окне проекта -> создать -> Player Data
    // Затем перетащите его в слот playerMovement на вашего игрока.

    public PlayerData Data; // Ссылка на Scriptable object с параметрами игрока.

    #region Переменные

    // Компоненты
    public Rigidbody2D RB { get; private set; }

    // Переменные управляют различными действиями, которые игрок может выполнять в любой момент.
    // Это поля, которые могут быть прочитаны из других скриптов, но могут быть записаны только приватно.
    public bool IsFacingRight { get; private set; } // Игрок смотрит вправо?
    public bool IsJumping { get; private set; } // Игрок выполняет прыжок?
    public bool IsWallJumping { get; private set; } // Игрок выполняет прыжок от стены?
    public bool IsSliding { get; private set; } // Игрок выполняет скольжение?

    // Таймеры (также все поля, можно было бы сделать приватными и использовать метод, возвращающий значение bool)
    public float LastOnGroundTime { get; private set; } // Время с последнего контакта с землей.
    public float LastOnWallTime { get; private set; } // Время с последнего контакта со стеной.
    public float LastOnWallRightTime { get; private set; } // Время с последнего контакта со стеной справа.
    public float LastOnWallLeftTime { get; private set; } // Время с последнего контакта со стеной слева.

    // Прыжок
    private bool _isJumpCut; // Игрок отпустил кнопку прыжка?
    private bool _isJumpFalling; // Игрок выполняет падение после прыжка?

    // Прыжок от стены
    private float _wallJumpStartTime; // Время начала прыжка от стены.
    private int _lastWallJumpDir; // Направление последнего прыжка от стены.

    private Vector2 _moveInput; // Входные данные от осей горизонтального и вертикального движения.
    public float LastPressedJumpTime { get; private set; } // Время с последнего нажатия кнопки прыжка.

    // Настройте все это в инспекторе.
    [Header("Проверки")] [SerializeField] private Transform _groundCheckPoint; // Точка проверки земли.
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f); // Размер области проверки земли.
    [Space(5)] [SerializeField] private Transform _frontWallCheckPoint; // Точка проверки передней стены.
    [SerializeField] private Transform _backWallCheckPoint; // Точка проверки задней стены.
    [SerializeField] private Vector2 _wallCheckSize = new Vector2(0.5f, 1f); // Размер области проверки стены.

    [Header("Слои и теги")] [SerializeField]
    private LayerMask _groundLayer; // Слои, считающиеся землей.

    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetGravityScale(Data.gravityScale);
        IsFacingRight = true;
    }

    private void Update()
    {
        #region ТАЙМЕРЫ

        LastOnGroundTime -= Time.deltaTime;
        LastOnWallTime -= Time.deltaTime;
        LastOnWallRightTime -= Time.deltaTime;
        LastOnWallLeftTime -= Time.deltaTime;

        LastPressedJumpTime -= Time.deltaTime;

        #endregion

        #region ОБРАБОТКА ВХОДА

        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");

        if (_moveInput.x != 0)
            CheckDirectionToFace(_moveInput.x > 0);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
        {
            OnJumpInput();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.J))
        {
            OnJumpUpInput();
        }

        #endregion

        #region ПРОВЕРКА СТОЛКНОВЕНИЯ

        if (!IsJumping)
        {
            // Проверка земли
            if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) && !IsJumping)
            {
                LastOnGroundTime =
                    Data.coyoteTime; // Если земля обнаружена, устанавливаем LastOnGroundTime равным coyoteTime.
            }

            // Проверка правой стены
            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)
                 || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) &&
                     !IsFacingRight)) && !IsWallJumping)
                LastOnWallRightTime = Data.coyoteTime;

            // Проверка левой стены
            if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) &&
                  !IsFacingRight)
                 || (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) &&
                     IsFacingRight)) && !IsWallJumping)
                LastOnWallLeftTime = Data.coyoteTime;

            // Две проверки необходимы для обеих стен, так как при каждом повороте точки проверки стены меняются местами.
            LastOnWallTime = Mathf.Max(LastOnWallLeftTime, LastOnWallRightTime);
        }

        #endregion

        #region ПРОВЕРКА ПРЫЖКА

        if (IsJumping && RB.velocity.y < 0)
        {
            IsJumping = false;

            if (!IsWallJumping)
                _isJumpFalling = true;
        }

        if (IsWallJumping && Time.time - _wallJumpStartTime > Data.wallJumpTime)
        {
            IsWallJumping = false;
        }

        if (LastOnGroundTime > 0 && !IsJumping && !IsWallJumping)
        {
            _isJumpCut = false;

            if (!IsJumping)
                _isJumpFalling = false;
        }

        // Прыжок
        if (CanJump() && LastPressedJumpTime > 0)
        {
            IsJumping = true;
            IsWallJumping = false;
            _isJumpCut = false;
            _isJumpFalling = false;
            Jump();
        }
        // Прыжок от стены
        else if (CanWallJump() && LastPressedJumpTime > 0)
        {
            IsWallJumping = true;
            IsJumping = false;
            _isJumpCut = false;
            _isJumpFalling = false;
            _wallJumpStartTime = Time.time;
            _lastWallJumpDir = (LastOnWallRightTime > 0) ? -1 : 1;

            WallJump(_lastWallJumpDir);
        }

        #endregion

        #region ПРОВЕРКА СКОЛЬЖЕНИЯ

        if (CanSlide() &&
            ((LastOnWallLeftTime > 0 && _moveInput.x < 0) || (LastOnWallRightTime > 0 && _moveInput.x > 0)))
            IsSliding = true;
        else
            IsSliding = false;

        #endregion

        #region ГРАВИТАЦИЯ

        // Большая гравитация, если отпущена кнопка прыжка или выполняется падение
        if (IsSliding)
        {
            SetGravityScale(0);
        }
        else if (RB.velocity.y < 0 && _moveInput.y < 0)
        {
            // Гораздо большая гравитация при удержании вниз
            SetGravityScale(Data.gravityScale * Data.fastFallGravityMult);
            // Ограничивает максимальную скорость падения, чтобы при падении на большие расстояния не набирать чрезмерно высокую скорость
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFastFallSpeed));
        }
        else if (_isJumpCut)
        {
            // Большая гравитация, если отпущена кнопка прыжка
            SetGravityScale(Data.gravityScale * Data.jumpCutGravityMult);
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
        }
        else if ((IsJumping || IsWallJumping || _isJumpFalling) &&
                 Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
        {
            // Меньшая гравитация при приближении к вершине прыжка
            SetGravityScale(Data.gravityScale * Data.jumpHangGravityMult);
        }
        else if (RB.velocity.y < 0)
        {
            // Большая гравитация, если выполняется падение
            SetGravityScale(Data.gravityScale * Data.fallGravityMult);
            // Ограничивает максимальную скорость падения, чтобы при падении на большие расстояния не набирать чрезмерно высокую скорость
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
        }
        else
        {
            // Обычная гравитация, если игрок стоит на платформе или движется вверх
            SetGravityScale(Data.gravityScale);
        }

        #endregion
    }


    private void FixedUpdate()
    {
        // Обработка бега
        if (IsWallJumping)
            Run(Data.wallJumpRunLerp);
        else
            Run(1);

        // Обработка скольжения
        if (IsSliding)
            Slide();
    }

    #region INPUT CALLBACKS

// Методы, которые обрабатывают ввод, обнаруженный в Update()
    public void OnJumpInput()
    {
        LastPressedJumpTime = Data.jumpInputBufferTime;
    }

    public void OnJumpUpInput()
    {
        if (CanJumpCut() || CanWallJumpCut())
            _isJumpCut = true;
    }

    #endregion

    #region GENERAL METHODS

    public void SetGravityScale(float scale)
    {
        RB.gravityScale = scale;
    }

    #endregion

// МЕТОДЫ ДВИЖЕНИЯ

    #region RUN METHODS

    private void Run(float lerpAmount)
    {
        // Вычисляем направление, в котором хотим двигаться, и желаемую скорость
        float targetSpeed = _moveInput.x * Data.runMaxSpeed;
        // Можем уменьшить управление с помощью Lerp(), чтобы сгладить изменения направления и скорости
        targetSpeed = Mathf.Lerp(RB.velocity.x, targetSpeed, lerpAmount);

        #region Вычисление AccelRate

        float accelRate;

        // Получаем значение ускорения в зависимости от того, ускоряемся ли мы (включая повороты) 
        // или пытаемся замедлиться (остановиться). Применяем множитель, если мы находимся в воздухе.
        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f)
                ? Data.runAccelAmount * Data.accelInAir
                : Data.runDeccelAmount * Data.deccelInAir;

        #endregion

        #region Добавление бонусного ускорения в вершине прыжка

        // Увеличиваем ускорение и максимальную скорость, когда мы находимся в вершине прыжка, чтобы прыжок стал более упругим, отзывчивым и естественным.
        if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
        {
            accelRate *= Data.jumpHangAccelerationMult;
            targetSpeed *= Data.jumpHangMaxSpeedMult;
        }

        #endregion

        #region Сохранение импульса

        // Мы не будем замедлять игрока, если он движется в нужном направлении, но со скоростью, превышающей максимальную скорость
        if (Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) &&
            Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f &&
            LastOnGroundTime < 0)
        {
            // Предотвращаем замедление, то есть сохраняем текущий импульс
            // Вы можете поэкспериментировать, разрешив игроку немного увеличивать свою скорость в этом "состоянии"
            accelRate = 0;
        }

        #endregion

        // Вычисляем разницу между текущей скоростью и желаемой скоростью
        float speedDif = targetSpeed - RB.velocity.x;
        // Вычисляем силу вдоль оси x, которую нужно применить к игроку

        float movement = speedDif * accelRate;

        // Преобразуем это в вектор и применяем к rigidbody
        RB.AddForce(movement * Vector2.right, ForceMode2D.Force);

        /*
         * Для тех, кто интересуется, вот что делает AddForce()
         * RB.velocity = new Vector2(RB.velocity.x + (Time.fixedDeltaTime  * speedDif * accelRate) / RB.mass, RB.velocity.y);
         * Time.fixedDeltaTime по умолчанию в Unity равен 0.02 секунды, что соответствует 50 вызовам FixedUpdate() в секунду.
         */
    }

    private void Turn()
    {
        // Сохраняем масштаб и переворачиваем игрока по оси x
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }

    #endregion

    #region JUMP METHODS

    private void Jump()
    {
        // Гарантируем, что мы не можем вызывать Jump несколько раз за одно нажатие
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        #region Выполнение прыжка

        // Увеличиваем силу, применяемую при падении, если мы уже падаем
        // Это означает, что прыжок всегда будет ощущаться одинаково 
        //(предварительно установить Y-скорость игрока на 0, вероятно, сработает так же, но я считаю это более элегантным :D)
        float force = Data.jumpForce;
        if (RB.velocity.y < 0)
            force -= RB.velocity.y;

        RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);

        #endregion
    }

    private void WallJump(int dir)
    {
        // Гарантируем, что мы не можем вызывать Wall Jump несколько раз за одно нажатие
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;
        LastOnWallRightTime = 0;
        LastOnWallLeftTime = 0;

        #region Выполнение Wall Jump

        Vector2 force = new Vector2(Data.wallJumpForce.x, Data.wallJumpForce.y);
        force.x *= dir; // прикладываем силу в противоположном направлении от стены

        if (Mathf.Sign(RB.velocity.x) != Mathf.Sign(force.x))
            force.x -= RB.velocity.x;

        if (RB.velocity.y <
            0) // проверяем, падает ли игрок, если да, вычитаем velocity.y (противодействие силе гравитации). Это гарантирует, что игрок всегда достигает нашей желаемой силы прыжка или больше
            force.y -= RB.velocity.y;

        // В отличие от бега, мы хотим использовать режим Impulse.
        // Режим по умолчанию применит силу мгновенно, игнорируя массу.
        RB.AddForce(force, ForceMode2D.Impulse);

        #endregion
    }

    #endregion

    #region OTHER MOVEMENT METHODS

    private void Slide()
    {
        // Работает так же, как бег, но только по оси y.
        // Вроде бы это работает хорошо, но, возможно, вы найдете более лучший способ реализовать скольжение в этой системе
        float speedDif = Data.slideSpeed - RB.velocity.y;
        float movement = speedDif * Data.slideAccel;
        // Здесь мы ограничиваем перемещение, чтобы предотвратить любые излишние коррекции (они не заметны при беге)
        // Применяемая сила не может быть больше (отрицательной) разницы в скорости, умноженной на количество вызовов FixedUpdate() в секунду. Для более подробной информации изучите, как применяются силы к Rigidbody.
        movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime),
            Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

        RB.AddForce(movement * Vector2.up);
    }

    #endregion


    #region CHECK METHODS

    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }

    private bool CanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    private bool CanWallJump()
    {
        return LastPressedJumpTime > 0 && LastOnWallTime > 0 && LastOnGroundTime <= 0 && (!IsWallJumping ||
            (LastOnWallRightTime > 0 && _lastWallJumpDir == 1) || (LastOnWallLeftTime > 0 && _lastWallJumpDir == -1));
    }

    private bool CanJumpCut()
    {
        return IsJumping && RB.velocity.y > 0;
    }

    private bool CanWallJumpCut()
    {
        return IsWallJumping && RB.velocity.y > 0;
    }

    public bool CanSlide()
    {
        if (LastOnWallTime > 0 && !IsJumping && !IsWallJumping && LastOnGroundTime <= 0)
            return true;
        else
            return false;
    }

    #endregion


    #region EDITOR METHODS

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(_frontWallCheckPoint.position, _wallCheckSize);
        Gizmos.DrawWireCube(_backWallCheckPoint.position, _wallCheckSize);
    }

    #endregion
}