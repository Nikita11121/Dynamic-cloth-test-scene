namespace Plavalaguna.Joy.Prototype.Animations {
    using System.Collections.Generic;
    using Red;
    using UniRx;
    using UnityEngine;

    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class Equipment : MonoBehaviour {

        private async void Start() {
            var targetSkinnedMeshContract = this.transform.root.GetOrCreate<ROriginalSkinnedMesh>();
            var targetSkinnedMesh = await targetSkinnedMeshContract.SkinnedMesh.Where(sm => sm != null).First();
            
            var boneMap = new Dictionary<string, Transform>();
            foreach (var bone in targetSkinnedMesh.bones) {
                boneMap[bone.gameObject.name] = bone;
            }


            var myRenderer = this.gameObject.GetComponent<SkinnedMeshRenderer>();
            var newBones = new Transform[myRenderer.bones.Length];
            for (int i = 0; i < myRenderer.bones.Length; ++i)
            {
                var bone = myRenderer.bones[i].gameObject;
                if (!boneMap.TryGetValue(bone.name, out newBones[i])) {
                    Debug.Log("Unable to map bone \"" + bone.name + "\" to target skeleton.");
                    break;
                }
            }
            myRenderer.bones = newBones;
        }
    }
}