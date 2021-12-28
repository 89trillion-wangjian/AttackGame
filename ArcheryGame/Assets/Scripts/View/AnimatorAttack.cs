using UnityEngine;

namespace View
{
    public class AnimatorAttack : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // 正在played的状态的第一帧被调用
            Debug.Log("------OnStateEnter------------");
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // 转换到另一个状态的最后一帧 被调用
            Debug.Log("-------------OnStateExit-----------------");
        }


/*    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 在OnAnimatorMove之前被调用
        Debug.Log("-------------OnStateMove-----------------");
    }
*/
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // 在OnAnimatorMove之前被调用
        }
    }
}