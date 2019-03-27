namespace Plavalaguna.Joy.Prototype.Animations {
    using Red;
    using UniRx;
    using UnityEngine;
    using UnityEngine.Assertions;

    public class ROriginalSkinnedMesh : RContract<ROriginalSkinnedMesh> {
        public ReactiveProperty<SkinnedMeshRenderer> SkinnedMesh { get; } = new ReactiveProperty<SkinnedMeshRenderer>();
    }
    
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class OriginalSkinnedMesh : MonoBehaviour {
        private void Awake() {
            var sm = this.GetComponent<SkinnedMeshRenderer>();
            
            Assert.IsNotNull(sm, $"SkinnedMeshRenderer is null on script {nameof(OriginalSkinnedMesh)}");
            
            var contract = this.transform.root.GetOrCreate<ROriginalSkinnedMesh>();
            contract.SkinnedMesh.Value = this.GetComponent<SkinnedMeshRenderer>();
        }
    }
}