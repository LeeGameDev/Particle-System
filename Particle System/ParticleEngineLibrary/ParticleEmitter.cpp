#include "ParticleEmitter.h"

#define MIN_VEL -25.5f
#define MAX_VEL 25.5f
#define MIN_TTL 2.0f
#define MAX_TTL 4.0f

ParticleEmitter::ParticleEmitter(Vector2f location, int emissionRate, int maxParticles, int seed) 
    : m_location(location), m_random(), m_emissionRate(emissionRate), m_emitting(false), m_maxParticles(maxParticles) {
}

int ParticleEmitter::GetEmissionRate() {
    return m_emissionRate;
}

int ParticleEmitter::GetMaxParticles() {
    return m_maxParticles;
}

int ParticleEmitter::GetParticleCount() {
    return m_particles.size();
}

int ParticleEmitter::GetParticleType() {
    return (int)m_type;
}

bool ParticleEmitter::GetIsEmitting() {
    return m_emitting;
}

void ParticleEmitter::StartEmitting() {
    m_emitting = true;
}

void ParticleEmitter::StopEmitting() {
    m_emitting = false;
}

void ParticleEmitter::DeleteAllParticles() {
    for(unsigned int p = 0; p < m_particles.size(); p++) {
        delete m_particles[p];
    }
    m_particles.clear();
}

void ParticleEmitter::Update(float delta) {
    // Emit some particles.
    if(m_emitting && m_particles.size() < m_maxParticles) {
        for(int p = 0; p < m_emissionRate; p++) {
            if( m_particles.size() < m_maxParticles ) {
                float mag = nextFloat(MIN_VEL, MAX_VEL);
                float radians = nextFloat(0, 360);
                float initialTTL = nextFloat(MIN_TTL, MAX_TTL);
                float currentTTL = initialTTL;
                m_particles.push_back(new Particle(m_location, Vector2f( cos(radians) * mag, sin(radians) * mag), 0.0f, 0.0f, *m_initialColour, *m_finalColour, initialTTL, currentTTL));
            } else {
                break;
            }
        }
    }
    
    for(unsigned int p = 0; p < m_particles.size(); ) {
        m_particles[p]->Update(delta);
        
        if(m_particles[p]->IsDead()) {
            // Delete the dead particle.
            delete m_particles[p];
            // Swap with last one on the list.
            m_particles[p] = m_particles[m_particles.size() - 1];
            // Pop it off the list.
            m_particles.pop_back();
        } else {
            p++;
        }
    }
}


void ParticleEmitter::changeType(int type) {
    switch (type)
    {
    case 1:
        m_type = ParticleType::PARTICLE_DIAMOND;
        break;
    default:
        m_type = ParticleType::PARTICLE_CIRCLE;
        break;
    }
}

void ParticleEmitter::setMaxParticles(int maxParticles) {
    m_maxParticles = maxParticles;
}

void ParticleEmitter::setEmissionRate(int emissionRate) {
    m_emissionRate = emissionRate;
}

float ParticleEmitter::nextFloat(float lo, float hi) {
    return lo + (float)m_random() / (float)( m_random.max() / (hi - lo) );
}

ParticleEmitter::~ParticleEmitter()
{
    for(unsigned int p = 0; p < m_particles.size(); p++) {
        delete m_particles[p];
    }
    if (m_initialColour != NULL) {
        delete m_initialColour;
    }
    if (m_finalColour != NULL) {
        delete m_finalColour;
    }
    m_particles.clear();
}

int GetEmitterInitialColourA(ParticleEmitter * p) {
    return static_cast<int>(p->m_initialColour->A);
}

int GetEmitterInitialColourR(ParticleEmitter * p) {
    return static_cast<int>(p->m_initialColour->R);
}

int GetEmitterInitialColourG(ParticleEmitter * p) {
    return static_cast<int>(p->m_initialColour->G);
}

int GetEmitterInitialColourB(ParticleEmitter * p) {
	return static_cast<int>(p->m_initialColour->B);
}

int GetEmitterFinalColourA(ParticleEmitter * p) {
    return static_cast<int>(p->m_finalColour->A);
}

int GetEmitterFinalColourR(ParticleEmitter * p) {
    return static_cast<int>(p->m_finalColour->R);
}

int GetEmitterFinalColourG(ParticleEmitter * p) {
    return static_cast<int>(p->m_finalColour->G);
}

int GetEmitterFinalColourB(ParticleEmitter * p) {
    return static_cast<int>(p->m_finalColour->B);
}
