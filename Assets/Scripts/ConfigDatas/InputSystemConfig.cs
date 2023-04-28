using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BalanseMaze
{
    [CreateAssetMenu(fileName = "InputSystemConfig", menuName = "ScriptableObjects/InputSystem/InputSystemConfig")]
    public class InputSystemConfig : ScriptableObject
    {
        [SerializeField] private TypeInput typeInput;
        [SerializeField] private float deathZone;

        public TypeInput TypeInput => typeInput;
        public float DeathZone => deathZone;
    }
}