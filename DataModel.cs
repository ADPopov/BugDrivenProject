using System;
using System.Collections.Generic;

namespace BugDrivenProject
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class Training
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Время
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// Дистанция пройденная спортсменом
        /// </summary>
        public int Distance { get; set; }
        /// <summary>
        /// Продолжительность
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public KindOfSports KindOfSports { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string NameTraining { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Место
        /// </summary>
        public string Place { get; set; }

    }

    /// <summary>
    /// Виды спорта
    /// </summary>
    public enum KindOfSports
    {
        /// <summary>
        /// Беговая тренировка
        /// </summary>
        Running,
        /// <summary>
        /// Тренировка на велосипеде
        /// </summary>
        Biking,
        /// <summary>
        /// Лыжная тренировка
        /// </summary>
        Skiing
    }

    /// <summary>
    /// Спортсмен 
    /// </summary>
    public class Sportsman
    {

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Возраст 
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Спортивный разряд
        /// </summary>
        public string SportsCategory { get; set; }
        /// <summary>
        /// Фотография
        /// </summary>
        public byte[] Photo { get; set; }
        /// <summary>
        /// Персональные рекорды
        /// </summary>
        public List<PersonalRecords> PersonalRecords { get; set; }
        /// <summary>
        /// Тренировки спортсмена
        /// </summary>
        public List<Training> Trainings { get; set; }
    }

    /// <summary>
    /// Личные рекорды спортсмена
    /// </summary>
    public class PersonalRecords
    {
        /// <summary>
        /// Вид спорта
        /// </summary>
        public KindOfSports KindOfSports { get; set; }
        /// <summary>
        /// Дистанция
        /// </summary>
        public int Distance { get; set; }
        /// <summary>
        /// Время
        /// </summary>
        public DateTime Time { get; set; }
    }

    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Мужчина
        /// </summary>
        Male,
        /// <summary>
        /// Женщина
        /// </summary>
        Female
    }
}
