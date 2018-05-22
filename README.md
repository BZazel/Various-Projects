#### Prosta gra służaca za pomoc naukową przy nauce rozróżniania preparatów histopatologicznych napisana przy pomocy WPF.
Aby ją uruchomić wystarczy pobrać i włączyć plik Szkielka.exe


#### Działanie

Program jest przygotowany do wrzucenia do niego zdjęć preparatów histologicznych w następujący sposób:

```      
      Folder główny                             
          ├───(Podfolder1)brodawczak                  
          │   ├───Zdjęcie preparatu 1  
          |   |───Zdjęcie preparatu 2   
          │   └───....            
          ├───(Podfolder2)gruczolak                   
          ├───rak płaskonbłonkowy rogowaci
          ├───włókniak                    
          ├───czerniak                    
          ├───włóknikowe zapalenie płuc   
          └───...
```
Dla każdego foleru w folderze głównych, program tworzy przycisk, który będzie jedną z możliwych odpowiedzi.
Program losuje jedno ze wszystkich zdjęć.

Podczas naciśnięcia przycisku porównywane są ze sobą nazwa przycisku oraz oraz nazwa folderu w którym znajduje się aktulne zdjęcie. 

Jeśli użytkownik odpowie źle, dane zdjęcie ląduje w liście zdjęć "Lista nietrafionych", na którą użytkownik może się potem przełączyć.
Jeśli  jest zaznaczona opcja "pokaż poprawną odpowiedź", zostaje tylko przycisk z poprawną odpowiedzią.
Tak samo dzieje się po naciśnięciu przyski "Pokaż poprawną odpowiedź"

        


      
