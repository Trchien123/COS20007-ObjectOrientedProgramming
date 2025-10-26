namespace SemesterTest_104848770
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileSystem filesystem = new FileSystem();

            File file_1 = new File("semester_test", ".pdf", 1024);
            filesystem.Add(file_1);

            Folder folder_1 = new Folder("Semester Test");
            File file_2 = new File("semester_test", ".sln", 2048);
            folder_1.Add(file_2);
            filesystem.Add(folder_1);

            Folder folder_3 = new Folder("Swinburne University");
            Folder folder_2 = new Folder("ID : 104848770");
            File file_3 = new File("std_info", ".docs", 999);
            File file_4 = new File("std_grades", ".docs", 10009);
            folder_2.Add(file_4);
            folder_2.Add(file_3);
            folder_3.Add(folder_2);
            filesystem.Add(folder_3);

            Folder empty_folder = new Folder("New Folder");
            filesystem.Add(empty_folder);

            filesystem.PrintContents();
        }
    }
}
