using UnityEngine;

namespace Game
{
    public class RecolorBySpeed : Skill
    {
        [Header("Settings")]
        [SerializeField, Tooltip("Ball movement speed to recolor.")]
        private float _speedToRecolor = 3.0f;
        [SerializeField]
        private Color _newBallColor;

        private MeshRenderer ownerRenderer;
        private float previousSpeed = 0.0f;
        private bool recolorNeeded = false;

        public override void Construct(Ball owner)
        {
            base.Construct(owner);

            ownerRenderer = Owner.GetComponent<MeshRenderer>();

            if (ownerRenderer != null)
                return;

            throw new MissingComponentException($"Missing 'MeshRenderer' component on the ball! Ball: '{Owner.gameObject.name}'");
        }

        protected override void ProcessState(BallState state)
        {
            recolorNeeded = previousSpeed < _speedToRecolor && state.Speed >= _speedToRecolor;

            previousSpeed = state.Speed;

            if (!recolorNeeded)
                return;

            Recolor();
        }

        private void Recolor()
        {
            ownerRenderer.material.color = _newBallColor;
        }
    }
}