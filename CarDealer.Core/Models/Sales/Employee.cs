
namespace CarDealer.Core.Models.Sales
{
    public class Employee
    {
        public int Id { get; set; }

        public string Fio {  get; set; }

        public string Email {  get; set; }

        public string Phone {  get; set; }

        public int State { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string fio, string email, string phone, int state)
        {
            Id = id;
            Fio = fio;
            Email = email;
            Phone = phone;
            State = state;
        }

        public static Employee Create(int id, string fio, string email, string phone, int state)
        {
            var employee = new Employee(id, fio, email, phone, state);

            return employee;
        }
    }
}
