using Exercicio01_Section17.Entities;
using System.Globalization;

namespace Exercicio01_Section17 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salaryMin = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.WriteLine("Email of people whose salary is more than 2000.00:");
            var moreThan = list.Where(p => p.Salary > salaryMin).Select(p => p.Email);
            foreach (string emial in moreThan) {
                Console.WriteLine(emial);
            }
            

            var Sum = list.Where(p => p.Name[0] == 'M').Select(p => p.Salary).Aggregate(0.0, (x,y) => x + y);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + Sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}