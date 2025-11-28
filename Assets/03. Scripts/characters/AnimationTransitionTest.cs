using UnityEngine;

public enum Animation
{
    Die,
    Run,
    Attack,
    Skill
}

public class AnimationTransitionTest : StateMachineBehaviour
{
    [SerializeField] Animation animation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        Debug.Log($"{animation} | Enter");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        Debug.Log($"{animation} | Exit");
    }
}