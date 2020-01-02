// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
using namespace std;

int age;
int loop;

class Students
{
protected: 
	int age;
	int grade;
public :
	void SetAgeAndGrade(int a, int g) { age = a; grade = g; };
	std::pair<int, int> Output() { return std::make_pair(age, grade); };
};

void Secondary()
{
	std::cout << "Enter your age ";
	cin >> age;
	std::cout << "the age you entered is " << age << endl;
	std::cout << "Enter the amount of time you want to loop ";
	while (loop == 0)
	{
		cin >> loop;
		std::cout << ((loop > 0) ? "looping..." : "re-enter your number") << endl;
	}
	if (loop > 0)
	{
		std::cout << "You wanted to loop " << loop << " Times" << endl;
		for (int i = 0; i < loop; i++)
		{
			std::cout << i + 1 << endl;
		}
	}
}

int GetAverage(int param[], int size)
{
	int average = 0;
	for (int i = 0; i < size; i++)
	{
		average += param[i];
	}
	average /= size;
	return average;
}

int Grades()
{
	std::cout << "Enter your marks" << endl;
	int marks[5];
	for (int i = 0; i < 5; i++)
	{
		cin >> marks[i];
	}
	std::cout << "Your average is " << GetAverage(marks, 5) << endl;
	int grade = GetAverage(marks, 5);
	return grade;
}

char GradeLetter(int mark)
{
	int req[6]{ 50,60,70,80,90, 100};
	char letter[5]{ 'F','D','C','B','A'};
	for (int i = 0; i < 5; i++)
	{
		if (mark >= req[i] && mark < req[i + 1])
			return letter[i];
		else if (mark <= req[0])
			return letter[0];
	}
}

int main()
{
	//Secondary();
	Students s = Students();
	std::cout << "Enter your age" << endl;
	int age = 0; 
	cin >> age;
	int grade = Grades();
	s.SetAgeAndGrade(age, grade);
	std::pair<int, int> p = s.Output();
	std::cout << "You're " << p.first << " years old and scored a " << p.second << endl;
	std::cout << "Your grade is " << GradeLetter(p.second) << endl;

	system("pause");
	cin.get();
	cin.get();
}

