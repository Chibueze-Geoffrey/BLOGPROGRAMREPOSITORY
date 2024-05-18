namespace BlogProgram.Common.Helpers
{
    public class Help
    {
        public static List<T> Paginate<T>(List<T> data, ref int pageSize, ref int pageNumber)
        {
            if (pageSize == 0) pageSize = 10;
            if (pageNumber == 0) pageNumber = 1;

            return data.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
    }   }
}
