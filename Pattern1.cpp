//Two lines travels forwards around the finger

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
    REPEAT
};

int main(int argc, char *argv[])
{
    // Create an emitter.
    Ultrahaptics::AmplitudeModulation::Emitter emitter;

    // Set frequency to 200 Hertz and maximum intensity
    float frequency = 200.0 * Ultrahaptics::Units::hertz;
    float intensity = 1.0f;

    // Position the focal point at 20 centimeters above the array.
    float distance = 15.0 * Ultrahaptics::Units::centimetres;

    // Optionally, specify the height of the square in cm on the command line
    if (argc > 1)
    {
        distance = atof(argv[1]) * Ultrahaptics::Units::centimetres;
    }

    Line li;
    Direction dir = UP;

    Ultrahaptics::Vector3 position1((-li.length / 2) + (3 * Ultrahaptics::Units::centimetres), -li.length / 2, distance);
    Ultrahaptics::Vector3 position2((-li.length / 2) - (1.6 * Ultrahaptics::Units::centimetres) + (3 * Ultrahaptics::Units::centimetres)
            , -li.length / 2, distance);
    Ultrahaptics::AmplitudeModulation::ControlPoint point1(position1, intensity, frequency);

    Ultrahaptics::Vector3 start_position = position1;
    Ultrahaptics::Vector3 start_position2 = position2;

    unsigned iterations = 0;
    int resolution = 100;
    auto wait_time_ms = (int) (2750 * 2.5  * li.period / (4 * resolution));
    unsigned counter = 0;

    for(;;){
        if(dir == UP) {

            position1.y += li.length / resolution;
            point1.setPosition(position1);
            emitter.update(point1);

            std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms));

            position2.y += li.length / resolution;
            point1.setPosition(position2);
            emitter.update(point1);
        }
        iterations++;

        if(iterations%resolution == 0 && iterations != 0){
            emitter.stop();
            std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms*40));

            counter += 1;
            if(counter == 3){
                return 0;
            }
            iterations = 0;
            position1 = start_position;
            position2 = start_position2;
            dir = (Direction)((unsigned)dir+1);
            if (dir==REPEAT)
                dir=UP;
        }
        std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms));
    }
    return 0;
}
