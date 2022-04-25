namespace Note.Logic
{
    public static class Logic
    {

        public static bool LogicAlgoritm(string name)
        {
            do
            {
                var count = name.Length;
                name = name.Replace("()", "");
                name = name.Replace("{}", "");
                name = name.Replace("[]", "");

                if (count == name.Length && count != 0)
                    return false;

            } while (name.Length > 0);

            return true;
        }
    }
}
