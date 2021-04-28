// This example uses the Amplitude Modulation emitter to project a square
// at a fixed distance above the centre of the array

#include <cstdlib>
#include <iostream>
#include <thread>
#include <chrono>

#include <UltrahapticsAmplitudeModulation.hpp>

struct Line
{
    double length = 40.0 * Ultrahaptics::Units::mm;
    double period = 1;
};

enum Direction{
    UP,
    DOWN,
    REPEAT
};

int main(int argc, char *argv[])
{
    // Create an emitter.
    Ultrahaptics::AmplitudeModulation::Emitter emitter;

    // Set frequency to 200 Hertz and maximum intensity
    float frequency = 200.0 * Ultrahaptics::Units::hertz;
    float intensity = 1.0f;

    // Position the focal point at 9 centimeters above the array.
    float distance = 9.0 * Ultrahaptics::Units::centimetres;

    Line li;

    Direction dir = UP;

    Ultrahaptics::Vector3 position1(-li.length / 2, -li.length / 2, distance);
    Ultrahaptics::AmplitudeModulation::ControlPoint point1(position1, intensity, frequency);

    Ultrahaptics::Vector3 start_position = position1;

    unsigned iterations = 0;
    int resolution = 100;

    //1200
    auto wait_time_ms = (int) (2500 * 2.5 * li.period / (4 * resolution));

    for(;;){
        emitter.update(point1);
        if(dir == UP) {
            position1.y += li.length / resolution;
            point1.setPosition(position1);
        }
        else if(dir == DOWN) {
            position1.y -= li.length / resolution;
            point1.setPosition(position1);
        }
        iterations++;

        if(iterations%resolution == 0 && iterations != 0){
            std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms));
            iterations = 0;
            dir = (Direction)((unsigned)dir+1);
            if (dir==REPEAT)
                position1 = start_position;
                dir=UP;
        }
        std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms));
    }
    return 0;
}
