// T là 1 type/ KDL bất kì
// class generictype
class Box<T>
{
    // đồ chơi
    // cục gạch
    public T GiaTri { get; set; }
}

// ql nhan vien : them , hien thi,xoa,...

// dl task : them task, hine , xoa

// mon an :

interface INhanVien { }

class NhanVien { }

class CucGach
{
    public string Ten { get; set; }
}

class Cat
{
    public string Ten { get; set; }

    public Cat(string ten)
    {
        Ten = ten;
    }

    public void Speak()
    {
        Console.WriteLine($"{Ten} kêu : Meo meo");
    }
}

class NVVP : INhanVien { }

class NVKD : INhanVien { }

class NVSX : INhanVien { }

// bổ sung ràng buộc cho generictype
class QuanLy<T>
    where T : class
{
    List<T> list = new List<T>();
}

class QuanLyHanhChinh<T>
    where T : INhanVien
{
    List<T> list = new List<T>();
}
