class Lasagna
{
    private const int TIME_PER_LAYER = 2;
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int actualMinutes) => ExpectedMinutesInOven() - actualMinutes;

    public int PreparationTimeInMinutes(int numLayers) => numLayers * TIME_PER_LAYER;

    public int ElapsedTimeInMinutes(int numLayers, int timeInOven) => PreparationTimeInMinutes(numLayers: numLayers) 
                                                                      + timeInOven; 
}
