# OOP

## [Лабораторна робота №1](https://github.com/MazurenkoNick/OOP/tree/main/Lab1)
Створити клас GameAccount.
Клас має обов’язково мати поля:
  UserName – Імя користувача
  CurrentRating – Рейтинг користувача
  GamesCount – Кількість зіграних партій
Клас має мати функції:
- WinGame з полями – функція яка визивається у випадку перемоги
    opponentName – і’мя опонента
    rating – рейтинг на який була гра
- LoseGame з полями – функція яка визивається у випадку поразки
    opponentName
    rating
- GetStats – функція яка показує історію ігор(Проти кого, перемога чи поразка, на який рейтинг грали, індекс гри)
Загальні умови:
Рейтинг не може стати менше 1.
Рейтинг на який грають не може бути від'ємним(в цьому випадку треба викинути помилку).
Для гри треба створити окремий клас в йому буде зберігатися потрібна інформація.
В мейні треба створити 2 об’єкти класу гравця, зробити імітацію декількох ігр та вивести статистику кожного гравця.

## [Лабораторна робота №2](https://github.com/MazurenkoNick/OOP/tree/main/Lab2)
Модифікувати першу лабораторну
- Зробити декілька видів аккаунтів з різними методами нарахування балів. Наприклад: базовий аккаунт, аккаунт у якого знімається вдвічі менше балів, в якому нараховуються додаткові бали за серію перемог і тд. (мінімум 2 види крім базового)
- Зробити різни типи ігор. Базовий клас має бути абстрактним, містити код загальний для усіх ігор, та мають бути конкретні реалізації. Наприклад:
стандартна гра, тренувальна без рейтингу гра, де на рейтинг грає лише один гравець. Мінімум 3 види
- Зробити клас який буде містити в собі функціонал для повернення гри будь якого типу, приводячи його до базового типу гри.
- Модифікувати методи гравців WinGame та LoseGame щоб замість рейтингу приходив об’єкт базової гри, що містить метод\властивість для визначення на який рейтинг була гра.
- В результаті ви матимете базу гравців для кожного з яких буде розраховуватися зміна рейтингу в залежності від типу їх аккаунту та клас для генерації ігор різних типів на різний рейтинг.
- Попередній функціонал має залишитись теж.
