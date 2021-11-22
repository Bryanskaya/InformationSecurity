## Алгоритм RSA

Алгоритм ассимитричного шифрование на основе открытого ключа.

1. Берутся два простых больших числа p, q.
1. n = p * q
1. Берётся случайное число d - взаимно простое с функцией Эйлера fi = (p - 1)(q - 1)
> Взаимно простое = не имеет ни одного общего делителя, кроме 1  
> Находится по расширенномуалгоритму Евклида
1. Определим случайное е (от 2 да fi), такое что: е взаимно простое с fi
1. Открытый ключ - e и n, секретный d и n.

### Шифрование
Текст на блоки и каждая единица текста возводится в степень е по модулю n.

### Расшифровка
Зашифрованный текст возводится в степень d по модулю n

### Отличия расширенного алгоритма Евклида от простого
"Обычный" алгоритм Евклида находит наибольший общий делитель двух чисел a и b. 
Расширенный алгоритм Евклида находит помимо НОД также коэффициенты x и y такие, что:
ax + by = НОД(a, b).