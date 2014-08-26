#ifndef PARTICLE_EMITTER_H
#define PARTICLE_EMITTER_H

#include <random>
#include <vector>

#include "Export.h"
#include "Vector2.h"
#include "Particle.h"
#include "Colour.h"

class ParticleEmitter;

extern "C" PARTICLE_API Particle    **GetFirstParticle(ParticleEmitter * object);

extern "C" PARTICLE_API int			GetEmitterInitialColourR(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterInitialColourG(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterInitialColourB(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterInitialColourA(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterFinalColourR(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterFinalColourG(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterFinalColourB(ParticleEmitter * p);
extern "C" PARTICLE_API int			GetEmitterFinalColourA(ParticleEmitter * p);

extern "C" PARTICLE_API void        SetInitialColour(ParticleEmitter * object, int r, int g, int b, int a);
extern "C" PARTICLE_API void        SetFinalColour(ParticleEmitter * object, int r, int g, int b, int a);
extern "C" PARTICLE_API void        SetEmitterX(ParticleEmitter * object, float x);
extern "C" PARTICLE_API void        SetEmitterY(ParticleEmitter * object, float y);
extern "C" PARTICLE_API float       GetEmitterX(ParticleEmitter * object);
extern "C" PARTICLE_API float       GetEmitterY(ParticleEmitter * object);

class PARTICLE_API ParticleEmitter
{
    friend PARTICLE_API Particle    **GetFirstParticle(ParticleEmitter * object);
    
	friend PARTICLE_API int			GetEmitterInitialColourR(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterInitialColourG(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterInitialColourB(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterInitialColourA(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterFinalColourR(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterFinalColourG(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterFinalColourB(ParticleEmitter * p);
	friend PARTICLE_API int			GetEmitterFinalColourA(ParticleEmitter * p);

    friend PARTICLE_API void        SetInitialColour(ParticleEmitter * object, int r, int g, int b, int a);
    friend PARTICLE_API void        SetFinalColour(ParticleEmitter * object, int r, int g, int b, int a);
    friend PARTICLE_API void        SetEmitterX(ParticleEmitter * object, float x);
	friend PARTICLE_API void        SetEmitterY(ParticleEmitter * object, float y);
	friend PARTICLE_API float       GetEmitterX(ParticleEmitter * object);
	friend PARTICLE_API float       GetEmitterY(ParticleEmitter * object);

public:
    ParticleEmitter(Vector2f location, int emissionRate, int maxParticles, int seed = 10);
    ~ParticleEmitter();

    void StartEmitting();
    void StopEmitting();

    void DeleteAllParticles();

    void Update(float delta);
    void changeType(int type);
    void setMaxParticles(int maxParticles);
    void setEmissionRate(int emissionRate);

    int  GetMaxParticles();
    int  GetEmissionRate();
    int  GetParticleCount();
    int  GetParticleType();
    bool GetIsEmitting();

private:
    Vector2f                    m_location;
    std::vector<Particle *>     m_particles;
    std::default_random_engine  m_random;
    bool                        m_emitting;
    int                         m_emissionRate;
    int                         m_maxParticles;
    ParticleType                m_type;
    Colour *                    m_initialColour;
    Colour *                    m_finalColour;

    float nextFloat(float lo, float high);
};

extern "C" {
    PARTICLE_API ParticleEmitter *CreateDefaultParticleEmitter_Object() {
        return new ParticleEmitter(Vector2f(150.0f, 150.0f), 100, 3000, 10);
    }
}

extern "C" PARTICLE_API ParticleEmitter *CreateParticleEmitter_Object(float x, float y, int rate, int max, int seed) {
        return new ParticleEmitter(Vector2f(x, y), rate, max, seed);
}

extern "C" {
    PARTICLE_API void DeleteParticleEmitter_Object(ParticleEmitter *object) {
        if(object != NULL) {
            delete object;
            object = NULL;
        }
    }
}
extern "C" PARTICLE_API Particle ** GetFirstParticle(ParticleEmitter * object) {
    if (object->m_particles.size() > 0) {
        return &(object->m_particles[0]);
    }
    else {
        return NULL;
    }
}

extern "C" PARTICLE_API void SetInitialColour(ParticleEmitter * object, int r, int g, int b, int a) {
    if (object->m_initialColour != NULL) {
        delete object->m_initialColour;
    }
    object->m_initialColour = new Colour(
        static_cast<unsigned char>(r),
        static_cast<unsigned char>(g),
        static_cast<unsigned char>(b),
        static_cast<unsigned char>(a));
}
extern "C" PARTICLE_API void SetFinalColour(ParticleEmitter * object, int r, int g, int b, int a) {
    if (object->m_finalColour!= NULL) {
        delete object->m_finalColour;
    }
    object->m_finalColour = new Colour(
        static_cast<unsigned char>(r),
        static_cast<unsigned char>(g),
        static_cast<unsigned char>(b),
        static_cast<unsigned char>(a));
}

extern "C" PARTICLE_API float GetEmitterX(ParticleEmitter * object)
{
	return object->m_location.X;
}

extern "C" PARTICLE_API float GetEmitterY(ParticleEmitter * object)
{
	return object->m_location.Y;
}

extern "C" PARTICLE_API void SetEmitterX(ParticleEmitter * object, float x)
{
	object->m_location.X = x;
}

extern "C" PARTICLE_API void SetEmitterY(ParticleEmitter * object, float y)
{
	object->m_location.Y = y;
}

extern "C" 
{
	PARTICLE_API int GetEmitterInitialColourR(ParticleEmitter * p);
    PARTICLE_API int GetEmitterInitialColourG(ParticleEmitter * p);
    PARTICLE_API int GetEmitterInitialColourB(ParticleEmitter * p);
    PARTICLE_API int GetEmitterInitialColourA(ParticleEmitter * p);
    PARTICLE_API int GetEmitterFinalColourR(ParticleEmitter * p);
    PARTICLE_API int GetEmitterFinalColourG(ParticleEmitter * p);
    PARTICLE_API int GetEmitterFinalColourB(ParticleEmitter * p);
    PARTICLE_API int GetEmitterFinalColourA(ParticleEmitter * p);
}

#endif