using UnityEngine;

namespace BalanseMaze
{
    [CreateAssetMenu(fileName = "BalanceMazeConfig", menuName = "ScriptableObjects/Maze/BalanceMazeConfig")]
    public class BalanceMazeConfig : ScriptableObject
    {
        [SerializeField] private float maxAngle;

        public float MaxAngle => maxAngle;
    }
}