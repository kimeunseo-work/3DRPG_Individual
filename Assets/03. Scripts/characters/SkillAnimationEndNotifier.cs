using UnityEngine;

public class SkillAnimationEndNotifier : StateMachineBehaviour
{
    private CharacterType characterType;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (characterType == CharacterType.None)
            characterType = animator.GetComponent<Character>().Type;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 1.0f)
        {
            EventBus_CharacterToBattle.InvokeOnSkillAnimationExited(characterType, true);
        }
    }
}