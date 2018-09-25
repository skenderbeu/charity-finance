namespace FinanceDomain
{
    public class Note : ValueObject<Note>
    {
        public virtual string Value { get; protected set; }

        private Note()
        {
            new Note(string.Empty);
        }

        private Note(string value)
        {
            Value = value;
        }

        public static Result<Note> Create(string note)
        {
            note = note.Trim();
            if (note.Length > 500)
                return Result.Fail<Note>("Note is too long");

            return Result.Ok(new Note(note));
        }

        protected override bool EqualsCore(Note other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator Note(string note)
        {
            return Create(note).Value;
        }

        public static implicit operator string(Note note)
        {
            return note.Value;
        }
    }
}