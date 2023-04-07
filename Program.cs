using System.Text;
namespace TheTenthHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание первой директории.
            DirectoryInfo theFirstDirectoryInfo = new(@"c:\Otus\TestDir1");
            try
            {
                if (theFirstDirectoryInfo.Exists)
                {
                    Console.WriteLine("Этот путь уже существует! - c:\\Otus\\TestDir1");
                }
                else
                {
                    theFirstDirectoryInfo.Create();
                    Console.WriteLine("Каталог успешно создан!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания каталога!\n {ex.Message}");
            }
            // Создание второй директории.
            DirectoryInfo theSecondDirectoryInfo = new(@"c:\Otus\TestDir2");
            try
            {
                if (theSecondDirectoryInfo.Exists)
                {
                    Console.WriteLine("Этот путь уже существует!- c:\\Otus\\TestDir2");
                }
                else
                {
                    theSecondDirectoryInfo.Create();
                    Console.WriteLine("Каталог успешно создан!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка создания каталога!\n {ex.Message}");
            }

            for (int i = 1; i <= 10; i++)
            {
                string nameOfFile = $"File{i}";
                string textOfFile = $"Текст {i} файла, Дата создания: ";
                string messageNoRights = $"Ошибка сохранения файла! {nameOfFile} Отсутствуют права на запись.";
                string messageErrorOfSaving = $"Файл {nameOfFile} создан ранее. Ошибка сохранения.";
                string pathofTheFirstDirectory = $"c:\\Otus\\TestDir1\\File{i}.txt";
                if (!File.Exists(pathofTheFirstDirectory))
                {
                    try
                    {
                        File.WriteAllText(pathofTheFirstDirectory, textOfFile + DateTime.Now, Encoding.UTF8);
                    }
                    catch
                    {
                        Console.WriteLine(messageNoRights);
                    }
                }
                else
                {
                    Console.WriteLine(messageErrorOfSaving);
                }
                string pathOfTheSecondDirectory = $"c:\\Otus\\TestDir2\\File{i}.txt";
                if (!File.Exists(pathOfTheSecondDirectory))
                {
                    try
                    {
                        File.WriteAllText(pathOfTheSecondDirectory, textOfFile + DateTime.Now, Encoding.UTF8);
                    }
                    catch
                    {
                        Console.WriteLine(messageNoRights);
                    }
                }
                else
                {
                    Console.WriteLine(messageErrorOfSaving);
                }
                Console.WriteLine(nameOfFile + " " + File.ReadAllText(pathOfTheSecondDirectory));
                Console.WriteLine(nameOfFile + " " + File.ReadAllText(pathofTheFirstDirectory));
            }
        }
    }
}