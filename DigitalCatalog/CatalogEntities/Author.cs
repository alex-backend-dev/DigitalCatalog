using System;

namespace DigitalCatalogue
{
    public class Author 
    {
        private readonly int TEXT_SYMB_LIMIT = 200; // поле для лимита ввода

        private string _firstName; // поле для ввода имени автора

        public string FirstName // вызов свойства для имени автора
        {
            get { return _firstName; } 
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT) // реализации проверки на null и пустое место, лимит на ввод
                {
                    _firstName = value;
                }

                else
                {
                    throw new ArgumentException("Ошибка! Значение не может быть пустым!");
                }
            }
        }

        private string _lastName; // поле для ввода фамилии автора

        public string LastName // обращение к свойству поля
        {
            get { return _lastName; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT) // реализации проверки на null и пустое место, лимит на ввод
                {
                    _lastName = value;
                }

                else
                {
                    throw new ArgumentException("Ошибка! Значение не может быть пустым!");
                }
            }
        }

        public Author(string firstName, string lastName) // инициализация полей в конструкторе
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Ошибка! Имя и фамилия автора не могут быть пустыми");
            }

            FirstName = firstName;
            LastName = lastName;
        }
    }
}
