using UnityEngine;

public enum CharacterType
{
    None,
    Babarian
}

public class Character : MonoBehaviour
{
    #region SerializeFields
    [Header("Character")]
    [SerializeField] CharacterType type;
    [SerializeField] CharacterSO data;
    [Header("Movement")]
    [SerializeField] Transform target;
    [SerializeField] CharacterController controller;
    [Header("Animation")]
    [SerializeField] Animator animator;
    [SerializeField] CharacterAnimationData animationData;
    #endregion

    #region SerializeFields's Properties
    public CharacterType Type => type;
    public CharacterSO Data => data;
    public Transform
        
        
        Target => target;
    public CharacterController Controller => controller;
    public Animator Animator => animator;
    public CharacterAnimationData AnimationData => animationData;
    #endregion

    public CharacterStateMachine StateMachine { get; private set; }

#if UNITY_EDITOR

    private void Reset()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
#endif

    #region Unity Life Cycle
    private void Awake()
    {
        animationData.Init();

        StateMachine = new CharacterStateMachine(this);
        StateMachine.ChangeState(StateMachine.RunState);
    }

    private void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.PhysicsUpdate();
    }
    #endregion
}