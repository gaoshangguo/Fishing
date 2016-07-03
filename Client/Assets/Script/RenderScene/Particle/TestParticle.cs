using UnityEngine;
using System.Collections;

namespace Fishing
{
    public class TestParticle : MonoBehaviour
    {
        ParticleSystem mParticleSystem = null;
        // Use this for initialization
        void Start()
        {
            mParticleSystem = GetComponent<ParticleSystem>();
            Debug.LogWarning(mParticleSystem.duration);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
