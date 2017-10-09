using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerController : MonoBehaviour {

    ParticleSystem m_System;
    ParticleSystem.Particle[] m_Particles;

    private Vector3 m_OriginalPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        InitializeIfNeeded();

        int numParticlesAlive = m_System.GetParticles(m_Particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_OriginalPosition = m_Particles[i].position;
            //float verticalPosition = CalculateVerticalPosition();
            //  m_Particles[i].position = new Vector3(m_Particles[i].position.x, m_Particles[i].position.y, m_Particles[i].position.z);
            // m_Particles[i].position = new Vector3(m_Particles[i].position.x, 10f, m_Particles[i].position.z);
            m_Particles[i].position = new Vector3(m_Particles[i].position.x, m_Particles[i].position.y, 10f);                                    //Z is the vertical local position

            m_System.SetParticles(m_Particles, numParticlesAlive);
        }

	}

    void InitializeIfNeeded()
    {
        if (m_System == null)
            m_System = GetComponent<ParticleSystem>();

        if (m_Particles == null || m_Particles.Length < m_System.maxParticles)
            m_Particles = new ParticleSystem.Particle[m_System.maxParticles];
    }
}
