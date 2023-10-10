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
        void Start()
        {
            _animator = GetComponent<Animator>();
            _isAttackingHash = Animator.StringToHash("_isAttacking"); //saving memory
        }

        void Update()
        {
            bool isAttacking = _animator.GetBool(_isAttackingHash); //get bool value from animator inside unity
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= attackRange && !isAttacking)
            {
                _animator.SetBool(_isAttackingHash, true);
            }
            if (distance > attackRange && isAttacking)
            {
                _animator.SetBool(_isAttackingHash, false);
            }
        }
    }
}