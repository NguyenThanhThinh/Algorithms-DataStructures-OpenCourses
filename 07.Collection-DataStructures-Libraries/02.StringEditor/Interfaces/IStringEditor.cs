namespace _02.StringEditor.Interfaces
{
    public interface IStringEditor
    {
        bool Append(string str);

        bool Delete(int index, int count);

        bool Insert(int index, string str);

        string Print();

        bool Replace(int index, int count, string str);
    }
}