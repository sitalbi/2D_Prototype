using UnityEngine;

namespace Enemies
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public AttackState _attackState;
        public DamageState _damagesState;

        public void TriggerAttack() {
            _attackState.TriggerAttack();
        }

        public void FinishAttack() {
            _attackState.FinishAttack();
        }

        public void FinishDamage() {
            _damagesState.FinishDamage();
        }
    }
}
