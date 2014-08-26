#include "Particle.h"

Particle::Particle(Vector2f position, Vector2f linearVelocity, float angle, float angularVelocity, Colour initialColour, Colour finalColour, float initialTTL, float currentTTL)
    : m_position(position), m_angle(angle), m_linearVelocity(linearVelocity), m_angularVelocity(angularVelocity), m_initial_Colour(initialColour), m_final_Colour(finalColour), m_initialTTL(initialTTL), m_currentTTL(currentTTL) {
}

Particle::~Particle() {
}

void Particle::Update(float delta) {
    m_currentTTL -= delta;
    m_position += m_linearVelocity * delta;
    m_angle += m_angularVelocity * delta;
}

float GetX(Particle ** p) {
    return (* p)->GetPosition().X;
}

float GetY(Particle ** p) {
    return (* p)->GetPosition().Y;
}

float GetInitialTTL(Particle ** p) {
    return (* p)->GetParticleInitialTTL();
}

float GetCurrentTTL(Particle ** p) {
    return (* p)->GetParticleCurrentTTL();
}

int GetInitialColourA(Particle ** p) {
    return static_cast<int>((* p)->m_initial_Colour.A);
}

int GetInitialColourR(Particle ** p) {
    return static_cast<int>((* p)->m_initial_Colour.R);
}

int GetInitialColourG(Particle ** p) {
    return static_cast<int>((* p)->m_initial_Colour.G);
}

int GetInitialColourB(Particle ** p) {
    return static_cast<int>((* p)->m_initial_Colour.B);
}

int GetFinalColourA(Particle ** p) {
    return static_cast<int>((* p)->m_final_Colour.A);
}

int GetFinalColourR(Particle ** p) {
    return static_cast<int>((* p)->m_final_Colour.R);
}

int GetFinalColourG(Particle ** p) {
    return static_cast<int>((* p)->m_final_Colour.G);
}

int GetFinalColourB(Particle ** p) {
    return static_cast<int>((* p)->m_final_Colour.B);
}