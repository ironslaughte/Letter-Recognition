namespace NN_Hopfield_WinForm
{
    public class Letter 
    {
        private readonly Vector _vector;

        public Vector Vector => _vector;

        public char Char { get; }

        public int Size => _vector.Size;

        public Letter(char letter, Vector vector)
        {
            Char = letter;
            _vector = vector;
        }
        public float this[int index] => _vector[index];
    }
}
