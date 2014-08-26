#ifndef EXPORT_H
#define EXPORT_H

#ifdef PARTICLELIBRARY_EXPORT
#define PARTICLE_API __declspec(dllexport)
#else 
#define PARTICLE_API __declspec(dllimport)
#endif

#endif