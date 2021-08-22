namespace DigitalCatalogue
{
    public class Author 
    {
        private readonly int TEXT_SYMB_LIMIT = 200; // поле для лимита ввода

        private string _firstName; // поле для ввода имени автора

        public string FirstName // вызов свойства для имени автора
        {
            get { return _firstName; } 
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT) // реализации проверки на null и пустое место, лимит на ввод
                {
                    _firstName = value;
                }
            }
        }

        private string _lastName; // поле для ввода фамилии автора

        public string LastName // обращение к свойству поля
        {
            get { return _lastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT) // реализации проверки на null и пустое место, лимит на ввод
                {
                    _lastName = value;
                }
            }
        }

        public Author(string firstName, string lastName) // инициализация полей в конструкторе
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
