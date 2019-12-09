#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <string.h>

#define BLOCK_SIZE	20
#define DATA_FILE	"masses.data"

int append(int **pArray, int pSize, int* pCapacity) 
{
	if (pSize >= *pCapacity) 
	{
		void *pTemp = realloc(*pArray, sizeof(*pArray) * (*pCapacity + BLOCK_SIZE));

		if (pTemp != NULL)
		{
			*pCapacity = *pCapacity + BLOCK_SIZE;
			*pArray = pTemp;

			return 0; 
		}

		return 1; 
	}

	return 0;
}

void calculate_required_fuel(int mass, int* total_fuel)
{
	int required_fuel = floor(mass / 3) - 2; 

	if (required_fuel > 0)
	{
		*total_fuel += required_fuel;

		calculate_required_fuel(required_fuel, total_fuel);
	}
}

int main()
{
	char	line[256];
	int		capacity = BLOCK_SIZE;
	int		size = 0; 
	int		index = 0;
	FILE*	fp = NULL;
	errno_t	err;

	err = fopen_s(&fp, DATA_FILE, "r");

	if (!err)
	{
		int success = 1; 
		int* masses = malloc(sizeof(int) * capacity);

		while (fgets(line, sizeof(line), fp))
		{
			//if (index != 0)
			{
				if (!append(&masses, index, &capacity))
				{
					masses[index] = (int)atoi(line);
				}
				else
				{
					printf("ERROR. Failed to allocate memory. Exiting...");
					success = 0;
					break; 
				}
			}

			index++;
		}

		if (success)
		{
			int total_required_fuel = 0;
			for (int i = 0; i < index; i++)
			{
				int mass = masses[i];
				if (mass > 0)
				{
					calculate_required_fuel(mass, &total_required_fuel);
				}
			}

			printf("Total required fuel: %d units", total_required_fuel);
		}

		free(masses);
	}

	fclose(fp);

	return 0;
}