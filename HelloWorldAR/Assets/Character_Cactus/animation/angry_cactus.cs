using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character_Cactus.animation
{
    public class angry_cactus : MonoBehaviour
    {
        public GameObject target;
        public float attackRange = 0.25f;
        private Animator _animator;
        private int _isAttackingHash;

        private float MoveRange = 0.5f;
        private float RotationSpeed = 1f;

        private int _isMovingHash;

        void Start()
        {
            _animator = GetComponent<Animator>();
            _isAttackingHash = Animator.StringToHash("_isAttacking");
            _isMovingHash = Animator.StringToHash("_isMoving");

        }

        void Update()
        {
            bool isAttacking = _animator.GetBool(_isAttackingHash); //get bool value from animator inside unity
            bool isMoving = _animator.GetBool(_isMovingHash);

            if (target == null)
            {
                _animator.SetBool(_isMovingHash, false);
                _animator.SetBool(_isAttackingHash, false);
            }
            else
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);
                
                //rotate object to face target

                Vector3 direction = (target.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);

                //if the distance is less than attack range, attack
                if (distance <= attackRange)
                {
                    _animator.SetBool(_isAttackingHash, true);
                    _animator.SetBool(_isMovingHash, false);
                }
                //if the distance is less than move range, move
                else if (distance < MoveRange)
                {
                    _animator.SetBool(_isMovingHash, true);
                    _animator.SetBool(_isAttackingHash, false);
                }
                else
                {
                    _animator.SetBool(_isMovingHash, false);
                    _animator.SetBool(_isAttackingHash, false);
                }


            }
            
          
        }
    }
}
