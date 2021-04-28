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

enum Side_Index{
    UP,
   // DOWN,
    REPEAT
};

int main(int argc, char *argv[])
{
    // Create an emitter.
    Ultrahaptics::AmplitudeModulation::Emitter emitter;

    // Set frequency to 200 Hertz and maximum intensity
    float frequency = 200.0 * Ultrahaptics::Units::hertz;
    float intensity = 1.0f;
    double board_length;

    // Position the focal point at 20 centimeters above the array.
    float distance = 9.0 * Ultrahaptics::Units::centimetres;

    // Optionally, specify the height of the square in cm on the command line
    if (argc > 1)
    {
        distance = atof(argv[1]) * Ultrahaptics::Units::centimetres;
    }

    Line sqr;

    Side_Index side = UP;

    Ultrahaptics::Vector3 position1(-sqr.length / 2, -sqr.length / 2, distance);
    Ultrahaptics::AmplitudeModulation::ControlPoint point1(position1, intensity, frequency);

    Ultrahaptics::Vector3 start_position = position1;


    unsigned iterations = 0;

    int side_resolution = 100;

    //1200
    auto wait_time_ms = (int) (2500 * 2.5  * sqr.period / (4 * side_resolution));

    for(;;){

        emitter.update(point1);

        if(side == UP) {
            position1.y += sqr.length / side_resolution;
            point1.setPosition(position1);
        }
       /* else if(side == DOWN) {
         //   position1.y -= sqr.length / side_resolution;
          //  point1.setPosition(position1);
        }*/

        iterations++;

        if(iterations%side_resolution == 0 && iterations != 0){
            emitter.stop();
            std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms*40));
            iterations = 0;
            position1 = start_position;
            side = (Side_Index)((unsigned)side+1);
            if (side==REPEAT)
                side=UP;
        }

        std::this_thread::sleep_for(std::chrono::milliseconds(wait_time_ms));
    }

    return 0;
}
