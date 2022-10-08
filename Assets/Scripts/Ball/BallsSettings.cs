using UnityEngine;
using System;

namespace Game
{
    [Serializable, CreateAssetMenu(menuName = "Game/Balls Settings")]
    public class BallsSettings : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField, Tooltip("Time in seconds between two ball speed and direction randomizations.")]
        private float _directionAndSpeedRandomizeTime = 1.0f;
        /// <summary>
        /// Time in seconds between two ball speed and direction randomizations.
        /// </summary>
        public float DirectionAndSpeedRandomizeTime => _directionAndSpeedRandomizeTime;

        [SerializeField, Tooltip("Minimum ball movement speed.")]
        private float _minSpeed = 1.0f;
        /// <summary>
        /// Minimum ball movement speed.
        /// </summary>
        public float MinSpeed => _minSpeed;

        [SerializeField, Tooltip("Maximum ball movement speed.")]
        private float _maxSpeed = 5.0f;
        /// <summary>
        /// Maximum ball movement speed.
        /// </summary>
        public float MaxSpeed => _maxSpeed;
    }
}