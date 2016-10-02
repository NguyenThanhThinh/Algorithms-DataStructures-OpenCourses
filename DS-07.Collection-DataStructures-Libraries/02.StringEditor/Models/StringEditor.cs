namespace _02.StringEditor.Models
{
    using System;

    using Interfaces;

    using Wintellect.PowerCollections;

    public class StringEditor : IStringEditor
    {
        private BigList<char> chars;

        public StringEditor()
        {
            this.chars = new BigList<char>();
        }

        public bool Append(string str)
        {
            try
            {
                this.chars.AddRange(str);
            }
            catch (ArgumentNullException)
            {
                return false;
            }

            return true;
        }

        public bool Insert(int index, string str)
        {
            try
            {
                this.chars.InsertRange(index, str);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException ||
                    ex is ArgumentNullException)
                {
                    return false;
                }

                throw;
            }

            return true;
        }

        public bool Delete(int index, int count)
        {
            try
            {
                this.chars.RemoveRange(index, count);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public bool Replace(int index, int count, string str)
        {
            try
            {
                this.chars.RemoveRange(index, count);
                this.Insert(index, str);
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public string Print() => string.Join(string.Empty, this.chars);
    }
}