using UnityEngine;

namespace Enemies
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public AttackState _attackState;

        public void TriggerAttack() {
            _attackState.TriggerAttack();
        }

        public void FinishAttack() {
            _attackState.FinishAttack();
        }
    }
}
