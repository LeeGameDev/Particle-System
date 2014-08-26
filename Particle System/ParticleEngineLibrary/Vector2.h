#ifndef VECTOR_2D
#define VECTOR_2D

template <typename T>
class Vector2
{
public:
    T X;
    T Y;

    Vector2() {
        X = 0;
        Y = 0;
    }

    Vector2(T x, T y) {
        X = x;
        Y = y;
    }

    Vector2 &operator+=(Vector2 const &rhs) {
        this->X += rhs.X;
        this->Y += rhs.Y;

        return *this;
    }

    Vector2 &operator*=(float const &rhs) {
        this->X *= rhs;
        this->Y *= rhs;

        return *this;
    }

    ~Vector2() {
    }
};

template<typename T>
Vector2<T> operator+(Vector2<T> lhs, Vector2<T> const &rhs) {
    lhs += rhs;
    return lhs;
}

template<typename T>
Vector2<T> operator*(Vector2<T> lhs, float const &rhs) {
    lhs *= rhs;
    return lhs;
}

typedef Vector2<float> Vector2f;

#endif