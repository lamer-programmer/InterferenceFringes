# Обработка интерференционных сигналов и картин интерференционных полос

## Команда
* Черкашин Антон (ФФ 19308)
* Волкова Екатерина (ММФ 19137)
* Губер Алексей (ММФ 19144)

## Пробема
Пользователь хочет изучить поверхность линзы или другого оптически совершенного объекта, узнать, насколько она "идеальна". Для этого программа делает анализ интерференционной картины, в который входит
* нахождение линий центров полос в интерференционной картине;
* восстановление “фазового фронта” (значения фазы в каждой точке) по координатам (изгибам) линий центров;
* приведение к гладкой функции (фаза может быть со сдвигом);
* создание карты поверхности.

## Основные компоненты приложения
1. Эмулятор, преобразующий коэффициенты Цернике в интеференционные картины
2. Обработчик двумерных картин интерференционных полос
3. Восстановитель <!-- Понятия не имею, как по-другому написать. --> фазы по линиям экстремумов интерференционных полос
4. Составитель карты поверхности
5. Реализация разложения восстановленной поверхности по полиномам Цернике и построение синтетической интерферограммы
6. Графический интерфейс
   
## Точки расширения
1. Спектральный метод Фурье
2. Метод со сдвигом фаз
3. Возможность экспорта модели полученной поверхности в популярные форматы для дальнейшего анализа
4. Вывод дополнительной статистики
