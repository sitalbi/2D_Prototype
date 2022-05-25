using UnityEngine;

namespace Enemies
{
    public class AnimationToStateMachine : MonoBehaviour
    {
        public AttackState _attackState;
        public DamageState _damagesState;
        public DeadState _deadsState;

        public void TriggerAttack() {
            _attackState.TriggerAttack();
        }

        public void FinishAttack() {
            _attackState.FinishAttack();
        }

        public void FinishDamage() {
            _damagesState.FinishDamage();
        }

        public void FinishDamageAnimation() {
            _damagesState.FinishDamageAnimation();
        }

        public void FinishDeathAnimation() {
            _deadsState.FinishDeathAnimation();
        }
    }
}
