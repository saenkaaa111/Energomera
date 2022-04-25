using Note.Logic;
using Notes.Data;
using Notes.Model;

namespace Notes.Response
{
    public static class InteractionWithUser
    {
        private static Items item;
        static DataLayer note = new DataLayer();

        public static void Start()
        {
            do
            {
                Console.WriteLine("введите число: \n" +
                                  "\n1 - Get result from algoritm" +
                                  "\n2 - Create in BD" +
                                  "\n3 - Read All" +
                                  "\n4 - Read by id" +
                                  "\n5 - Update by id" +
                                  "\n6 - Delete by id");

                string number = Console.ReadLine();

                switch (number)
                {
                    case "1":
                        GetResultFromAlgoritm();
                        break;

                    case "2":
                        Console.WriteLine("Введите последовательность для записи");
                        item = new Items() { Name = Console.ReadLine() };
                        note.CreateItem(item);
                        Console.WriteLine("Записано");
                        break;

                    case "3":
                        foreach (var it in note.GetItems())
                        {
                            Console.WriteLine(it.Id + " " + it.Name);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Введите id");
                        Console.WriteLine(note.GetItem(Convert.ToInt32(Console.ReadLine())).Name);
                        break;

                    case "5":
                        Console.WriteLine("Введите id");
                        var update = note.GetItem(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Введите последовательность");
                        item = new Items() { Id = update.Id, Name = Console.ReadLine() };
                        note.UpdateItem(item);
                        Console.WriteLine("Изменено");
                        break;

                    case "6":
                        Console.WriteLine("Введите id");
                        note.DeleteItem(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Удалено");
                        break;

                    default:
                        Console.WriteLine("Введено неправильное число");
                        break;
                }

                Console.WriteLine("Для выхода введите Exit, для продолжения нажмите Enter");

            } while (Console.ReadLine() != "exit");
        }

        public static void GetResultFromAlgoritm()
        {
            Console.WriteLine("Введите последовательность");
            var stringFromUser = Console.ReadLine();
            Console.WriteLine(Logic.LogicAlgoritm(stringFromUser));
            Console.WriteLine("Сохранить последовательность в бд? Введите 'Yes' или 'No'");
            var yes = Console.ReadLine();
            if (yes.ToLower() == "yes")
            {
                item = new Items() { Name = stringFromUser };
                note.CreateItem(item);
                Console.WriteLine("Записано");
            }
        }
    }
}
