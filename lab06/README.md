## Алгоритм Хаффмана

Сжатие -- процесс сокращения количества бит для хранения одного и того же объема информации.  
2 подхода:
* замена повторяющихся последовательностей кодом;
* замена часто встречающихся символов короткими кодами.

**Шаги**:
1. собираем статистику
2. получаем коды
3. замена

**Алгоритм сжатия**
1. построение таблицы частот
2. сортировка по возрастанию частот
3. если в статистике больше 1 узла, то
4. берём 2 (0 и 1) узла с наименьшими частотами, формируем для них общего родителя, его частота равна сумме частот двух узлов
5. удаляем эти два узла из статистики
6. добавляем родительский узел в статистику
7. повторяем с пункта 3
8. ------
9. если один элемент в массиве => корень, всё, готово дерево
10. составляем по дереву коды: 0 - влево, 1 - вправо
11. идём по файлу и заменяем символ на код

**Алгоритм разжатия**
1. Восстанавливаем коды
2. Идём по файлу и по дереву и всё восстанавливаем
