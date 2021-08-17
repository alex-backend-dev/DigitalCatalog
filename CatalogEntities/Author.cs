namespace DigitalCatalogue
{
    public class Author
    {
        private readonly int TEXT_SYMB_LIMIT = 200;

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT)
                {
                    _firstName = value;
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= TEXT_SYMB_LIMIT)
                {
                    _lastName = value;
                }
            }
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
