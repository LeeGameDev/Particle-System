#ifndef COLOUR_H
#define COLOUR_H

class Colour
{
public:
    unsigned char R;
    unsigned char G;
    unsigned char B;
    unsigned char A;

    Colour(unsigned char r, unsigned char g, unsigned char b, unsigned char a);
    ~Colour();
};

#endif