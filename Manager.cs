using System.Reflection;

class Manager<T>
    where T : class
{
    public List<T> lst = new List<T>();

    //add
    //nhận vào tham số là T: item,...
    public void AddThem(T item)
    {
        lst.Add(item);
    }

    /* demo này chỉ hỗ trợ nếu property là kiểu base , không dùng được néu là list, hashset,...*/
    public void AddByInput()
    {
        // T = student -> thì mình cho nhập dữ liệu liện quan đến studen
        //
        T item = Activator.CreateInstance<T>(); // khởi tạo ra 1 item có kiểu là T

        // lấy ra ds property của T để cho nhập liệu phù hợp
        // student => fullname, classname, yob
        // book => .... tương tự
        PropertyInfo[] proplst = typeof(T).GetProperties();
        foreach (PropertyInfo prop in proplst)
        {
            Console.Write($"Nhập {prop.Name}: ");
            string value = Console.ReadLine();
            // int , double , ...
            // chuyển đổi về đúng type
            var valueConvert = Convert.ChangeType(value, prop.PropertyType);

            // set gias trij cho properti hieenj tai vao cho item
            prop.SetValue(item, valueConvert);
        }
        // nhap xong properti thif theem item vao lst
        lst.Add(item);
    }

    public void Display()
    {
        System.Console.WriteLine($"danh sach {typeof(T)}");
        foreach (T item in lst)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

class Student
{
    public string HoTen { get; set; }
    public string Lop { get; set; }
    public int NamSinh { get; set; }

    public Student() { }

    public Student(string fullname, string className, int yob)
    {
        HoTen = fullname;
        Lop = className;
        NamSinh = yob;
    }

    public override string ToString()
    {
        return $"Fullname: {HoTen} - Class: {Lop} - Year of birth{NamSinh}";
    }
}

class Book
{
    public string tensach { get; set; }
    public string tacgia { get; set; }
    public int namphathanh { get; set; }

    public Book() { }

    public Book(string bookName, string authorName, int yob)
    {
        tensach = bookName;
        tacgia = authorName;
        namphathanh = yob;
    }

    public override string ToString()
    {
        return $"BookName: {tensach} - Author: {tacgia} - Year {namphathanh}";
    }
}
// sau do dung manager dể khởi tại phần quản lý book và student

// Kế thừa, đa hình , trừu tượng

// Trừu tượng:  quy định cái khung, ẩn đi chi tiết , cụ thể class con sex triển khai

//kế thừa : class con nhận tất cả (public , protectec,...) từ class cha hoặc interface đã định nghĩa
// kế thừa giúp thực hiện hoá trừu tượng
// Đa hình :
// kế thừa + abstract class / vitural/ override => 1 phương thucứ có nhiều cấch thể hiện khác nhau
