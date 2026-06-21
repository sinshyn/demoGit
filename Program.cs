using Microsoft.Extensions.DependencyInjection;

class Program
{
    public static void Main(string[] args)
    {
        // khai báo class generic
        // tạo box với t là string
        Box<string> boxA = new Box<string>();
        boxA.GiaTri = "hello";
        //boxA.GiaTri = 14; // lỗi vì 14 là cố nguyên không phải string
        // Box<int> boxB = new Box<int>();
        // boxB.GiaTri = 4; // GiaTri chi nhan so nguyên
        // Box<NhanVien> boxC = new Box<NhanVien>();

        // Box<CucGach> boxD = new Box<CucGach>();

        // Box<List<NhanVien>> boxE = new Box<List<NhanVien>>();
        // Box<object> boxF = new Box<object>();
        // T không giới hạn về KDL nhận vào
        // QuanLy<T> where : class
        // không nhận valuetype

        // QuanLy<string> quanLy = new QuanLy<string>();

        // QuanLy<NhanVien> quanLy1 = new QuanLy<NhanVien>();

        // QuanLy<CucGach> quanLy2 = new QuanLy<CucGach>();

        // QuanLyHanhChinh<T> where : INhanVien
        // chỉ nhận những class có implêmnt INhanVien
        // QuanLyHanhChinh<CucGach> qlhc1 = new QuanLyHanhChinh<CucGach>();
        // QuanLyHanhChinh<NVVP> qlhc1 = new QuanLyHanhChinh<NVVP>();

        // Manager<Student>
        // Manager<Student> managerStu = new Manager<Student>();
        // managerStu.AddThem(new Student("Nguyễn Văn An", "Toán Cao Cấp 1", 1990));
        // managerStu.AddThem(new Student("Trần Văn Bảo", "Toán Cao Cấp 2", 1990));
        // managerStu.AddThem(new Student("Lê Thị Bé", "Toán Cao Cấp 3", 1990));
        // managerStu.AddThem(new Student("Nguyễn Thị An", "Toán Cao Cấp 4", 1990));

        // managerStu.AddByInput();
        // managerStu.Display();

        // book
        // Manager<Book> managerBook = new Manager<Book>();
        // managerBook.AddThem(new Book("Sách giáo khoa lớp 1", "Bộ giáo dục", 2000));
        // managerBook.AddThem(new Book("Sách giáo khoa lớp 2", "Bộ giáo dục", 2000));
        // managerBook.AddThem(new Book("Sách giáo khoa lớp 3", "Bộ giáo dục", 2000));
        // managerBook.AddThem(new Book("Sách giáo khoa lớp 4", "Bộ giáo dục", 2000));
        // managerBook.AddByInput();
        // managerBook.Display();

        // ACTIVATOR dùng khi k biết kiểu dữ liệu là gì
        //ACTIVATOR kết hợp với Generic type
        //sử dụng tạo instance k dùng từ khóa new
        //khởi tạo với class k có constructor
        // Type tCucGach = typeof(CucGach);
        // Console.WriteLine(tCucGach);
        // dynamic cucGach1 = Activator.CreateInstance(tCucGach);
        // cucGach1.Ten = "Cục gạch nhỏ màu đen";
        // Console.WriteLine(cucGach1.Ten);

        // khoi tao bang activatỏ cho contructỏ có tham so
        // object meoMun = Activator.CreateInstance(typeof(Cat), "Mun");
        // Cat cat = (Cat)meoMun;
        // cat.Speak();

        // ChimCachCut chimCachCut1 = new ChimCachCut();
        // chimCachCut1.Fly();

        Console.WriteLine("----------- Buoi 13  - DIP --------");

        SaveDataService saveDataService = new SaveDataService("");
        QLHocVien qlhv = new QLHocVien(saveDataService);

        qlhv.LuuThongTin();

        Console.WriteLine("----------- Payment --------");
        IPaymentService momo = new MomoPayment();
        StudentCyber stu = new StudentCyber(momo);
        stu.Name = "sinh vien A";
        stu.Pay();
        IPaymentService paypal = new PaypalPayment();
        StudentCyber stu1 = new StudentCyber(paypal);
        stu1.Name = "sinh vien B";
        stu1.Pay();

        // DI bằng tay - SimpleContainer

        SimpleContainer container = new SimpleContainer();
        // đăng kí
        container.Registers<IPaymentService, MomoPayment>(); // khi gặp chỗ nào dùng Ipayment thì -> momo

        StudentCyber svc = new StudentCyber(container.KhoiTao<IPaymentService>());

        svc.Name = "Sinh viên CNTT";
        svc.Pay();

        // DI bằng thue viên DependencyInjection

        var service = new ServiceCollection();
        service.AddScoped<IPaymentService, MomoPayment>();
        service.AddSingleton<StudentCyber>();
        //khởi tạo mới khi nào
        //AddSingleton: khởi tạo 1 lần duy nhất khi chạy ứng dụng, dùng chung
        //AddScoped: khởi tạo mới vào mỗi request, cùng phiên thì không tạo mới
        //AddTransient: khởi tạo mới khi gặp các đối tượng được đăng kí bằng AddTransient, cấp mới khi dùng

        //ví dụ
        //AddSingleton mỗi quán ăn có 1 bình nước
        //AddScoped mỗi khách vào quán có 1 ly nước riêng (trà đá)
        //AddTransient mỗi lần order nước mới (nước mua tốn tiền) phải đưa ly mới 

        //builder provider
        var serProvider = service.BuildServiceProvider();

        // tạo thằng student cybersoft
        var studentCybersoft = serProvider.GetService<StudentCyber>();
        studentCybersoft.Name = "Sinh viên học IT";
        studentCybersoft.Pay();
    }
}
