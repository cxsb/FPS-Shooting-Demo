using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A2
{
    public class Enemy2Behaviour : MonoBehaviour
    {
        public Character character;

        public InitiativeEquipment initiativeEquipment;
        public GameObject initiativeEquipmentRoot;
        public UnityEngine.AI.NavMeshAgent agent;
        public GameObject target;
        private Vector3 targetPos;
        private Vector3 initPos;
        private bool reset = false;
        [SerializeField] private float m_searchRange=10;
        [SerializeField] private float m_stopRange=5;
        [SerializeField] private float m_speed=3;

        public float aimSpeed = 0.75f;
        private float _aimSpeed = 0.015f;

        // Start is called before the first frame update
        void Start()
        {
            _aimSpeed = aimSpeed / 50f;
            agent.speed = m_speed;
            agent.updateRotation = true;
            initPos = transform.position;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            targetPos = target.gameObject.transform.position;
            bool find = (targetPos-transform.position).magnitude<m_searchRange;
            bool touch = (targetPos-transform.position).magnitude<m_stopRange;

            if (find)
            {
                if (touch)
                {
                    Vector3 dir = targetPos - transform.position;

                    RaycastHit hit;
                    if (Physics.Raycast(transform.position, dir, out hit))
                    {
                        if (hit.collider.gameObject == target)
                        {
                            agent.ResetPath();
                            if (initiativeEquipment != null)
                            {
                                Vector3 currentDir = Vector3.Lerp(initiativeEquipmentRoot.transform.forward, dir, _aimSpeed);
                                initiativeEquipmentRoot.transform.rotation = Quaternion.LookRotation(currentDir);
                                //瞄准玩家攻击
                                initiativeEquipment.FunctionBtnInput(character, BtnType.Main1, BtnInputType.Down);

                                currentDir = Vector3.Lerp(transform.forward, dir, _aimSpeed);
                                currentDir.y = 0;
                                transform.rotation = Quaternion.LookRotation(currentDir);
                            }
                        }
                        else
                        {
                            initiativeEquipment.FunctionBtnInput(character, BtnType.Main1, BtnInputType.Up);
                            agent.SetDestination(targetPos);
                        }
                    }
                    else
                    {
                        initiativeEquipment.FunctionBtnInput(character, BtnType.Main1, BtnInputType.Up);
                        agent.SetDestination(targetPos);
                    }


                }
                else
                {
                    initiativeEquipment.FunctionBtnInput(character, BtnType.Main1, BtnInputType.Up);
                    if (find)
                    {
                        agent.SetDestination(targetPos);
                        reset = true;//被引出来了
                    }
                    if (!find)
                    {
                        if (reset)//如果是被引出来的
                        {
                            reset = false;//回去
                            agent.ResetPath();
                            StartCoroutine(waitOneSecond());
                        }
                    }
                }
            }
        }

        IEnumerator waitOneSecond(){
            yield return new WaitForSeconds(1.0f);
            agent.SetDestination(initPos);
        }
    }
}