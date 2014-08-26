#ifndef PARTICLE_H
#define PARTICLE_H

#include "Vector2.h"
#include "Colour.h"
#include "Export.h"

enum ParticleType {
    PARTICLE_CIRCLE = 0,
    PARTICLE_DIAMOND,
};

class Particle
{
public:
    Particle(Vector2f position, Vector2f linearVelocity, float angle, float angularVelocity, Colour initialColour, Colour finalColour, float initialTTL, float currentTTL);
    ~Particle();

    void        Update(float delta);
    bool        IsDead()                        { return m_currentTTL <= 0; }
    
    Colour      m_initial_Colour;
    Colour      m_final_Colour;

    Vector2f    const &GetPosition()            { return m_position; }
    float       const &GetParticleInitialTTL()  { return m_initialTTL; }
    float       const &GetParticleCurrentTTL()  { return m_currentTTL; }

private:
    Vector2f    m_position;
    Vector2f    m_linearVelocity;
    float       m_angle;
    float       m_angularVelocity;
    float       m_initialTTL;
    float       m_currentTTL;
};

extern "C" {
    PARTICLE_API float  GetX(Particle ** p);
    PARTICLE_API float  GetY(Particle ** p);
    PARTICLE_API float  GetInitialTTL(Particle ** p);
    PARTICLE_API float  GetCurrentTTL(Particle ** p);

    PARTICLE_API int GetInitialColourR(Particle ** p);
    PARTICLE_API int GetInitialColourG(Particle ** p);
    PARTICLE_API int GetInitialColourB(Particle ** p);
    PARTICLE_API int GetInitialColourA(Particle ** p);
    PARTICLE_API int GetFinalColourR(Particle ** p);
    PARTICLE_API int GetFinalColourG(Particle ** p);
    PARTICLE_API int GetFinalColourB(Particle ** p);
    PARTICLE_API int GetFinalColourA(Particle ** p);
}

#endif