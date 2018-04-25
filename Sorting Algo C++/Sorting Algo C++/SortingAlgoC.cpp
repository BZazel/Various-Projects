#include "stdafx.h"
#include <iostream>
#include <chrono>
#include <vector>
#define N 500000


using namespace std;

int T[N];
int t[N]; 

void printArray(int x[], int length)
{
	for (int i = 0; i < length; i++)
	{
		cout << " " << x[i]; 
	};
	cout << "||" << endl;
}
void printPartArray(int x[], int start, int length)
{
	for (int i = start; i < length; i++)
	{
		cout << " " << x[i];
	};
	cout << "||" << endl;
}

void BubbleSort(int x[], int length)
{	
	bool sortFlag = true;
	int temp;

	while (sortFlag)
	{
		sortFlag = false;

		for (int i = 1; i < length; i++)
		{
			if (x[i] < x[i - 1])
			{
				sortFlag = true;

				temp = x[i-1];
				x[i - 1] = x[i];
				x[i] = temp;
				//printArray(x, length);
			}
		}
	}
}

void MyPickSort(int x[],int start, int end)
{
	int temp;

	for (int i = start; i < end; i++)
	{
		for (int j = i+1; j < end; j++)
		{
			if ( x[j] < x[i])
			{
				temp = x[i];
				x[i] = x[j];
				x[j] = temp;
				
			}
		}		
	}	
}

void Merge( int p, int s, int k)
{
	int i, j, q;
	
	for (i = p; i <= k; i++)
	{
		t[i] = T[i];
	}

	i = p;
	q = p;

	j = s + 1;

	
	while (i <= s && j <= k)
	{
		
		if (t[j] < t[i])
		{
			T[q++] = t[j++];
			
		}

		else {
			T[q++] = t[i++];
			
		}
	}
	while (i <= s) T[q++] = t[i++];

	

}

void MyMergeSort( int start, int end)
{
	int s;
	if (start < end)
	{
		s = (start+end) / 2;
		
		MyMergeSort(start,s);
		MyMergeSort(s + 1, end);
		Merge(start,s,end);
	}


}

void QuickSort(int p, int k)
{
	if (p < k) {

		int i = 0;
		int s = p;
		int K = k;


		for (i = p + 1; i <= k; i++)
		{
			if (T[i] <= T[p]) t[s++] = T[i];
			else
				t[K--] = T[i];
		}

		//Kopiuj œrodek
		t[s] = T[p];

		//Kopiowanie fragmentów tablic
		for (int j = p; j <= k; j++) T[j] = t[j];
		//printArray(T, N);
		

		QuickSort(s + 1, k);
		QuickSort(p, s - 1);
	}
	
}


void Partitioning(int *tab,int p,int q)
{
	if (q - p <= 200 && p < q)
	{
		MyPickSort(tab, p, q);
		//printPartArray(tab, p, q);
		return;
	}
	else if (p < q) {

		int x = tab[q];
		int i = p;
		int j = q;

		int temp;

		while (true)
		{
			while (tab[j] > x) j--;


			while (tab[i] < x) i++;

			if (i < j)
			{
				//cout << " i = " << i << endl;
				//cout << " j = " << j << endl;

				// cout << T[i] << " Z " << T[j] << endl;

				temp = tab[i];
				tab[i] = tab[j];
				tab[j] = temp;
				if (tab[i] == tab[j])
				{
					
					j--;
				}
				//printArray(T, N);
			}
			else 
			{
				//cout << z << endl;
				
				//cout << "Next" << endl;
				Partitioning(tab,p, j-1);
				Partitioning(tab,j + 1, q);
				
				return;
			}
		}
	}
	//printArray(T, N);
	
}

int OnParts(int*tab, int p, int q)
{
	int i = p;
	int j = q;

	if (p < q) 
	{
		int x = tab[q];

		int temp;

		while (true)
		{
			while (tab[j] > x) j--;

			while (tab[i] < x) i++;

			if (i < j)
			{
				/*cout << " i = " << i << endl;
				cout << " j = " << j << endl;
				 cout << T[i] << " Z " << T[j] << endl;*/

				temp = tab[i];
				tab[i] = tab[j];
				tab[j] = temp;
				

				if (tab[i] == tab[j])
				{
					j--;
				}
				
			}
			else return j;
		}
	}
	
}

void QSort(int *tab, int p, int q)
{
	Recurse:
	//if (q - p <= 100 && p < q)
	//{
	//	MyPickSort(tab, p, q);
	//	//cout << " Part of array" << endl;
	//	//printPartArray(tab, p, q);
	//}
	 if (p < q) 
	{
		 int mid = OnParts(tab, p, q);
		
		if (mid < (q+p)/2)
		{
			QSort(tab, p, mid - 1);
			p = mid + 1; goto Recurse;
		}
		else 
		{
			QSort(tab, mid + 1, q);
			q = mid - 1; goto Recurse;
		}
		 /*QSort(tab, p, mid - 1);
		 QSort(tab, mid + 1, q);*/
	}
}

int main()
{

	
for (int i = 0; i < N; i++) T[i] = (int)(rand() %200);

#pragma region Partitioning


//printArray(T, N);
//auto PartStart = chrono::high_resolution_clock::now();
//
//	QSort(T,0, N-1);
//
//
//auto PartFinish = chrono::high_resolution_clock::now();
//
//chrono::duration<double> PartElapsed = PartFinish - PartStart;
//cout << "Elapsed time: " <<	 PartElapsed.count() * 1000 << " ms\n" << PartElapsed.count() << "s";
////printArray(T, N);
//
//#pragma endregion
//
//#pragma region QuickSort
//	
//	auto QuickStart = chrono::high_resolution_clock::now();
//
//		QuickSort(0, N - 1);
//		auto QuickFinish = chrono::high_resolution_clock::now();
//
//		chrono::duration<double> QuickElapsed = QuickFinish - QuickStart;
//		cout << "Elapsed time: " << QuickElapsed.count() * 1000 << " ms\n" << QuickElapsed.count() << "s";
//	
//
//#pragma endregion
//
//
//
#pragma region MergeSort

	
	auto Pickstart = std::chrono::high_resolution_clock::now();

	MyMergeSort(0, N - 1);

	auto Pickfinish = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> Pickelapsed = Pickfinish - Pickstart;
	std::cout << "Elapsed time: " << Pickelapsed.count() * 1000 << " ms\n" << Pickelapsed.count() << "s";
	
#pragma endregion
		
/*
#pragma region MyPickSort

	auto Pickstart = std::chrono::high_resolution_clock::now();
	MyPickSort(T, N-1);
	auto Pickfinish = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> Pickelapsed = Pickfinish - Pickstart;
	std::cout << "Elapsed time: " << Pickelapsed.count() * 1000 << " ms\n" << Pickelapsed.count() << "s";
#pragma endregion

*/
	/*
#pragma region BubleSort
	auto start = std::chrono::high_resolution_clock::now();
	BubbleSort(T, N-1);
	auto finish = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> elapsed = finish - start;
	std::cout << "Elapsed time: " << elapsed.count() * 1000 << " ms\n" << elapsed.count() << "s";

#pragma endregion*/
	


	int pause = 0;
	cin >> pause ;
	return 0;
}



