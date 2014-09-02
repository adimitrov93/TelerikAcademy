public void PrintStatistics(double[] arrayOfNumbers, int countForStatistics)
{
	double max = double.MinValue;
	for (int i = 0; i < countForStatistics; i++)
	{
		if (arrayOfNumbers[i] > max)
		{
			max = arrayOfNumbers[i];
		}
	}

	PrintMax(max);

	double min = double.MaxValue;
	for (int i = 0; i < countForStatistics; i++)
	{
		if (arrayOfNumbers[i] < min)
		{
			min = arrayOfNumbers[i];
		}
	}

	PrintMin(min);

	double sum = 0;
	for (int i = 0; i < countForStatistics; i++)
	{
		sum += arrayOfNumbers[i];
	}

	PrintAvg(sum / countForStatistics);
}