using UnityEngine;
using System.Collections.Generic;

namespace Game
{
    [RequireComponent(typeof(Ball))]
    public class SkillsComponent : MonoBehaviour
    {
        [Header("General")]
        [SerializeField, Tooltip("Array with references to skill prefabs.")]
        private Skill[] _skills = null;

        private Ball owner;
        private Skill[] ballSkills;

        private void Start()
        {
            owner = GetComponent<Ball>();

            ConstructSkills();
        }

        private void ConstructSkills()
        {
            ballSkills = new Skill[_skills.Length];

            for (int i = 0; i < _skills.Length; i++)
            {
                ballSkills[i] = CreateSkill(_skills[i]);
            }
        }

        private Skill CreateSkill(Skill prefab)
        {
            Skill newSkill = Instantiate(prefab, transform);

            newSkill.Construct(owner);

            return newSkill;
        }
    }
}