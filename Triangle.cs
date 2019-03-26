using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Triangle : MonoBehaviour
{
    public Transform[] bones;
    SkinnedMeshRenderer smr;

    private void Awake()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();

        m.vertices = new Vector3[]
      {
            new Vector3(0,0,0),
            new Vector3(-0.5f,1,0),
            new Vector3(0.5f,1,0), //head

            new Vector3(-0.75f,0,0),
            new Vector3(0.75f,0,0),
            new Vector3(0,-1.5f,0), //body

            new Vector3(-0.75f,0,0),
            new Vector3(-1.75f,0.25f,0),
            new Vector3(-1.75f,-0.25f,0), //left arm1

            new Vector3(-1.75f,0.25f,0),
            new Vector3(-1.75f,-0.25f,0),
            new Vector3(-2,0,0), //left arm2

            new Vector3(0.75f,0,0),
            new Vector3(1.75f,0.25f,0),
            new Vector3(1.75f,-0.25f,0), //right arm1

            new Vector3(1.75f,0.25f,0),
            new Vector3(1.75f,-0.25f,0),
            new Vector3(2,0,0), //right arm2
          
            new Vector3(0,-1.5f,0),
            new Vector3(-0.5f,-2,0),
            new Vector3(0.5f,-2,0), //bottom
       
            new Vector3(-0.5f,-2,0),
            new Vector3(-0.75f,-3,0),
            new Vector3(-0.25f,-3,0), //left leg1

            new Vector3(-0.75f,-3,0),
            new Vector3(-0.25f,-3,0),
            new Vector3(-0.5f,-4,0), //left leg2

            new Vector3(0.5f,-2,0),
            new Vector3(0.75f,-3,0),
            new Vector3(0.25f,-3,0), //right leg1

            new Vector3(0.75f,-3,0),
            new Vector3(0.25f,-3,0),
            new Vector3(0.5f,-4,0) //right leg2

      };

        m.triangles = new int[]
        {
            0,1,2, //head

            3,4,5,//body

            8,7,6, //left arm1
            9,10,11, //left arm2

            12,13,14, //right arm1
            17,16,15, //right arm2

            20,19,18, //bottom

            23,22,21, //left leg1
            24,25,26,  //left leg2

            27,28,29, //right leg1
            32,31,30  //right leg2
        };

        m.bindposes = new Matrix4x4[]
        {
            bones[0].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[1].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[2].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[3].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[4].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[5].worldToLocalMatrix * transform.localToWorldMatrix,
            bones[6].worldToLocalMatrix * transform.localToWorldMatrix
        
        };

        m.boneWeights = new BoneWeight[]
        {
            new BoneWeight() {boneIndex0 = 0,weight0 = 1},
            new BoneWeight() {boneIndex0 = 0,weight0 = 1},
            new BoneWeight() {boneIndex0 = 0,weight0 = 1}, //head

            new BoneWeight() {boneIndex0 = 1,weight0 = 1},
            new BoneWeight() {boneIndex0 = 1,weight0 = 1},
            new BoneWeight() {boneIndex0 = 1,weight0 = 1}, //body

            new BoneWeight() {boneIndex0 = 2,weight0 = 1},
            new BoneWeight() {boneIndex0 = 2,weight0 = 1},
            new BoneWeight() {boneIndex0 = 2,weight0 = 1}, //left arm

            new BoneWeight() {boneIndex0 = 3,weight0 = 1},
            new BoneWeight() {boneIndex0 = 3,weight0 = 1},
            new BoneWeight() {boneIndex0 = 3,weight0 = 1},//right arm

            new BoneWeight() {boneIndex0 = 4,weight0 = 1},
            new BoneWeight() {boneIndex0 = 4,weight0 = 1},
            new BoneWeight() {boneIndex0 = 4,weight0 = 1}, //bottom
       
            new BoneWeight() {boneIndex0 = 5,weight0 = 1},
            new BoneWeight() {boneIndex0 = 5,weight0 = 1},
            new BoneWeight() {boneIndex0 = 5,weight0 = 1}, //left leg

            new BoneWeight() {boneIndex0 = 6,weight0 = 1},
            new BoneWeight() {boneIndex0 = 6,weight0 = 1},
            new BoneWeight() {boneIndex0 = 6,weight0 = 1} //right leg


        };

        smr = GetComponent<SkinnedMeshRenderer>();
        smr.bones = bones;
        smr.sharedMesh = m;
        smr.quality = SkinQuality.Bone1;
    }
}
