public class Sorter
{
    private CustomList<string> customList;

    public Sorter(CustomList<string> customList)
    {
        this.customList = customList;
    }

    public void Sort()
    {
        this.customList.Sort();
    }
}